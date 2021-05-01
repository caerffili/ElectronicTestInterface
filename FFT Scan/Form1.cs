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
using Visa;
using FY_AWG;

namespace FFT_Scan
{
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

        double[] Frequency;
        double[] ResponseVal;
        double[] ResponseValSmoothed;

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
         //   fft = new DSPLib.FFT();
       //     fft.Initialize(FFTLength, zeroPadding); // NOTE: Zero Padding

            // Add the titles
            // chart1.Titles["Title"].Text = mTitle;
            //  this.Text = mTitle;
            //  chart1.Titles["AxisX"].Text = mAxisX;
            //  chart1.Titles["AxisY"].Text = mAxisY;

            // Enable zooming
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
        }

        public void TakeSample(double SigGenFreq)
        {
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

                // Instantiate & Initialize a new DFT
                DSPLib.FFT fft = new DSPLib.FFT();
                fft.Initialize(FFTLength, zeroPadding); // NOTE: Zero Padding


                // Call the DFT and get the scaled spectrum back
                Complex[] cSpectrum = fft.Execute(wInputData);

                // Convert the complex spectrum to note: Magnitude Format
                double[] lmSpectrum = DSPLib.DSP.ConvertComplex.ToMagnitude(cSpectrum);

                // Properly scale the spectrum for the added window
               // lmSpectrum = DSP.Math.Multiply(lmSpectrum, wScaleFactor);
                lmSpectrum = DSP.ConvertMagnitude.ToMagnitudeDBV(DSP.Math.Multiply(lmSpectrum, wScaleFactor));

                // For plotting on an XY Scatter plot generate the X Axis frequency Span
                double[] freqSpan = fft.FrequencySpan(samplingRate);


                if (Frequency == null)
                {
                    ResultStart = 0;
                    ResultEnd = 0;

                    for (int i = 0; i < freqSpan.Count(); i++)
                    {
                        if ((ResultStart == 0) && (freqSpan[i] >= 1)) ResultStart = i;
                        if ((ResultEnd == 0) && (freqSpan[i] >= 20000)) ResultEnd = i;
                    }

                    ResultSize = ResultEnd - ResultStart; 
                    Frequency = new double[ResultSize];
                    ResponseVal = new double[ResultSize];
                    ResponseValSmoothed = new double[ResultSize];

                    for (int i = 0; i < ResultSize; i++)
                    {
                        Frequency[i] = freqSpan[ResultStart + i];
                        ResponseVal[i] = -1000;
                    }
                }

                int lv = 0; 
                for (int i = 0; i < ResultSize; i++)
                {
                    if (lmSpectrum[ResultStart + i] > ResponseVal[i])
                    {
                        ResponseVal[i] = lmSpectrum[ResultStart + i];
                        //lv = ResponseValSmoothed
                    }
                }

                PlotData(Frequency, ResponseVal);
            }
        }

        public void PlotData(double[] xData, double[] yData)
        {
            chart1.Series["Series1"].Points.Clear();
            chart1.Series["Series1"].Points.DataBindXY(xData, yData);
            chart1.ChartAreas[0].AxisX.IsLogarithmic = true;
            this.Refresh();
        }

        private void buttonTakeMeasurement_Click(object sender, EventArgs e)
        {
            TakeSample(800);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            osciloscope.Close();
            siggen.CloseComport();
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            for (int i = 5; i < 140; i++)
            {
                // TakeSample(10);
                // TakeSample(25);
                TakeSample(i * i);
            }
          //  TakeSample(100);
        //    TakeSample(250);
      //      TakeSample(500);
        //    TakeSample(1000);
        //    TakeSample(2500);
      //      TakeSample(4998.09);
         //   TakeSample(7500);
            //  TakeSample(10000);
         //   TakeSample(12500);
        }
    }
}
