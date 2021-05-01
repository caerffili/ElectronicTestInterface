using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FY_AWG
{

    public enum Output
    {
        WaveForm,
        Frequency,
        Amplitude,
        Offset,
        Duty,
        Phase,
        Status
    }

    public enum Measurement
    {
        GateTime,
        Frequency,
        CountingValue,
        CountingPeriod,
        PositivePulseWidth,
        NegativePulseWidth,
        DutyCycle
    }

    public enum CouplingMode
    {
        DC = 0,
        AC = 1
    }

    public enum GateTime
    {
        Gate1s = 0,
        Gate10s = 1,
        Gate100s = 2
    }

    public enum Trigger
    {
        TriggerMode,
        PulseAmount,
        ASKMmode,
        FSKMode,
        FSKSecondaryFrequency,
        PSKMode
    }

    public enum SweepControl
    {
        Time = 0,
        VCO = 1
    }

    public enum SweepObject
    {
        Frequency = 0,
        Amplitude = 1,
        Offset = 2,
        DutyCycle = 3
    }

    public enum SweepMode
    {
        Linear = 0,
        Logarithmic = 1
    }

    public enum OnOff
    {
        off = 0,
        on = 1
    }

    /*  public enum SystemSetting
      {
          Syncronisation,
          BuzzerStatus,
          UploadMode,
          UplinkStatus,
          LocalID,
          LocalModel
      }*/

    public enum WaveForm
    {
        SineWave = 0,
        SquareWave,
        Triangle,
        RiseSawtooth,
        FallSawtooth,
        StepTriangle,
        PositiveStep,
        InverseStep,
        PositiveExponent,
        InverseExponent,
        PositiveFallingExponent,
        InverseFallingExponent,
        PositiveLogarithm,
        InverseLogarithm,
        PositiveFallingLogarithm,
        InverseFallingLogarithm,
        PositiveHalf,
        NegativeHalf,
        PositiveHalfWaveRectification,
        NegativeHalfWaveRectification,
        LorenzPulse,
        Multitone,
        RandomNoise,
        Electrocardiogram,
        TrapezoidalPulse,
        SincPulse,
        NarrowPulse,
        GaussWhiteNoise,
        AM,
        FM,
        LinearFM,
        ArbitraryWaveform1,
        ArbitraryWaveform2,
        ArbitraryWaveform64
    };


    public class Interface
    {
        int comPort;

        SerialPort serialPort;

        public Interface(int ComPort)
        {
            ComPort = ComPort;
        }


        // General / Setup
        public String GetSynchronisation()
        {
            Write("RSA");
            return Read();
        }
        public String GetBuzzerStatus()
        {
            Write("RBZ");
            return Read();
        }
        public String GetUplinkMode()
        {
            Write("RMS");
            return Read();
        }
        public String GetUplinkStatus()
        {
            Write("RUL");
            return Read();
        }
        public String GetLocalID()
        {
            Write("UID");
            return Read();
        }
        public String GetLocalModel()
        {
            Write("UMO");
            return Read();
        }

        // Output Commands
        public WaveForm GetWaveForm(int channel)
        {
            return (WaveForm)(int)GetOutput(channel, Output.WaveForm);
        }
        public void SetWaveForm(int channel, WaveForm waveForm)
        {
            SetOutput(channel, Output.WaveForm, String.Format("{0:D2}", (int)waveForm));
        }
        public double GetFrequency(int channel)
        {
            return GetOutput(channel, Output.Frequency);
        }
        public void SetFrequency(int channel, double frequency)
        {
            Int64 f = Convert.ToInt64(frequency * 1000000.0);
            SetOutput(channel, Output.Frequency, String.Format("{0:D14}", f));
        }
        public double GetAmplitude(int channel)
        {
            return GetOutput(channel, Output.Amplitude)/10000;
        }
        public void SetAmplitude(int channel, double amplitude)
        {
            SetOutput(channel, Output.Amplitude, String.Format("{0:F4}", amplitude));
        }
        public double GetOffset(int channel)
        {
            return GetOutput(channel, Output.Offset) / 1000;
        }
        public void SetOffset(int channel, double offset)
        {
            SetOutput(channel, Output.Offset, String.Format("{0:F3}", offset));
        }
        public double GetDutyCycle(int channel)
        {
            return GetOutput(channel, Output.Duty) / 1000;
        }
        public void SetDutyCycle(int channel, double duty)
        {
            SetOutput(channel, Output.Duty, String.Format("{0:F3}", duty));
        }
        public double GetPhase(int channel)
        {
            return GetOutput(channel, Output.Phase) / 1000;
        }
        public void SetPhase(int channel, double phase)
        {
            SetOutput(channel, Output.Phase, String.Format("{0:F3}", phase));
        }
        public bool Enabled(int channel)
        {
            return GetOutput(channel, Output.Status) == 255;
        }
        public void SetStatus(int channel, bool enabled)
        {
            int Enabled = enabled ? 1 : 0;
            SetOutput(channel, Output.Status, String.Format("{0:D1}", Enabled));
        }
        public double GetOutput(int channel, Output output)
        {
            if (channel < 1 || channel > 2) return 0;

            serialPort.Write("R");

            if (channel == 1)
                serialPort.Write("M");
            else
                serialPort.Write("F");

            switch (output)
            {
                case Output.WaveForm: serialPort.Write("W"); break;
                case Output.Frequency: serialPort.Write("F"); break;
                case Output.Amplitude: serialPort.Write("A"); break;
                case Output.Offset: serialPort.Write("O"); break;
                case Output.Duty: serialPort.Write("D"); break;
                case Output.Phase: serialPort.Write("P"); break;
                case Output.Status: serialPort.Write("N"); break;
                default: break;
            }
            serialPort.Write("\n");

            float value;
            String returnedString = Read();
            if (float.TryParse(returnedString, out value))
            {
                return value;
            }
            else
            {
                return 0;
            }
        }

        public void SetOutput(int channel, Output output, String value)
        {
            if (channel < 1 || channel > 2) return;

            serialPort.Write("W");

            if (channel == 1)
                serialPort.Write("M");
            else
                serialPort.Write("F");

             switch (output)
            {
                case Output.WaveForm: serialPort.Write("W"); break;
                case Output.Frequency: serialPort.Write("F"); break;
                case Output.Amplitude: serialPort.Write("A"); break;
                case Output.Offset: serialPort.Write("O"); break;
                case Output.Duty: serialPort.Write("D"); break;
                case Output.Phase: serialPort.Write("P"); break;
                case Output.Status: serialPort.Write("N"); break;
                default: break;
            }

            serialPort.Write(value);

            serialPort.Write("\n");

            Read();
        }


        // Frequency/Counting Measurements
        public float GetGateTime()
        {
            Write("RCG");
            return float.Parse(Read());
        }
        public void SetGateTime(GateTime gateTime)
        {
            Console.WriteLine(String.Format("WCG{0:D1}", (int)gateTime));
            Read();
        }
        public float GetFrequency()
        {
            Write("RCF");
            return float.Parse(Read());
        }
        public float GetCountingValue()
        {
            Write("RCC");
            return float.Parse(Read());
        }
        public float GetCountingPeriod()
        {
            Write("RCT");
            return float.Parse(Read());
        }
        public float GetPositivePulseWidth()
        {
            Write("RC+");
            return float.Parse(Read());
        }
        public float GetNegativePulseWidth()
        {
            Write("RC-");
            return float.Parse(Read());
        }
        public float GetDutyCycle()
        {
            Write("RCD");
            return float.Parse(Read());
        }
        public void SetCouplingMode(CouplingMode couplingMode)
        {
            serialPort.WriteLine(String.Format("WCC{0:D1}", (int)couplingMode));
            Read();
        }
        public void ResetCounter()
        {
            serialPort.WriteLine(String.Format("WCZ0"));
            Read();
        }
        public void PauseMeasurement()
        {
            serialPort.WriteLine(String.Format("WCP0"));
            Read();
        }


        // Sweep

        SweepObject currentSweepObject;
        public void SetSweepObject(SweepObject sweepObject)
        {
            currentSweepObject = sweepObject;
            serialPort.WriteLine(String.Format("SOB{0:D1}", (int)sweepObject));
            Read();
        }
        public void SetStartData(double start)
        {
            switch (currentSweepObject)
            {
                case SweepObject.Frequency: serialPort.WriteLine(String.Format("SST{0:F1}", start)); break;
                case SweepObject.Amplitude: serialPort.WriteLine(String.Format("SST{0:F3}", start)); break;
                case SweepObject.Offset: serialPort.WriteLine(String.Format("SST{0:F3}", start)); break;
                case SweepObject.DutyCycle: serialPort.WriteLine(String.Format("SST{0:F1}", start)); break;
                default: break;
            }
            Read();
        }
        public void SetEndData(double end)
        {
            switch (currentSweepObject)
            {
                case SweepObject.Frequency: serialPort.WriteLine(String.Format("SEN{0:F1}", end)); break;
                case SweepObject.Amplitude: serialPort.WriteLine(String.Format("SEN{0:F3}", end)); break;
                case SweepObject.Offset: serialPort.WriteLine(String.Format("SEN{0:F3}", end)); break;
                case SweepObject.DutyCycle: serialPort.WriteLine(String.Format("SEN{0:F1}", end)); break;
                default: break;
            }
            Read();
        }
        public void SetSweepTime(double sweepTime)
        {
            serialPort.WriteLine(String.Format("STI{0:F2}", sweepTime));
            Read();
        }
        public void SetSweepMode(SweepMode sweepMode)
        {
            serialPort.WriteLine(String.Format("SMO{0:D1}", (int)sweepMode));
            Read();
        }
        public void StartSweep()
        {
            serialPort.WriteLine("SBE1");
            Read();
        }
        public void StopSweep()
        {
            serialPort.WriteLine("SBE0");
            Read();
        }
        public void SetSweepControl(SweepControl sweepControl)
        {
            serialPort.WriteLine(String.Format("SXY{0:D1}", (int)sweepControl));
            Read();
        }



        // Triggers
        public float GetTriggerMode()
        {
            Write("RPM");
            return float.Parse(Read());
        }
        public float GetPulseAmount()
        {
            Write("RPN");
            return float.Parse(Read());
        }
        public String GetASKMode()
        {
            Write("RTA");
            return Read();
        }
        public String GetFSKMode()
        {
            Write("RTF");
            return Read();
        }
        public float GetFSKSecondaryFrequency()
        {
            Write("RFK");
            return float.Parse(Read());
        }
        public String GetPSKMode()
        {
            Write("RTP");
            return Read();
        }

        public void Write(String command)
        {
            serialPort.Write(command);
            serialPort.Write("\n");
        }

        public String Read()
        {
            serialPort.DiscardInBuffer();

            char r;
            StringBuilder sb = new StringBuilder();

            try
            {
                r = (char)serialPort.ReadChar();
                while (r != 0x0a)
                {
                    sb.Append(r);
                    r = (char)serialPort.ReadChar();
                }
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine("Timeout");
            }
            serialPort.DiscardInBuffer();
            return sb.ToString();
        }

        public bool OpenComport()
        {
            serialPort = new SerialPort();

            // Allow the user to set the appropriate properties.
            serialPort.PortName = "COM18";
            serialPort.BaudRate = 115200;
            serialPort.Parity = Parity.None;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Handshake = Handshake.None;

            // Set the read/write timeouts
            serialPort.ReadTimeout = 500;
            serialPort.WriteTimeout = 500;

            serialPort.Open();

            return true;
        }

        public void CloseComport()
        {
            serialPort.Close();
        }
    }
}
