using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using DSPLib;
using Utilities;
using Visa;
using FY_AWG;

namespace FFT_Scan
{

    enum Octaves
    {
        O1,
        O3rd,
        O6th

    }

    public partial class Form1 : Form
    {
        VISA_Osciloscope osciloscope;
        Interface siggen;

        DSPLib.FFT fft;
        double samplingRate;
        UInt32 FFTLength;

        int ResultStart;
        int ResultEnd;
        int ResultSize;

        UInt32 zeroPadding = 0; // NOTE: Zero Padding

        double[] FFTInputSignal;

        List<OctaveBand> OctaveBands;

        FFTBin FFTBins;
        OctaveBin OctaveBins;


        public Form1()
        {
            InitializeComponent();

            siggen = new Interface(17);
            siggen.OpenComport();

            osciloscope = new VISA_Osciloscope();
            osciloscope.SetAcquireMemorySize(MemorySize.MS_14M);
            samplingRate = osciloscope.GetSampleRate();
            var wave = osciloscope.GetWaveform(1);

            FFTLength = Convert.ToUInt32(Math.Pow(2, Math.Floor(Math.Log(wave.Times.Count(), 2))));
            FFTInputSignal = new double[FFTLength];

            labelScopeSampleFrequency.Text = samplingRate.ToString() + " Samples/s";
            labelCapturedSamples.Text = wave.Values.Count() + " Samples";
            labelFFTLength.Text = FFTLength + " Samples";

            zeroPadding = 0; // NOTE: Zero Padding

            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
        }


        public double FindNearestFFTBucket(OctaveBand Band, double freq, bool SetScanned)
        {
            int NearestIndex = -1;
            double Difference = 100000;

            for (int i = 0; i < ResultSize; i++)
            {
                if (Band == null)
                {
                    if (Math.Abs(freq - FFTBins.Frequency[i]) < Difference)
                    {
                        Difference = Math.Abs(freq - FFTBins.Frequency[i]);
                        if (!FFTBins.Scanned[i])
                        {
                            NearestIndex = i;
                        }
                    }
                }
                else
                {
                    if ((FFTBins.Frequency[i] >= Band.Lower) && (FFTBins.Frequency[i] <= Band.Upper))
                    {
                        if (Math.Abs(freq - FFTBins.Frequency[i]) < Difference)
                        {
                            Difference = Math.Abs(freq - FFTBins.Frequency[i]);
                            if (!FFTBins.Scanned[i])
                            {
                                NearestIndex = i;
                            }
                        }
                    }
                }
            }

            if (NearestIndex >= 0)
            {
                if (SetScanned)
                {
                    FFTBins.Scanned[NearestIndex] = true;
                }
                return FFTBins.Frequency[NearestIndex];
            }
            else
            {
                return 0;
            }
        }


