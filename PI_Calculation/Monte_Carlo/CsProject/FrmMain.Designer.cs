namespace CsProject
{
    partial class FrmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.NudNomberOfSimulations = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnStartSimulation = new System.Windows.Forms.Button();
            this.ChartPi = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.LblNumDots = new System.Windows.Forms.Label();
            this.LblPi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NudNomberOfSimulations)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartPi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "시뮬레이션 횟수:";
            // 
            // NudNomberOfSimulations
            // 
            this.NudNomberOfSimulations.Location = new System.Drawing.Point(144, 24);
            this.NudNomberOfSimulations.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NudNomberOfSimulations.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NudNomberOfSimulations.Name = "NudNomberOfSimulations";
            this.NudNomberOfSimulations.Size = new System.Drawing.Size(120, 25);
            this.NudNomberOfSimulations.TabIndex = 1;
            this.NudNomberOfSimulations.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NudNomberOfSimulations.ValueChanged += new System.EventHandler(this.NudNomberOfSimulations_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnStartSimulation);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NudNomberOfSimulations);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 127);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // BtnStartSimulation
            // 
            this.BtnStartSimulation.Location = new System.Drawing.Point(19, 66);
            this.BtnStartSimulation.Name = "BtnStartSimulation";
            this.BtnStartSimulation.Size = new System.Drawing.Size(245, 43);
            this.BtnStartSimulation.TabIndex = 3;
            this.BtnStartSimulation.Text = "Start";
            this.BtnStartSimulation.UseVisualStyleBackColor = true;
            this.BtnStartSimulation.Click += new System.EventHandler(this.BtnStartSimulation_Click);
            // 
            // ChartPi
            // 
            chartArea4.Name = "ChartArea1";
            this.ChartPi.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.ChartPi.Legends.Add(legend4);
            this.ChartPi.Location = new System.Drawing.Point(319, 12);
            this.ChartPi.Name = "ChartPi";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series4.IsVisibleInLegend = false;
            series4.Legend = "Legend1";
            series4.Name = "SeriesPi";
            this.ChartPi.Series.Add(series4);
            this.ChartPi.Size = new System.Drawing.Size(420, 420);
            this.ChartPi.TabIndex = 3;
            // 
            // LblNumDots
            // 
            this.LblNumDots.Location = new System.Drawing.Point(28, 362);
            this.LblNumDots.Name = "LblNumDots";
            this.LblNumDots.Size = new System.Drawing.Size(248, 23);
            this.LblNumDots.TabIndex = 4;
            this.LblNumDots.Text = "Number of Dots: #";
            // 
            // LblPi
            // 
            this.LblPi.Location = new System.Drawing.Point(28, 387);
            this.LblPi.Name = "LblPi";
            this.LblPi.Size = new System.Drawing.Size(248, 23);
            this.LblPi.TabIndex = 5;
            this.LblPi.Text = "Pi: #";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 446);
            this.Controls.Add(this.LblPi);
            this.Controls.Add(this.LblNumDots);
            this.Controls.Add(this.ChartPi);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.Text = "PI by Monte Carlo Simulation";
            ((System.ComponentModel.ISupportInitialize)(this.NudNomberOfSimulations)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartPi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NudNomberOfSimulations;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnStartSimulation;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartPi;
        private System.Windows.Forms.Label LblNumDots;
        private System.Windows.Forms.Label LblPi;
    }
}

