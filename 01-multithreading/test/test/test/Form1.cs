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

namespace test
{
    public partial class Form1 : Form
    {
        Process[] processes;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            processes = Process.GetProcesses();
            textBox1.Text = $"PID{Environment.NewLine}";
            foreach (Process process in processes)
            {

                textBox1.Text += $"{process.Id}{process.ProcessName}{Environment.NewLine}";
            }
        }
    }
}
