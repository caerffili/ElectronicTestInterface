namespace FYUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDownCh1Frequency = new System.Windows.Forms.NumericUpDown();
            this.checkBoxCh1Enabled = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownCh1Amplitude = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCh1Offset = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCh1DutyCycle = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCh1Phase = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDownCh2Frequency = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCh2Phase = new System.Windows.Forms.NumericUpDown();
            this.checkBoxCh2Enabled = new System.Windows.Forms.CheckBox();
            this.numericUpDownCh2DutyCycle = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownCh2Offset = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownCh2Amplitude = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDownSweepStart = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSweepEnd = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSweepTime = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxSweepObject = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBoxSweepMode = new System.Windows.Forms.ComboBox();
            this.comboBoxSweepDirection = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBoxSweepControl = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.buttonSweepStartStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh1Frequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh1Amplitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh1Offset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh1DutyCycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh1Phase)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh2Frequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh2Phase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh2DutyCycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh2Offset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh2Amplitude)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSweepStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSweepEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSweepTime)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownCh1Frequency
            // 
            this.numericUpDownCh1Frequency.DecimalPlaces = 6;
            this.numericUpDownCh1Frequency.Location = new System.Drawing.Point(102, 50);
            this.numericUpDownCh1Frequency.Maximum = new decimal(new int[] {
            60000000,
            0,
            0,
            0});
            this.numericUpDownCh1Frequency.Name = "numericUpDownCh1Frequency";
            this.numericUpDownCh1Frequency.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCh1Frequency.TabIndex = 2;
            this.numericUpDownCh1Frequency.ValueChanged += new System.EventHandler(this.numericUpDownCh1Frequency_ValueChanged);
            // 
            // checkBoxCh1Enabled
            // 
            this.checkBoxCh1Enabled.AutoSize = true;
            this.checkBoxCh1Enabled.Location = new System.Drawing.Point(102, 27);
            this.checkBoxCh1Enabled.Name = "checkBoxCh1Enabled";
            this.checkBoxCh1Enabled.Size = new System.Drawing.Size(65, 17);
            this.checkBoxCh1Enabled.TabIndex = 3;
            this.checkBoxCh1Enabled.Text = "Enabled";
            this.checkBoxCh1Enabled.UseVisualStyleBackColor = true;
            this.checkBoxCh1Enabled.CheckedChanged += new System.EventHandler(this.checkBoxCh1Enabled_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Frequency (Hz)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Amplitude";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Offset";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Duty";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Phase";
            // 
            // numericUpDownCh1Amplitude
            // 
            this.numericUpDownCh1Amplitude.DecimalPlaces = 4;
            this.numericUpDownCh1Amplitude.Location = new System.Drawing.Point(102, 76);
            this.numericUpDownCh1Amplitude.Name = "numericUpDownCh1Amplitude";
            this.numericUpDownCh1Amplitude.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCh1Amplitude.TabIndex = 9;
            this.numericUpDownCh1Amplitude.ValueChanged += new System.EventHandler(this.numericUpDownCh1Amplitude_ValueChanged);
            // 
            // numericUpDownCh1Offset
            // 
            this.numericUpDownCh1Offset.DecimalPlaces = 3;
            this.numericUpDownCh1Offset.Location = new System.Drawing.Point(102, 102);
            this.numericUpDownCh1Offset.Name = "numericUpDownCh1Offset";
            this.numericUpDownCh1Offset.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCh1Offset.TabIndex = 10;
            this.numericUpDownCh1Offset.ValueChanged += new System.EventHandler(this.numericUpDownCh1Offset_ValueChanged);
            // 
            // numericUpDownCh1DutyCycle
            // 
            this.numericUpDownCh1DutyCycle.DecimalPlaces = 3;
            this.numericUpDownCh1DutyCycle.Location = new System.Drawing.Point(102, 128);
            this.numericUpDownCh1DutyCycle.Name = "numericUpDownCh1DutyCycle";
            this.numericUpDownCh1DutyCycle.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCh1DutyCycle.TabIndex = 11;
            this.numericUpDownCh1DutyCycle.ValueChanged += new System.EventHandler(this.numericUpDownCh1DutyCycle_ValueChanged);
            // 
            // numericUpDownCh1Phase
            // 
            this.numericUpDownCh1Phase.DecimalPlaces = 3;
            this.numericUpDownCh1Phase.Location = new System.Drawing.Point(102, 154);
            this.numericUpDownCh1Phase.Maximum = new decimal(new int[] {
            359999,
            0,
            0,
            196608});
            this.numericUpDownCh1Phase.Name = "numericUpDownCh1Phase";
            this.numericUpDownCh1Phase.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCh1Phase.TabIndex = 12;
            this.numericUpDownCh1Phase.ValueChanged += new System.EventHandler(this.numericUpDownCh1Phase_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownCh1Frequency);
            this.groupBox1.Controls.Add(this.numericUpDownCh1Phase);
            this.groupBox1.Controls.Add(this.checkBoxCh1Enabled);
            this.groupBox1.Controls.Add(this.numericUpDownCh1DutyCycle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDownCh1Offset);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDownCh1Amplitude);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 188);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Channel 1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDownCh2Frequency);
            this.groupBox2.Controls.Add(this.numericUpDownCh2Phase);
            this.groupBox2.Controls.Add(this.checkBoxCh2Enabled);
            this.groupBox2.Controls.Add(this.numericUpDownCh2DutyCycle);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.numericUpDownCh2Offset);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.numericUpDownCh2Amplitude);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(266, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 188);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Channel 2";
            // 
            // numericUpDownCh2Frequency
            // 
            this.numericUpDownCh2Frequency.DecimalPlaces = 6;
            this.numericUpDownCh2Frequency.Location = new System.Drawing.Point(102, 50);
            this.numericUpDownCh2Frequency.Maximum = new decimal(new int[] {
            60000000,
            0,
            0,
            0});
            this.numericUpDownCh2Frequency.Name = "numericUpDownCh2Frequency";
            this.numericUpDownCh2Frequency.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCh2Frequency.TabIndex = 2;
            this.numericUpDownCh2Frequency.ValueChanged += new System.EventHandler(this.numericUpDownCh2Frequency_ValueChanged);
            // 
            // numericUpDownCh2Phase
            // 
            this.numericUpDownCh2Phase.DecimalPlaces = 3;
            this.numericUpDownCh2Phase.Location = new System.Drawing.Point(102, 154);
            this.numericUpDownCh2Phase.Maximum = new decimal(new int[] {
            359999,
            0,
            0,
            196608});
            this.numericUpDownCh2Phase.Name = "numericUpDownCh2Phase";
            this.numericUpDownCh2Phase.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCh2Phase.TabIndex = 12;
            this.numericUpDownCh2Phase.ValueChanged += new System.EventHandler(this.numericUpDownCh2Phase_ValueChanged);
            // 
            // checkBoxCh2Enabled
            // 
            this.checkBoxCh2Enabled.AutoSize = true;
            this.checkBoxCh2Enabled.Location = new System.Drawing.Point(102, 27);
            this.checkBoxCh2Enabled.Name = "checkBoxCh2Enabled";
            this.checkBoxCh2Enabled.Size = new System.Drawing.Size(65, 17);
            this.checkBoxCh2Enabled.TabIndex = 3;
            this.checkBoxCh2Enabled.Text = "Enabled";
            this.checkBoxCh2Enabled.UseVisualStyleBackColor = true;
            // 
            // numericUpDownCh2DutyCycle
            // 
            this.numericUpDownCh2DutyCycle.DecimalPlaces = 3;
            this.numericUpDownCh2DutyCycle.Location = new System.Drawing.Point(102, 128);
            this.numericUpDownCh2DutyCycle.Name = "numericUpDownCh2DutyCycle";
            this.numericUpDownCh2DutyCycle.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCh2DutyCycle.TabIndex = 11;
            this.numericUpDownCh2DutyCycle.ValueChanged += new System.EventHandler(this.numericUpDownCh2DutyCycle_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Frequency (Hz)";
            // 
            // numericUpDownCh2Offset
            // 
            this.numericUpDownCh2Offset.DecimalPlaces = 3;
            this.numericUpDownCh2Offset.Location = new System.Drawing.Point(102, 102);
            this.numericUpDownCh2Offset.Name = "numericUpDownCh2Offset";
            this.numericUpDownCh2Offset.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCh2Offset.TabIndex = 10;
            this.numericUpDownCh2Offset.ValueChanged += new System.EventHandler(this.numericUpDownCh2Offset_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Amplitude";
            // 
            // numericUpDownCh2Amplitude
            // 
            this.numericUpDownCh2Amplitude.DecimalPlaces = 4;
            this.numericUpDownCh2Amplitude.Location = new System.Drawing.Point(102, 76);
            this.numericUpDownCh2Amplitude.Name = "numericUpDownCh2Amplitude";
            this.numericUpDownCh2Amplitude.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCh2Amplitude.TabIndex = 9;
            this.numericUpDownCh2Amplitude.ValueChanged += new System.EventHandler(this.numericUpDownCh2Amplitude_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(61, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Offset";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(59, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Phase";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(67, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Duty";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonSweepStartStop);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.comboBoxSweepControl);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.comboBoxSweepDirection);
            this.groupBox3.Controls.Add(this.comboBoxSweepMode);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.comboBoxSweepObject);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.numericUpDownSweepTime);
            this.groupBox3.Controls.Add(this.numericUpDownSweepEnd);
            this.groupBox3.Controls.Add(this.numericUpDownSweepStart);
            this.groupBox3.Location = new System.Drawing.Point(547, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(241, 260);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sweep";
            // 
            // numericUpDownSweepStart
            // 
            this.numericUpDownSweepStart.DecimalPlaces = 1;
            this.numericUpDownSweepStart.Location = new System.Drawing.Point(85, 54);
            this.numericUpDownSweepStart.Maximum = new decimal(new int[] {
            60000000,
            0,
            0,
            0});
            this.numericUpDownSweepStart.Name = "numericUpDownSweepStart";
            this.numericUpDownSweepStart.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSweepStart.TabIndex = 0;
            this.numericUpDownSweepStart.ValueChanged += new System.EventHandler(this.numericUpDownSweepStart_ValueChanged);
            // 
            // numericUpDownSweepEnd
            // 
            this.numericUpDownSweepEnd.DecimalPlaces = 1;
            this.numericUpDownSweepEnd.Location = new System.Drawing.Point(84, 80);
            this.numericUpDownSweepEnd.Maximum = new decimal(new int[] {
            60000000,
            0,
            0,
            0});
            this.numericUpDownSweepEnd.Name = "numericUpDownSweepEnd";
            this.numericUpDownSweepEnd.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSweepEnd.TabIndex = 1;
            this.numericUpDownSweepEnd.ValueChanged += new System.EventHandler(this.numericUpDownSweepEnd_ValueChanged);
            // 
            // numericUpDownSweepTime
            // 
            this.numericUpDownSweepTime.DecimalPlaces = 2;
            this.numericUpDownSweepTime.Location = new System.Drawing.Point(84, 106);
            this.numericUpDownSweepTime.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            131072});
            this.numericUpDownSweepTime.Name = "numericUpDownSweepTime";
            this.numericUpDownSweepTime.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSweepTime.TabIndex = 2;
            this.numericUpDownSweepTime.ValueChanged += new System.EventHandler(this.numericUpDownSweepTime_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(48, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Time";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(50, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Start";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(52, 83);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "End";
            // 
            // comboBoxSweepObject
            // 
            this.comboBoxSweepObject.FormattingEnabled = true;
            this.comboBoxSweepObject.Items.AddRange(new object[] {
            "Frequency",
            "Amplitude",
            "Offset",
            "DutyCycle"});
            this.comboBoxSweepObject.Location = new System.Drawing.Point(84, 27);
            this.comboBoxSweepObject.Name = "comboBoxSweepObject";
            this.comboBoxSweepObject.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSweepObject.TabIndex = 6;
            this.comboBoxSweepObject.SelectedIndexChanged += new System.EventHandler(this.comboBoxSweepObject_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(40, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Object";
            // 
            // comboBoxSweepMode
            // 
            this.comboBoxSweepMode.FormattingEnabled = true;
            this.comboBoxSweepMode.Items.AddRange(new object[] {
            "Linear",
            "Logarithmic"});
            this.comboBoxSweepMode.Location = new System.Drawing.Point(84, 133);
            this.comboBoxSweepMode.Name = "comboBoxSweepMode";
            this.comboBoxSweepMode.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSweepMode.TabIndex = 8;
            this.comboBoxSweepMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxSweepMode_SelectedIndexChanged);
            // 
            // comboBoxSweepDirection
            // 
            this.comboBoxSweepDirection.Enabled = false;
            this.comboBoxSweepDirection.FormattingEnabled = true;
            this.comboBoxSweepDirection.Location = new System.Drawing.Point(83, 160);
            this.comboBoxSweepDirection.Name = "comboBoxSweepDirection";
            this.comboBoxSweepDirection.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSweepDirection.TabIndex = 9;
            this.comboBoxSweepDirection.SelectedIndexChanged += new System.EventHandler(this.comboBoxSweepDirection_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(44, 136);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "Mode";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Enabled = false;
            this.label15.Location = new System.Drawing.Point(28, 163);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 11;
            this.label15.Text = "Direction";
            // 
            // comboBoxSweepControl
            // 
            this.comboBoxSweepControl.FormattingEnabled = true;
            this.comboBoxSweepControl.Items.AddRange(new object[] {
            "Time",
            "VCO"});
            this.comboBoxSweepControl.Location = new System.Drawing.Point(83, 188);
            this.comboBoxSweepControl.Name = "comboBoxSweepControl";
            this.comboBoxSweepControl.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSweepControl.TabIndex = 12;
            this.comboBoxSweepControl.SelectedIndexChanged += new System.EventHandler(this.comboBoxSweepControl_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(37, 191);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "Control";
            // 
            // buttonSweepStartStop
            // 
            this.buttonSweepStartStop.Location = new System.Drawing.Point(83, 228);
            this.buttonSweepStartStop.Name = "buttonSweepStartStop";
            this.buttonSweepStartStop.Size = new System.Drawing.Size(75, 23);
            this.buttonSweepStartStop.TabIndex = 14;
            this.buttonSweepStartStop.Text = "Start";
            this.buttonSweepStartStop.UseVisualStyleBackColor = true;
            this.buttonSweepStartStop.Click += new System.EventHandler(this.buttonSweepStartStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh1Frequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh1Amplitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh1Offset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh1DutyCycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh1Phase)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh2Frequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh2Phase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh2DutyCycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh2Offset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh2Amplitude)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSweepStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSweepEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSweepTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownCh1Frequency;
        private System.Windows.Forms.CheckBox checkBoxCh1Enabled;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownCh1Amplitude;
        private System.Windows.Forms.NumericUpDown numericUpDownCh1Offset;
        private System.Windows.Forms.NumericUpDown numericUpDownCh1DutyCycle;
        private System.Windows.Forms.NumericUpDown numericUpDownCh1Phase;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDownCh2Frequency;
        private System.Windows.Forms.NumericUpDown numericUpDownCh2Phase;
        private System.Windows.Forms.CheckBox checkBoxCh2Enabled;
        private System.Windows.Forms.NumericUpDown numericUpDownCh2DutyCycle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownCh2Offset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownCh2Amplitude;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDownSweepTime;
        private System.Windows.Forms.NumericUpDown numericUpDownSweepEnd;
        private System.Windows.Forms.NumericUpDown numericUpDownSweepStart;
        private System.Windows.Forms.ComboBox comboBoxSweepObject;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBoxSweepDirection;
        private System.Windows.Forms.ComboBox comboBoxSweepMode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBoxSweepControl;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button buttonSweepStartStop;
    }
}