        public void TakeSample(OctaveBand Band, double SigGenFreq)
        {
            DSPLib.FFT fft = new DSPLib.FFT();
            fft.Initialize(FFTLength, zeroPadding); // NOTE: Zero Padding

            if (FFTBins == null)
            {
                // On first run, build frequency table
                double[] freqSpan = fft.FrequencySpan(samplingRate);

                ResultStart = 0;
                ResultEnd = 0;

                for (int i = 0; i < freqSpan.Count(); i++)
                {
                    if ((ResultStart == 0) && (freqSpan[i] >= 1)) ResultStart = i;
                    if ((ResultEnd == 0) && (freqSpan[i] >= 20000)) ResultEnd = i;
                }

                ResultSize = ResultEnd - ResultStart;
                FFTBins = new FFTBin(ResultSize);

                for (int i = 0; i < ResultSize; i++)
                {
                    FFTBins.Frequency[i] = freqSpan[ResultStart + i];
                }
            }

            SigGenFreq = FindNearestFFTBucket(Band, SigGenFreq, true);

            if (SigGenFreq > 0)
            {
                labelScanning.Text = SigGenFreq.ToString();
                this.Refresh();

                siggen.SetFrequency(1, SigGenFreq);
                siggen.SetAmplitude(1, 2);

                System.Threading.Thread.Sleep(100);

                osciloscope.WaitTriggerReady();
                osciloscope.Arm_Acquisition();
                osciloscope.WaitTriggerStop();

                var wave = osciloscope.GetWaveform(1);

                if (wave.Values.Count() > 0)
                {

                    for (int i = 0; i < FFTLength; i++)
                    {
                        FFTInputSignal[i] = wave.Values[i];
                    }

                    //double[] FFTInputSignal = DSPLib.DSP.Generate.ToneSampling(1, SigGenFreq, samplingRate, FFTLength);

                    // Apply window to the Input Data & calculate Scale Factor
                    double[] wCoefs = DSP.Window.Coefficients(DSP.Window.Type.Hanning, FFTLength);
                    double[] wInputData = DSP.Math.Multiply(FFTInputSignal, wCoefs);
                    double wScaleFactor = DSP.Window.ScaleFactor.Signal(wCoefs);

                    // Call the FFT and get the scaled spectrum back
                    Complex[] cSpectrum = fft.Execute(wInputData);

                    // Convert the complex spectrum to note: Magnitude Format
                    double[] lmSpectrum = DSPLib.DSP.ConvertComplex.ToMagnitude(cSpectrum);

                    // Properly scale the spectrum for the added window
                    // lmSpectrum = DSP.Math.Multiply(lmSpectrum, wScaleFactor);
                    lmSpectrum = DSP.ConvertMagnitude.ToMagnitudeDBV(DSP.Math.Multiply(lmSpectrum, wScaleFactor));


                    for (int i = 0; i < ResultSize; i++)
                    {
                        if (lmSpectrum[ResultStart + i] > FFTBins.ResponseVal[i])
                        {
                            FFTBins.ResponseVal[i] = lmSpectrum[ResultStart + i];
                        }


                        for (int j = 0; j < OctaveBands.Count - 1; j++)
                        {
                            if ((OctaveBands[j].Lower <= FFTBins.Frequency[i]) && (OctaveBands[j].Upper >= FFTBins.Frequency[i]))
                            {
                                if (FFTBins.ResponseVal[i] > OctaveBins.ResponseValOct[j])
                                {
                                    OctaveBins.ResponseValOct[j] = FFTBins.ResponseVal[i];
                                }
                            }
                        }
                    }

                    for (int j = 1; j < OctaveBands.Count - 1; j++)
                    {
                        if (OctaveBins.ResponseValOct[j] == -1000)
                        {
                            for (int n = j; n >=0; n--)
                            {
                                if (OctaveBins.ResponseValOct[n] > -1000)
                                {
                                    for (int m = j; m < OctaveBands.Count; m++)
                                    {
                                        if (OctaveBins.ResponseValOct[m] > -1000)
                                        {
                                            OctaveBins.ResponseValOct[j] = (OctaveBins.ResponseValOct[n] + OctaveBins.ResponseValOct[m]) / 2;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    PlotData(FFTBins.Frequency, FFTBins.ResponseVal, OctaveBins.FrequencyOct, OctaveBins.ResponseValOct);
                }
            }
        }


        public void PlotData(double[] xData, double[] yData, double[] xDataOct, double[] yDataOct)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.DataBindXY(xData, yData);
            chart1.Series[1].Points.Clear();
            chart1.Series[1].Points.DataBindXY(xDataOct, yDataOct);
            chart1.ChartAreas[0].AxisX.IsLogarithmic = true;
            this.Refresh();
        }


        private void buttonTakeMeasurement_Click(object sender, EventArgs e)
        {
            TakeSample(null, 800);
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            osciloscope.Close();
            siggen.CloseComport();
        }


        private void buttonScan_Click(object sender, EventArgs e)
        {
            bool ValidSmoothing = false;

            switch (comboBoxSmoothing.Text)
            {
                case "Octave":
                    OctaveBands = CalculateOctaveBands(Octaves.O1);
                    ValidSmoothing = true;
                    break;
                case "1/3 Octave":
                    OctaveBands = CalculateOctaveBands(Octaves.O3rd);
                    ValidSmoothing = true;
                    break;
                case "1/6 Octave":
                    OctaveBands = CalculateOctaveBands(Octaves.O6th);
                    ValidSmoothing = true;
                    break;
                default: break;
            }
          
            if (ValidSmoothing == true)
            {
                OctaveBins = new OctaveBin(OctaveBands.Count);

                for (int i = 0; i < OctaveBands.Count; i++)
                {
                    OctaveBins.FrequencyOct[i] = OctaveBands[i].Centre;
                    OctaveBins.ResponseValOct[i] = -1000;
                }

                for (int i = 0; i < OctaveBands.Count; i++)
                {
                    TakeSample(OctaveBands[i], OctaveBands[i].Centre);
                }
            }
        }


        private List<OctaveBand> CalculateOctaveBands(Octaves oct)
        {
            List<OctaveBand> OctaveBands = new List<OctaveBand>();

            int StartBand;
            int EndBand;
            double coefficient;

            switch (oct)
            {
                case Octaves.O1:
                    StartBand = 3;
                    EndBand = 15;
                    coefficient = 0.3;
                    break;
                case Octaves.O3rd:
                    StartBand = 10;
                    EndBand = 44;
                    coefficient = 0.1;
                    break;
                case Octaves.O6th:
                    StartBand = 20;
                    EndBand = 87;
                    coefficient = 0.05;
                    break;
                default:
                    StartBand = 3;
                    EndBand = 15;
                    coefficient = 0.3;
                    break;
            }

            for (int i = StartBand; i <= EndBand; i++)
            {
                OctaveBand Band = new OctaveBand();
                Band.Centre = Math.Round(Math.Pow(10, coefficient * i), 2);
                Band.Lower = Math.Round(Band.Centre / Math.Pow(10, coefficient / 2), 2);
                Band.Upper = Math.Round(Band.Centre * Math.Pow(10, coefficient / 2), 2);
                OctaveBands.Add(Band);
            }    

            return OctaveBands;
        }
    }
}
