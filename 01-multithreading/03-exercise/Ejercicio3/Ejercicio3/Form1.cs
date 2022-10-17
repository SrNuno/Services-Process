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

namespace Ejercicio3
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
            textBox1.Text += $"|{"PID",10}{"|",9}{"Name",16}{"|",15}{"Window Title",21}{"|",9}{Environment.NewLine}";
            textBox1.Text += $"|-------------------------------------------------------------------------------|{Environment.NewLine}";
            foreach (Process process in processes)
            {
                string nameProcess = cutString(process.ProcessName, 12);
                string windowTitle = cutString(process.MainWindowTitle, 10);

                textBox1.Text += $"|{process.Id,10}{"|",9}{nameProcess,20}{"|",11}{windowTitle,18}{"|",12}{Environment.NewLine}";
            }
            textBox1.Text += $"---------------------------------------------------------------------------------{Environment.NewLine}";
        }

        private string cutString(string value, int chars)
        {
            if (value.Length > chars)
            {
                return value.Substring(0, chars - 3) + "...";
            }
            return value;
        }
    }
}
