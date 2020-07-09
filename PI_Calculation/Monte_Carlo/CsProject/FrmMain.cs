using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsProject
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            UserInit();
        }

        private void UserInit()
        {
            Globals.NumberOfSimulations = (int)NudNomberOfSimulations.Value;
            LblNumDots.Visible = false;
            LblPi.Visible = false;
        }

        private void NudNomberOfSimulations_ValueChanged(object sender, EventArgs e)
        {
            Globals.NumberOfSimulations = (int)NudNomberOfSimulations.Value;
        }

        private void BtnStartSimulation_Click(object sender, EventArgs e)
        {
            BtnStartSimulation.Enabled = false;

            ChartPi.ChartAreas.Clear();
            ChartPi.Series.Clear();

            // 차트 영역 설정
            ChartPi.ChartAreas.Add("Draw");
            ChartPi.ChartAreas["Draw"].AxisX.Minimum = -1.0;
            ChartPi.ChartAreas["Draw"].AxisX.Maximum = 1.0;
            ChartPi.ChartAreas["Draw"].AxisX.Interval = 0.5;
            ChartPi.ChartAreas["Draw"].AxisX.MajorGrid.LineColor = Color.LightGray;
            ChartPi.ChartAreas["Draw"].AxisY.Minimum = -1.0;
            ChartPi.ChartAreas["Draw"].AxisY.Maximum = 1.0;
            ChartPi.ChartAreas["Draw"].AxisY.Interval = 0.5;
            ChartPi.ChartAreas["Draw"].AxisY.MajorGrid.LineColor = Color.LightGray;

            // 원 그리기
            ChartPi.Series.Add("Circle");
            ChartPi.Series["Circle"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            ChartPi.Series["Circle"].MarkerSize = 1;
            ChartPi.Series["Circle"].Color = Color.Red;
            ChartPi.Series["Circle"].IsVisibleInLegend = false;
            for (double x = -1.0; x <= 1.0; x += 0.001)
            {
                double y = Math.Sqrt(1.0 - x * x);
                ChartPi.Series["Circle"].Points.AddXY(x, y);
                ChartPi.Series["Circle"].Points.AddXY(x, -y);
            }

            // XY Scatter
            ChartPi.Series.Add("Scatter");
            ChartPi.Series["Scatter"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            ChartPi.Series["Scatter"].MarkerSize = 1;
            ChartPi.Series["Scatter"].Color = Color.Blue;
            ChartPi.Series["Scatter"].IsVisibleInLegend = false;
            LblNumDots.Visible = true;
            LblPi.Visible = true;
            Random rnd = new Random();
            int countInCircle = 0;
            double Pi = 0.0;
            for (int i = 1; i <= Globals.NumberOfSimulations; i++)
            {
                double x = Globals.GenerateRandomDouble(-1.0, 1.0);
                double y = Globals.GenerateRandomDouble(-1.0, 1.0);
                ChartPi.Series["Scatter"].Points.AddXY(x, y);
                if (x * x + y * y <= 1.0)
                {
                    countInCircle++;
                    Pi = 4.0 * (double)countInCircle / i;
                }
                LblNumDots.Text = $"Number of Dots: {i}";
                LblPi.Text = $"PI: {Pi}";
                if (rnd.Next(0, 1001) == 0)
                {
                    //LblNumDots.Refresh();
                    //ChartPi.Update();
                    Application.DoEvents();
                }
            }

            BtnStartSimulation.Enabled = true;
        }
    }
}
