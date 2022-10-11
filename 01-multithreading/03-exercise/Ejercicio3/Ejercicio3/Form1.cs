﻿using System;
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
            textBox1.Text = $"|{"PID",10} {"|",8} {"Name",10} {"|",8}{"Window Title",20} {"|",8}{Environment.NewLine}";
            textBox1.Text += "---------------------------------------------------------------------";

            foreach (Process process in processes)
            {
                textBox1.Text += $"{process.Id, 7}{Environment.NewLine}";
            }
        }
    }
}
