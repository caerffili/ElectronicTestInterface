using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FY_AWG
{
    class Program
    {
        static void Main(string[] args)
        {
            Interface i = new Interface(17);

            i.OpenComport();

            try
            {
                Console.WriteLine(i.Enabled(1).ToString());
                Console.WriteLine(i.GetFrequency(1));
                i.GetOffset(2);
                //i.SetWaveForm(1, WaveForm.SquareWave);
                //i.SetWaveForm(1, WaveForm.PositiveHalf);
                i.SetFrequency(1, 204000);
                i.SetAmplitude(1, 1.1234);
                i.SetOffset(1, 1.123);
                i.SetDutyCycle(1, 13.123);
                i.SetPhase(1, 3.123);
                i.SetStatus(1, true);


               /* i.SetCouplingMode(CouplingMode.DC);
                i.SetCouplingMode(CouplingMode.AC);
                i.ResetCounter();
                i.PauseMeasurement();
                i.SetGateTime(GateTime.Gate1s);
                i.SetGateTime(GateTime.Gate10s);
                i.SetGateTime(GateTime.Gate100s);


                i.SetSweepObject(SweepObject.Amplitude);
                i.SetStartData(200);
                i.SetEndData(400);
                i.SetSweepTime(100);
                i.SetSweepMode(SweepMode.Linear);
                i.StartSweep();
                i.StopSweep();*/



                /*Console.WriteLine("Model {0}", i.GetLocalModel());
                Console.WriteLine("ID {0}", i.GetLocalID());
                Console.WriteLine("Synchronisation {0}", i.GetSynchronisation());
                Console.WriteLine("BuzzerStatus {0}", i.GetBuzzerStatus());
                Console.WriteLine("UplinkMode {0}", i.GetUplinkMode());
                Console.WriteLine("UplinkStatus {0}", i.GetUplinkStatus());

                Console.WriteLine("Wave Form 1 {0}", i.GetWaveForm(1));
                Console.WriteLine("Frequency 1 {0}", i.GetFrequency(1));
                Console.WriteLine("Amplitude 1 {0}", i.GetAmplitude(1));
                Console.WriteLine("Offset 1 {0}", i.GetOffset(1));
                Console.WriteLine("Duty 1 {0}", i.GetDutyCycle(1));
                Console.WriteLine("Phase 1 {0}", i.GetPhase(1));
                Console.WriteLine("Status 1 {0}", i.GetStatus(1));

                Console.WriteLine("Wave Form 2 {0}", i.GetWaveForm(2));
                Console.WriteLine("Frequency 2 {0}", i.GetFrequency(2));
                Console.WriteLine("Amplitude 2 {0}", i.GetAmplitude(2));
                Console.WriteLine("Offset 2 {0}", i.GetOffset(2));
                Console.WriteLine("Duty 2 {0}", i.GetDutyCycle(2));
                Console.WriteLine("Phase 2 {0}", i.GetPhase(2));
                Console.WriteLine("Status 2 {0}", i.GetStatus(2));
                */
                /*Console.WriteLine("GateTime {0}", i.GetGateTime());
                Console.WriteLine("Frequency {0}", i.GetFrequency());
                Console.WriteLine("CountingValue {0}", i.GetCountingValue());
                Console.WriteLine("CountingPeriod {0}", i.GetCountingPeriod());
                Console.WriteLine("PositivePulseWidth {0}", i.GetPositivePulseWidth());
                Console.WriteLine("NegativePulseWidth {0}", i.GetNegativePulseWidth());
                Console.WriteLine("DutyCycle {0}", i.GetDutyCycle());*/

                /*Console.WriteLine("GetTriggerMode {0}", i.GetTriggerMode());
                Console.WriteLine("GetPulseAmount {0}", i.GetPulseAmount());
                Console.WriteLine("GetASKMmode {0}", i.GetASKMode());
                Console.WriteLine("GetFSKMode {0}", i.GetFSKMode());
                Console.WriteLine("GetFSKSecondaryFrequency {0}", i.GetFSKSecondaryFrequency());
                Console.WriteLine("GetPSKMode {0}", i.GetPSKMode());*/



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                i.CloseComport();
            }

            Console.ReadKey();
        }
    }
}
