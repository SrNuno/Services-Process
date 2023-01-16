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
            textBox1.Text = "";
            textBox2.Text = "";
            viewProcesses();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            processInfo();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            closeProcess();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            killProcess();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            runApp();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            startsWith();
        }
        /*---------------------------------------------------------*/
        private void viewProcesses()
        {
            processes = Process.GetProcesses();
            textBox1.Text += $"|{"PID",10}{"|",9}{"Name",16}{"|",15}{"Window Title",21}{"|",9}{Environment.NewLine}";
            Array.ForEach(processes, item =>
            {
                textBox1.Text += $"|{item.Id,10}{"|",9}{cutString(item.ProcessName, 12),18}{"|",13}{cutString(item.MainWindowTitle, 10),18}{"|",12}{Environment.NewLine}";
            });
        }
        private void processInfo()
        {
            int val = 0;
            ProcessThreadCollection threadCollection;
            ProcessModuleCollection moduleCollection;

            if (!Int32.TryParse(textBox2.Text, out val) || textBox2.Text.Equals(""))
            {
                DialogResult dialog = MessageBox.Show("PID invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                processes = Process.GetProcesses();
                foreach (Process p in processes)
                {
                    if (p.Id.ToString() == textBox2.Text)
                    {
                        textBox1.Text = $"Information:{Environment.NewLine}";
                        textBox1.Text += $"PID: {p.Id} - Name: {p.ProcessName}{Environment.NewLine}";
                        threadCollection = p.Threads;
                        textBox1.Text += $"\tSubprocess:{Environment.NewLine}";
                        foreach (ProcessThread processThread in threadCollection)
                        {
                            textBox1.Text += $"\t{processThread.Id} - {processThread.StartTime}{Environment.NewLine}";
                        }

                        moduleCollection = p.Modules;
                        textBox1.Text += $"\t\tModules:{Environment.NewLine}";
                        foreach (ProcessModule module in moduleCollection)
                        {
                            textBox1.Text += $"\t\t{module.ModuleName} - {cutString(module.FileName, 33)}{Environment.NewLine}";
                        }
                    }
                }
            }
        }
        private void closeProcess()
        {
            if (!Int32.TryParse(textBox2.Text, out val) || textBox2.Text.Equals(""))
            {
                DialogResult dialog = MessageBox.Show("PID invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                Array.ForEach(processes, item =>
                {
                    if (item.Id.ToString() == textBox2.Text)
                    {
                        item.CloseMainWindow();
                        DialogResult dialog = MessageBox.Show("Process close correctly", "Close", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        textBox2.Text = "";
                    }
                });
            }
        }
        private void killProcess()
        {
            if (!Int32.TryParse(textBox2.Text, out val) || textBox2.Text.Equals(""))
            {
                DialogResult dialog = MessageBox.Show("PID invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                Array.ForEach(processes, item =>
                {
                    if (item.Id.ToString() == textBox2.Text)
                    {
                        item.Kill();
                        DialogResult dialog = MessageBox.Show("Process kill correctly", "Close", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        textBox2.Text = "";
                    }
                });

            }
        }
        private void runApp()
        {
            Process p = new Process();
            p.StartInfo.FileName = textBox2.Text;
            p.Start();
        }
        private void startsWith()
        {
            if (textBox2.Text.Equals(""))
            {
                DialogResult dialog = MessageBox.Show("PID invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                Array.ForEach(processes, item =>
                {
                    if (item.ProcessName.StartsWith(textBox2.Text.ToString()))
                    {
                        textBox1.Text += item.ProcessName + " - " + item.Id + Environment.NewLine;
                    }
                });
            }
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
