using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RandomGraph
{
    public partial class Form1 : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            var min = 0;
            var max = 0;
            var iterations = 0;

            try
            {
                min = int.Parse(textBox1.Text);
                max = int.Parse(textBox2.Text);
                iterations = int.Parse(textBox3.Text);

                var randomArray = GenerateRandomArray(min, max, iterations);
                var randomMean = new DataPoint[randomArray.Length];

                //chart1.ChartAreas["ChartArea1"].AxisX.IsLogarithmic = true;
                
                chart1.Series["Average"].Points.Clear();
                chart1.Series["Random"].Points.Clear();

                chart1.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
                chart1.ChartAreas["ChartArea1"].AxisX.Maximum = iterations;
                chart1.ChartAreas["ChartArea1"].AxisY.Minimum = min;
                chart1.ChartAreas["ChartArea1"].AxisY.Maximum = max;
                chart1.ChartAreas["ChartArea1"].AxisY.Interval = (double)(max - min) / 4;

                for (var i = 0; i < randomArray.Length; i++)
                {
                    chart1.Series["Average"].Points.AddXY(i + 1, randomArray.Take(i + 1).Average());
                    chart1.Series["Random"].Points.AddXY(i + 1, randomArray[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid input");
            }

            label4.Visible = false;
            chart1.ChartAreas["ChartArea1"].Visible = true;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private static int[] GenerateRandomArray(int min, int max, int iterations)
        {
            Random random = new Random();
            var randomIntArray = new int[iterations];

            for (var i = 0; i < iterations; i++) randomIntArray[i] = random.Next(min, max + 1);

            return randomIntArray;
        }

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void textBox2_GotFocus(object sender, EventArgs e)
        {
            textBox2.SelectAll();
        }

        private void textBox3_GotFocus(object sender, EventArgs e)
        {
            textBox3.SelectAll();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                Close();

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
