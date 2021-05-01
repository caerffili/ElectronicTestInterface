using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NationalInstruments.Visa;
namespace Visa
{
    public enum PointsMode
    {
        NORMAL,
        MAXIMUM,
        RAW
    }

    public enum VoltUnits
    {
        V = 1,
        mV = 1000,
        uV = 1000000
    }

    public enum TimeUnits
    {
        S = 1,
        mS = 1000,
        uS = 1000000,
        nS = 1000000000
    }

    public enum InternalState
    {
        unknow = 0,
        Aquired = 1,
        TriggerReady = 8192
    }

    public enum MemorySize
    {
        MS_7K,
        MS_70K,
        MS_700K,
        MS_7M,
        MS_14K,
        MS_140K,
        MS_1_4M,
        MS_14M
    }

    public enum TriggerSweep
    {
        AUTO,
        NORMAL,
        SINGLE
    }

    public enum TriggerStatus
    {
        RUN,
        STOP,
        TD,
        WAIT,
        AUTO
    }

    public class VISA_Osciloscope
    {
        static MessageBasedSession session;
        static ResourceManager resourceManager;

        public string _model;
        public string _serialNumber;
        public string _swVersion;
       // Channel[] channels;


        int channelQty;

        public VISA_Osciloscope()
        {
            resourceManager = new ResourceManager();

            String[] Resources = GetResources();
            String Resource = "";

            foreach (String resource in GetResources())
            {
                if (resource.StartsWith("USB"))
                {
                    Resource = resource;
                }
                Console.WriteLine(resource);
            }
            Console.WriteLine("Selected resource {0}", Resource);

            channelQty = 2;
            // _channels = new Channel[_numChannels];

            // Create Message based session, open first resource found
            session = (MessageBasedSession)resourceManager.Open(Resource);
            session.TimeoutMilliseconds = 1000 * 60 * 5;

            // Create channel object for every physical channel of oscilloscope
            for (uint i = 0; i < channelQty; i++)
            {
            //    channels[i] = new channels(i + 1, this);
            }

            Write("*IDN?");
            // Example response: Rigol Technologies,DS1102E,DS1EB1XXXXXXXX,00.02.06.00.01
            string[] fields = ReadString().Split(',');
            _model = fields[1];
            _serialNumber = fields[2];
            _swVersion = fields[3];

            Console.WriteLine("Device details: {0} {1} {2}", _model, _serialNumber, _swVersion);
        }

