using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        DirectoryInfo directory;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.StartsWith("%") && textBox1.Text.EndsWith("%"))
                {
                    Directory.SetCurrentDirectory(Environment.GetEnvironmentVariable(textBox1.Text.Remove(0, 1).Remove(textBox1.Text.Length - 2, 1)));
                }
                else
                {
                    if (Directory.Exists(textBox1.Text))
                    {
                        Directory.SetCurrentDirectory(textBox1.Text);
                    }
                    else
                    {
                        MessageBox.Show("Path invalid", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Variable invalid", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            listBox1.Items.Clear();
            listBox1.Items.Add("..");
            foreach (DirectoryInfo directories in directory.GetDirectories())
            {
                listBox1.Items.Add(directories.Name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
