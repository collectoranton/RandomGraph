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
            var min = int.Parse(textBox1.Text);
            var max = int.Parse(textBox1.Text);
            var iterations = int.Parse(textBox1.Text);

            var randomArray = GenerateRandomArray(min, max, iterations);
            var randomMean = new DataPoint[randomArray.Length];

            for (var i = 0; i < randomArray.Length; i++)
            {
                randomMean[i]  randomArray.Take(i + 1).Average();
            }

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
    }
}
