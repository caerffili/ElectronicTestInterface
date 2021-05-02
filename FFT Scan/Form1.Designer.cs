namespace FFT_Scan
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.textBoxStartFreq = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEndFreq = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelScopeSampleFrequency = new System.Windows.Forms.Label();
            this.labelCapturedSamples = new System.Windows.Forms.Label();
            this.labelFFTLength = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonTakeMeasurement = new System.Windows.Forms.Button();
            this.buttonScan = new System.Windows.Forms.Button();
            this.labelScanning = new System.Windows.Forms.Label();
            this.comboBoxSmoothing = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxStartFreq
            // 
            this.textBoxStartFreq.Location = new System.Drawing.Point(120, 12);
            this.textBoxStartFreq.Name = "textBoxStartFreq";
            this.textBoxStartFreq.Size = new System.Drawing.Size(100, 20);
            this.textBoxStartFreq.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start Frequency";
            // 
            // textBoxEndFreq
            // 
            this.textBoxEndFreq.Location = new System.Drawing.Point(339, 12);
            this.textBoxEndFreq.Name = "textBoxEndFreq";
            this.textBoxEndFreq.Size = new System.Drawing.Size(100, 20);
            this.textBoxEndFreq.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "End Frequency";
            // 
            // labelScopeSampleFrequency
            // 
            this.labelScopeSampleFrequency.AutoSize = true;
            this.labelScopeSampleFrequency.Location = new System.Drawing.Point(656, 18);
            this.labelScopeSampleFrequency.Name = "labelScopeSampleFrequency";
            this.labelScopeSampleFrequency.Size = new System.Drawing.Size(35, 13);
            this.labelScopeSampleFrequency.TabIndex = 4;
            this.labelScopeSampleFrequency.Text = "label3";
            // 
            // labelCapturedSamples
            // 
            this.labelCapturedSamples.AutoSize = true;
            this.labelCapturedSamples.Location = new System.Drawing.Point(656, 42);
            this.labelCapturedSamples.Name = "labelCapturedSamples";
            this.labelCapturedSamples.Size = new System.Drawing.Size(35, 13);
            this.labelCapturedSamples.TabIndex = 5;
            this.labelCapturedSamples.Text = "label3";
            // 
            // labelFFTLength
            // 
            this.labelFFTLength.AutoSize = true;
            this.labelFFTLength.Location = new System.Drawing.Point(656, 66);
            this.labelFFTLength.Name = "labelFFTLength";
            this.labelFFTLength.Size = new System.Drawing.Size(35, 13);
            this.labelFFTLength.TabIndex = 6;
            this.labelFFTLength.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(521, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Scope Sample Frequency";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(557, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Captured Samples";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(588, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "FFT Length";
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.Maximum = 100000D;
            chartArea1.AxisX.Minimum = 1D;
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorGrid.Interval = 1D;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX2.Minimum = 1D;
            chartArea1.AxisY.Interval = 10D;
            chartArea1.AxisY.Maximum = 20D;
            chartArea1.AxisY.Minimum = -150D;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 186);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "FFT";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "Smoothed FFT";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(858, 312);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            // 
            // buttonTakeMeasurement
            // 
            this.buttonTakeMeasurement.Location = new System.Drawing.Point(257, 87);
            this.buttonTakeMeasurement.Name = "buttonTakeMeasurement";
            this.buttonTakeMeasurement.Size = new System.Drawing.Size(75, 23);
            this.buttonTakeMeasurement.TabIndex = 11;
            this.buttonTakeMeasurement.Text = "button1";
            this.buttonTakeMeasurement.UseVisualStyleBackColor = true;
            this.buttonTakeMeasurement.Click += new System.EventHandler(this.buttonTakeMeasurement_Click);
            // 
            // buttonScan
            // 
            this.buttonScan.Location = new System.Drawing.Point(356, 86);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(75, 23);
            this.buttonScan.TabIndex = 12;
            this.buttonScan.Text = "button1";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // labelScanning
            // 
            this.labelScanning.AutoSize = true;
            this.labelScanning.Location = new System.Drawing.Point(560, 143);
            this.labelScanning.Name = "labelScanning";
            this.labelScanning.Size = new System.Drawing.Size(35, 13);
            this.labelScanning.TabIndex = 13;
            this.labelScanning.Text = "label6";
            // 
            // comboBoxSmoothing
            // 
            this.comboBoxSmoothing.FormattingEnabled = true;
            this.comboBoxSmoothing.Items.AddRange(new object[] {
            "Octave",
            "1/3 Octave",
            "1/6 Octave"});
            this.comboBoxSmoothing.Location = new System.Drawing.Point(61, 77);
            this.comboBoxSmoothing.Name = "comboBoxSmoothing";
            this.comboBoxSmoothing.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSmoothing.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 510);
            this.Controls.Add(this.comboBoxSmoothing);
            this.Controls.Add(this.labelScanning);
            this.Controls.Add(this.buttonScan);
            this.Controls.Add(this.buttonTakeMeasurement);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelFFTLength);
            this.Controls.Add(this.labelCapturedSamples);
            this.Controls.Add(this.labelScopeSampleFrequency);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxEndFreq);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxStartFreq);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxStartFreq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEndFreq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelScopeSampleFrequency;
        private System.Windows.Forms.Label labelCapturedSamples;
        private System.Windows.Forms.Label labelFFTLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button buttonTakeMeasurement;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.Label labelScanning;
        private System.Windows.Forms.ComboBox comboBoxSmoothing;
    }
}

