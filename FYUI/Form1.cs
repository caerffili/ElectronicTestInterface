using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FY_AWG;

namespace FYUI
{
    public partial class Form1 : Form
    {
        Interface fy;

        bool Initialising;

        bool SweepStarted;

        public Form1()
        {
            InitializeComponent();

            Initialising = true;

            fy = new Interface(17);

            fy.OpenComport();

            checkBoxCh1Enabled.Checked = fy.Enabled(1);
            numericUpDownCh1Frequency.Value = (decimal)fy.GetFrequency(1);
            numericUpDownCh1Amplitude.Value = (decimal)fy.GetAmplitude(1);
            numericUpDownCh1Offset.Value = (decimal)fy.GetOffset(1);
            numericUpDownCh1DutyCycle.Value = (decimal)fy.GetDutyCycle(1);
            numericUpDownCh1Phase.Value = (decimal)fy.GetPhase(1);

            checkBoxCh2Enabled.Checked = fy.Enabled(2);
            numericUpDownCh2Frequency.Value = (decimal)fy.GetFrequency(2);
            numericUpDownCh2Amplitude.Value = (decimal)fy.GetAmplitude(2);
            numericUpDownCh2Offset.Value = (decimal)fy.GetOffset(2);
            numericUpDownCh2DutyCycle.Value = (decimal)fy.GetDutyCycle(2);
            numericUpDownCh2Phase.Value = (decimal)fy.GetPhase(2);

            SweepStarted = false;

            Initialising = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            fy.CloseComport();
        }


        private void checkBoxCh1Enabled_CheckedChanged(object sender, EventArgs e)
        {
            if (!Initialising)
            {
                if (checkBoxCh1Enabled.Checked)
                {
                    fy.SetStatus(1, true);
                }
                else
                {
                    fy.SetStatus(1, false);
                }
            }
        }

        private void numericUpDownCh1Frequency_ValueChanged(object sender, EventArgs e)
        {
            if (!Initialising)
            {
                fy.SetFrequency(1, (double)numericUpDownCh1Frequency.Value);
            }
        }

        private void numericUpDownCh1Amplitude_ValueChanged(object sender, EventArgs e)
        {
            if (!Initialising)
            {
                fy.SetAmplitude(1, (double)numericUpDownCh1Amplitude.Value);
            }
        }

        private void numericUpDownCh1Offset_ValueChanged(object sender, EventArgs e)
        {
            if (!Initialising)
            {
                fy.SetOffset(1, (double)numericUpDownCh1Offset.Value);
            }
        }

        private void numericUpDownCh1DutyCycle_ValueChanged(object sender, EventArgs e)
        {
            if (!Initialising)
            {
                fy.SetDutyCycle(1, (double)numericUpDownCh1DutyCycle.Value);
            }
        }

        private void numericUpDownCh1Phase_ValueChanged(object sender, EventArgs e)
        {
            if (!Initialising)
            {
                fy.SetPhase(1, (double)numericUpDownCh1Phase.Value);
            }
        }

        private void checkBoxCh2Enabled_CheckedChanged(object sender, EventArgs e)
        {
            if (!Initialising)
            {
                if (checkBoxCh2Enabled.Checked)
                {
                    fy.SetStatus(2, true);
                }
                else
                {
                    fy.SetStatus(2, false);
                }
            }
        }

        private void numericUpDownCh2Frequency_ValueChanged(object sender, EventArgs e)
        {
            if (!Initialising)
            {
                fy.SetFrequency(2, (double)numericUpDownCh2Frequency.Value);
            }
        }

        private void numericUpDownCh2Amplitude_ValueChanged(object sender, EventArgs e)
        {
            if (!Initialising)
            {
                fy.SetAmplitude(2, (double)numericUpDownCh2Amplitude.Value);
            }
        }

        private void numericUpDownCh2Offset_ValueChanged(object sender, EventArgs e)
        {
            if (!Initialising)
            {
                fy.SetOffset(2, (double)numericUpDownCh2Offset.Value);
            }
        }

        private void numericUpDownCh2DutyCycle_ValueChanged(object sender, EventArgs e)
        {
            if (!Initialising)
            {
                fy.SetDutyCycle(2, (double)numericUpDownCh2DutyCycle.Value);
            }
        }

        private void numericUpDownCh2Phase_ValueChanged(object sender, EventArgs e)
        {
            if (!Initialising)
            {
                fy.SetPhase(2, (double)numericUpDownCh2Phase.Value);
            }
        }

        private void numericUpDownSweepStart_ValueChanged(object sender, EventArgs e)
        {
            if (!Initialising)
            {
                fy.SetStartData((double)numericUpDownSweepStart.Value);
            }
        }

        private void numericUpDownSweepEnd_ValueChanged(object sender, EventArgs e)
        {
            if (!Initialising)
            {
                fy.SetEndData((double)numericUpDownSweepEnd.Value);
            }
        }

        private void numericUpDownSweepTime_ValueChanged(object sender, EventArgs e)
        {
            if (!Initialising)
            {
                fy.SetSweepTime((double)numericUpDownSweepTime.Value);
            }
        }

        private void comboBoxSweepObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Initialising)
            {
                switch (comboBoxSweepObject.SelectedItem)
                {
                    case "Frequency":
                        fy.SetSweepObject(SweepObject.Frequency); break;
                    case "Amplitude":
                        fy.SetSweepObject(SweepObject.Amplitude); break;
                    case "Offset":
                        fy.SetSweepObject(SweepObject.Offset); break;
                    case "DutyCycle":
                        fy.SetSweepObject(SweepObject.DutyCycle); break;
                    default: break;
                }
            }
        }

        private void comboBoxSweepMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Initialising)
            {
                switch (comboBoxSweepMode.SelectedItem)
                {
                    case "Linear":
                        fy.SetSweepMode(SweepMode.Linear); break;
                    case "Logarithmic":
                        fy.SetSweepMode(SweepMode.Logarithmic); break;
                    default: break;
                }
            }
        }

        private void comboBoxSweepDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Initialising)
            {
                switch (comboBoxSweepDirection.SelectedItem)
                {
                }
            }
        }

        private void comboBoxSweepControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Initialising)
            {
                switch (comboBoxSweepControl.SelectedItem)
                {
                    case "Time":
                        fy.SetSweepControl(SweepControl.Time); break;
                    case "VCO":
                        fy.SetSweepControl(SweepControl.VCO); break;
                    default: break;
                }
            }
        }

        private void buttonSweepStartStop_Click(object sender, EventArgs e)
        {
            if (!Initialising)
            {
                if (SweepStarted)
                {
                    SweepStarted = false;
                    buttonSweepStartStop.Text = " Start";
                    fy.StopSweep();
                }
                else
                {
                    SweepStarted = true;
                    buttonSweepStartStop.Text = " Stop";
                    fy.StartSweep();
                }
            }
        }
    }
}
