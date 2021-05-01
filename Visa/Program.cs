using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using DSPLib;
using System.IO;

namespace Visa
{
    class Program
    {
        static void Main(string[] args)
        {
            VISA_Osciloscope osciloscope = new VISA_Osciloscope();

            //osciloscope.Stop();

            //System.Threading.Thread.Sleep(500);

            //Console.WriteLine(osciloscope.GetTemplate());

            osciloscope.GetWaveform_Setup();

            osciloscope.SetAcquireMemorySize(MemorySize.MS_14M);

            double samplingRate = osciloscope.GetSampleRate();
            //osciloscope.GetVDiv(1);
            //osciloscope.GetVOffset(1);
            //osciloscope.GetTDiv();-
            osciloscope.WaitTriggerReady();
            osciloscope.Arm_Acquisition();
            osciloscope.WaitTriggerStop();
            //osciloscope.Stop();

            var wave = osciloscope.GetWaveform(1);
            // var wave2 = osciloscope.GetWaveform(1);
            // var wave3 = osciloscope.GetWaveform(1);
            wave.SaveCSV("test.csv");
            osciloscope.Close();





            // Same Input Signal as Example 1 - Except a fractional cycle for frequency.
            //   double amplitude = 1.0; double frequency = 20000.5;
            //   UInt32 length = 1024; 
            UInt32 zeroPadding = 0; // NOTE: Zero Padding


            //    double[] inputSignal = DSPLib.DSP.Generate.ToneSampling
            //                           (amplitude, frequency, samplingRate, length);

            UInt32 points = Convert.ToUInt32(Math.Pow(2, Math.Floor(Math.Log(wave.Times.Count(), 2))));
            Console.WriteLine("Calculating FFT based on {0} samples", points);

            double[] inputSignal = new double[points];

            for (int i = 0; i < points; i++)
            {
                inputSignal[i] = wave.Values[i];
            }
            UInt32 length = points;


            // Apply window to the Input Data & calculate Scale Factor
            double[] wCoefs = DSP.Window.Coefficients(DSP.Window.Type.Hamming, length);
            double[] wInputData = DSP.Math.Multiply(inputSignal, wCoefs);
            double wScaleFactor = DSP.Window.ScaleFactor.Signal(wCoefs);

            // Instantiate & Initialize a new DFT
            DSPLib.FFT fft = new DSPLib.FFT();
            fft.Initialize(length, zeroPadding); // NOTE: Zero Padding

            // Call the DFT and get the scaled spectrum back
            Complex[] cSpectrum = fft.Execute(wInputData);

            // Convert the complex spectrum to note: Magnitude Format
            double[] lmSpectrum = DSPLib.DSP.ConvertComplex.ToMagnitude(cSpectrum);

            // Properly scale the spectrum for the added window
            lmSpectrum = DSP.Math.Multiply(lmSpectrum, wScaleFactor);

            // For plotting on an XY Scatter plot generate the X Axis frequency Span
            double[] freqSpan = fft.FrequencySpan(samplingRate);

            // At this point a XY Scatter plot can be generated from,
            // X axis => freqSpan
            // Y axis => lmSpectrum



            StringBuilder sb = new StringBuilder(lmSpectrum.Length * 10);

            int valuesCount = lmSpectrum.Count();


            // Header
            sb.Append("Freq,FFT");


            // Data
            for (int i = 0; i < valuesCount; i++)
            {
                sb.Append(freqSpan[i]);
                sb.Append(",");
                sb.Append(lmSpectrum[i]);
                sb.Append("\n");
            }

            //sb = sb.Replace('.', ',');                     // Excel ITA compatibility
            File.Delete("fft.csv");
            File.WriteAllText("fft.csv", sb.ToString());


            Console.ReadKey();
        }
    }
}
