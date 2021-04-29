using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visa
{
    class Program
    {
        static void Main(string[] args)
        {
            VISA_Osciloscope osciloscope = new VISA_Osciloscope();
            //osciloscope.Stop();
            Console.WriteLine(osciloscope.GetWaveform_Setup()); 
            Console.WriteLine(osciloscope.GetTemplate());
            osciloscope.Arm_Acquisition();
;
            osciloscope.SetWaveformPointsMode(PointsMode.MAXIMUM);
            osciloscope.SetAcquireMemoryDepth(AcquireMemoryDepth.LONG);
            osciloscope.SetTriggerSweep(TriggerSweep.SINGLE);
            //osciloscope.WaitTriggerStop();
            osciloscope.Wait();
            //osciloscope.Stop();

            var wave = osciloscope.GetWaveform(1);
            wave.SaveCSV("test.csv");
            osciloscope.Close();
        }
    }
}
