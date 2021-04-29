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

    public enum AcquireMemoryDepth
    {
        NORMAL,
        LONG
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

        static string _model;
        static string _serialNumber;
        static string _swVersion;
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

        public void SetWaveformPointsMode(PointsMode value)
        {
            Write(":WAVeform:POINts:MODE " + value);
        }

        public void SetAcquireMemoryDepth(AcquireMemoryDepth memoryDepth)
        {
            Write(":ACQuire:MEMDepth " + memoryDepth);
        }

        public void SetTriggerSweep(TriggerSweep memoryDepth)
        {
            Write(":TRIGger:EDGE:SWEep " + memoryDepth);
        }

        public void WaitTriggerStop()
        {
            while (GetTriggerStatus() != TriggerStatus.STOP)
            {
                Thread.Sleep(50);
            }
        }

        public TriggerStatus GetTriggerStatus()
        {
            Write(":TRIGger:STATus?");
            String returnString = ReadString();

            if (returnString == "T'D") return TriggerStatus.TD;

            return (TriggerStatus)Enum.Parse(typeof(TriggerStatus), returnString);
        }

        public void Close()
        {
            Write(":KEY:FORCE");
        }

        public void Arm_Acquisition()
        {
            Write(":ARM_ACQUISITION");
        }
        public void Wait()
        {
            Write(":WAIT");
        }

        public void Run()
        {
            Write(":RUN");
        }

        public void Stop()
        {
            Write(":STOP");
        }

        public double GetScale(int channel)
        {
            Write(":CHAN" + channel + ":SCAL?");
            return double.Parse(ReadString());
        }

        public double GetOffset(int channel)
        {
            Write(":CHAN" + channel + ":OFFS?");
            return double.Parse(ReadString());
        }

        public double GetTimebaseScale()
        {
            // TODO: Delayed option
            Write(":TIMebase:SCALe?");
            return double.Parse(ReadString());
        }

        public double GetTimebaseOffset()
        {
            // TODO: Delayed option
            Write(":TIMebase:OFFS?");
            return double.Parse(ReadString());
        }

        public double GetAcquireSamplingRate(int channel)
        {
            if (channel > channelQty)
            {
                throw new ArgumentException("Wrong channel");
            }
            // TODO: Digital channel of DS1000D not supported			
            Write(":ACQuire:SAMPlingrate? CHANnel" + channel);
            return double.Parse(ReadString());
        }

        public String GetWaveform_Setup()
        {
            Write("WAVEFORM_SETUP?");
            byte[] response = Read();

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
        
            //Write(":WAVEFORM:DATA? CHAN" + channel);
            Write("C1:WAVEFORM? DAT2");
            byte[] response = Read();

           Console.WriteLine(Encoding.UTF8.GetString(response, 0, response.Length));

            long pointsCount = response.Length - 10;

            double[] data = new double[pointsCount];
            double[] times = new double[pointsCount];

            double scale = GetScale(channel);
            double offset = GetOffset(channel);
            double oscTimeScale = GetTimebaseScale();
            double oscTimeOffset = GetTimebaseOffset();
            double sampleRate = GetAcquireSamplingRate(channel);

            double initial, interval;

            // 600 points
            //T(s) = (<Pt_Num> - 1) * (<Time_Div> / 50) - [(<Time_Div> * 6) - <Time_Offset>]      
            // > 600 points
            //T(s) = <Time_Offset> -[ (<Points> - 10) / (1 / (2*<Samp_Rate>)]

            if (pointsCount > 600)
            {
                initial = -((1.0 / sampleRate) * (pointsCount / 2)) + oscTimeOffset;
                interval = 1.0 / sampleRate;
            }
            else
            {
                initial = -(oscTimeScale * 6) - oscTimeOffset;
                interval = oscTimeScale / 50;
            }

            for (int i = 0; i < pointsCount; i++)
            {
                // Strip off 10 byte header and loop through data and termination characters
                int rawData = (int)response[i + 10];

                // Scale the vertical data from bytes to volts
                // A(V) = [(240 - <Raw_Byte>) * (<Volts_Div> / 25) - [(<Vert_Offset> + <Volts_Div> * 4.6)]]
                data[i] = ((240 - rawData) * scale / 25) - (offset + (scale * 4.6));
                times[i] = initial + interval * i;
            }

            return new WaveForm(times, data);
        }



        public string ReadString()
        {
            // Read the response; omit end-of-line characters.
            return session.RawIO.ReadString().TrimEnd('\r', '\n');
        }

        public byte[] Read()
        {
            // Rigol DS1102E Long Memory can acquire 1M points (1048576 bytes + 10 bytes header)            
            var readBytes = session.RawIO.Read(1048586, out var status);
            Console.WriteLine(string.Format("Readed {0} bytes from device with Status {1}", readBytes.Length, status));
            return readBytes;
        }

        public void Write(string str)
        {
            session.RawIO.Write(str);
            // Give time to process command
            Thread.Sleep(50);
            // TODO: Improve and validate
        }
    }
}