        public string[] GetResources()
        {
            string[] results = new string[] { };

            try
            {
                results = resourceManager.Find("?*").ToArray();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return results;
        }

        /*public void SetWaveformPointsMode(PointsMode value)
        {
            Write(":WAVeform:POINts:MODE " + value);
        }*/

        public void SetAcquireMemorySize(MemorySize memorySize)
        {
            Write(":MEMORY_SIZE " + memorySize);
            Console.WriteLine();
        }

        /*public void SetTriggerSweep(TriggerSweep memoryDepth)
        {
            Write(":TRIGger:EDGE:SWEep " + memoryDepth);
        }*/


        public void WaitTriggerReady()
        {
            /*  while (true)
             {
                  GetInternalState();
                  Thread.Sleep(50);
              }
            */
            while ((GetInternalState() & (int)InternalState.TriggerReady) == 1)
            {
                Thread.Sleep(50);
            }
        }

        public void WaitTriggerStop()
        {
          /*  while (true)
           {
                GetInternalState();
                Thread.Sleep(50);
            }
          */
            while ( (GetInternalState() & (int)InternalState.Aquired) == 0)
            {
                Thread.Sleep(50);
            }
        }

        public int GetInternalState()
        {
            Write(":INR?");
            String returnString = ReadString();
            Console.WriteLine(returnString);
           return int.Parse(returnString.Replace("INR", ""));
        }

        public void Close()
        {
            Write(":KEY:FORCE");
            Console.WriteLine();
        }

        public void Arm_Acquisition()
        {
            Write(":ARM_ACQUISITION");
            Console.WriteLine();
        }

        /*public void Wait()
        {
            Write(":WAIT");
        }*/

        /*public void Run()
        {
            Write(":RUN");
        }*/

        public void Stop()
        {
            Write(":STOP");
            Console.WriteLine();
        }

        public double GetTDiv()
        {
            Write(":TDIV?");
            String strval = ReadString();

            TimeUnits units = TimeUnits.S;
            int start = 5;
            int end = strval.Length - 1;

            if (strval.Substring(strval.Length - 1, 1).ToLower() == "s")
            {
                units = TimeUnits.S;
                end = strval.Length - 1;
            }
            if (strval.Substring(strval.Length - 2, 2).ToLower() == "ms")
            {
                units = TimeUnits.mS;
                end = strval.Length - 2;
            }
            if (strval.Substring(strval.Length - 2, 2).ToLower() == "us")
            {
                units = TimeUnits.uS;
                end = strval.Length - 2;
            }
            if (strval.Substring(strval.Length - 2, 2).ToLower() == "ns")
            {
                units = TimeUnits.nS;
                end = strval.Length - 2;
            }

            double TDiv = double.Parse(strval.Substring(start, end - start), System.Globalization.NumberStyles.Float) / (double)units;
            Console.WriteLine("TDiv {0:E}s", TDiv);
            return TDiv;
        }

        public double GetVDiv(int channel)
        {
            Write("C" + channel + ":VDIV?");
            String strval = ReadString();

            VoltUnits units = VoltUnits.V;
            int start = 8;
            int end = strval.Length - 1;

            if (strval.Substring(strval.Length - 1, 1).ToLower() == "v")
            {
                units = VoltUnits.V;
                end = strval.Length - 1;
            }
            if (strval.Substring(strval.Length - 2, 2).ToLower() == "mv")
            {
                units = VoltUnits.mV;
                end = strval.Length - 2;
            }
            if (strval.Substring(strval.Length - 2, 2).ToLower() == "uv")
            {
                units = VoltUnits.uV;
                end = strval.Length - 2;
            }

            double VDiv = double.Parse(strval.Substring(start, end - start), System.Globalization.NumberStyles.Float) / (double)units;
            Console.WriteLine("VDiv {0}v", VDiv);
            return VDiv;
        }

        public double GetVOffset(int channel)
        {
            Write("C" + channel + ":OFST?");
            String strval = ReadString();

            VoltUnits units = VoltUnits.V;
            int start = 8;
            int end = strval.Length - 1;

            if (strval.Substring(strval.Length - 1, 1).ToLower() == "v")
            {
                units = VoltUnits.V;
                end = strval.Length - 1;
            }
            if (strval.Substring(strval.Length - 2, 2).ToLower() == "mv")
            {
                units = VoltUnits.mV;
                end = strval.Length - 2;
            }
            if (strval.Substring(strval.Length - 2, 2).ToLower() == "uv")
            {
                units = VoltUnits.uV;
                end = strval.Length - 2;
            }

            double Offset = double.Parse(strval.Substring(start, end - start), System.Globalization.NumberStyles.Float) / (double)units;
            Console.WriteLine("Offset {0}v", Offset);
            return Offset;
        }

        public double GetSampleRate()
        {
            Write(":SAMPLE_RATE?");
            String strval = ReadString();
            double retval = double.Parse(strval.Replace("SARA", "").Replace("Sa/s", "").Replace("GSa/s", ""), System.Globalization.NumberStyles.Float);
            Console.WriteLine("Sample rate {0} Sa/s", retval);
            return retval;
        }

        /*public double GetTimebaseOffset()
        {
            // TODO: Delayed option
            Write(":TIMebase:OFFS?");
            String retval = ReadString();
            Console.WriteLine(retval);
            return 0;
        }*/

        /*public double GetAcquireSamplingRate(int channel)
        {
            if (channel > channelQty)
            {
                throw new ArgumentException("Wrong channel");
            }
            // TODO: Digital channel of DS1000D not supported			
            Write(":ACQuire:SAMPlingrate? CHANnel" + channel);
            return double.Parse(ReadString());
        }*/

        public String GetWaveform_Setup()
        {
            Write("WAVEFORM_SETUP?");
            byte[] response = Read();
            Console.WriteLine(Encoding.UTF8.GetString(response, 0, response.Length));
            return Encoding.UTF8.GetString(response, 0, response.Length);
        }

        public String GetTemplate()
        {
            Write("TEMPLATE?");
            byte[] response = Read();

            return Encoding.UTF8.GetString(response, 0, response.Length);
        }

        public WaveForm GetWaveform(int channel)
        {
            double VDiv = GetVDiv(channel);
            double VOffset = GetVOffset(channel);
            double sampleRate = GetSampleRate();

            Write("C" + channel + ":WAVEFORM? DAT2");
            byte[] response = Read();
        
            long sampleCount = response.Length - 22 - 2;
            Console.WriteLine("Samples received {0}.", sampleCount);

            double[] data = new double[sampleCount];
            double[] times = new double[sampleCount];

            double initial, interval;

            interval = 1.0 / sampleRate;

            for (int i = 0; i < sampleCount; i++)
            {
                // Strip off 10 byte header and loop through data and termination characters
                int rawData = (int)response[i + 22];
                if (rawData > 127) rawData -= 255;

                // Scale the vertical data from bytes to volts
                // A(V) = [(240 - <Raw_Byte>) * (<Volts_Div> / 25) - [(<Vert_Offset> + <Volts_Div> * 4.6)]]
                data[i] = rawData * VDiv / 4 - VOffset;

                times[i] = /*initial + */ interval * i;
            }
       
            return new WaveForm(times, data);
        }



        public string ReadString()
        {
            // Read the response; omit end-of-line characters.
             string retval = session.RawIO.ReadString().TrimEnd('\r', '\n');
            Console.Write(string.Format("Read {0} bytes from device [{1}]. ", retval.Length, retval));
            return retval;
        }

        public byte[] Read()
        {
            // Rigol DS1102E Long Memory can acquire 1M points (1048576 bytes + 10 bytes header)            
            var readBytes = session.RawIO.Read(1048586, out var status);
            Console.Write(string.Format("Read {0} bytes from device with Status {1}. ", readBytes.Length, status));
            return readBytes;
        }

        public void Write(string str)
        {
            Console.Write("Writing [{0}]. ", str);
            session.RawIO.Write(str);
            // Give time to process command
            Thread.Sleep(50);
            // TODO: Improve and validate
        }
    }
}
