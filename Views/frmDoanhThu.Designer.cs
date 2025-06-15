namespace ShoeStore.Views
{
    partial class frmDoanhThu
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
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.loadlai = new System.Windows.Forms.Button();
			this.chi = new System.Windows.Forms.Label();
			this.thu = new System.Windows.Forms.Label();
			this.nam = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nam)).BeginInit();
			this.SuspendLayout();
			// 
			// chart1
			// 
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(12, 31);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Tổng doanh thu";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(1045, 389);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			this.chart1.Click += new System.EventHandler(this.chart1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(91, 444);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Tổng tiền nhập :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(642, 437);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Tổng thu nhập :";
			// 
			// loadlai
			// 
			this.loadlai.Location = new System.Drawing.Point(453, 476);
			this.loadlai.Name = "loadlai";
			this.loadlai.Size = new System.Drawing.Size(90, 27);
			this.loadlai.TabIndex = 5;
			this.loadlai.Text = "Load lại";
			this.loadlai.UseVisualStyleBackColor = true;
			// 
			// chi
			// 
			this.chi.AutoSize = true;
			this.chi.Location = new System.Drawing.Point(182, 444);
			this.chi.Name = "chi";
			this.chi.Size = new System.Drawing.Size(21, 13);
			this.chi.TabIndex = 6;
			this.chi.Text = "chi";
			// 
			// thu
			// 
			this.thu.AutoSize = true;
			this.thu.Location = new System.Drawing.Point(731, 437);
			this.thu.Name = "thu";
			this.thu.Size = new System.Drawing.Size(22, 13);
			this.thu.TabIndex = 7;
			this.thu.Text = "thu";
			// 
			// nam
			// 
			this.nam.Location = new System.Drawing.Point(509, 4);
			this.nam.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
			this.nam.Name = "nam";
			this.nam.Size = new System.Drawing.Size(71, 20);
			this.nam.TabIndex = 10;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(417, 6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(86, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Doanh thu năm :";
			// 
			// frmDoanhThu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1247, 526);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.nam);
			this.Controls.Add(this.thu);
			this.Controls.Add(this.chi);
			this.Controls.Add(this.loadlai);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.chart1);
			this.Name = "frmDoanhThu";
			this.Text = "  ";
			this.Load += new System.EventHandler(this.frmDoanhThu_Load);
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nam)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button loadlai;
		private System.Windows.Forms.Label chi;
		private System.Windows.Forms.Label thu;
		private System.Windows.Forms.NumericUpDown nam;
		private System.Windows.Forms.Label label3;
	}
}