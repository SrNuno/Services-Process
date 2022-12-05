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
        Form2 form2 = new Form2();
        DirectoryInfo directory;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            form2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool valido = false;
            try
            {
                if (textBox1.Text.StartsWith("%") && textBox1.Text.EndsWith("%"))
                {
                    if (form2.comboBox1.SelectedItem.ToString() != "C:\\")
                    {
                        MessageBox.Show("El sistema no puede encontrar la ruta especificada.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (Environment.GetEnvironmentVariable(textBox1.Text.Remove(0, 1).Remove(textBox1.Text.Length - 2, 1)).StartsWith("C:\\"))
                        {
                            Directory.SetCurrentDirectory(Environment.GetEnvironmentVariable(textBox1.Text.Remove(0, 1).Remove(textBox1.Text.Length - 2, 1)));
                            valido = true;
                        }
                        else
                        {
                            Directory.SetCurrentDirectory(form2.comboBox1.SelectedItem.ToString() + Environment.GetEnvironmentVariable(textBox1.Text.Remove(0, 1).Remove(textBox1.Text.Length - 2, 1)));
                            valido = true;
                        }
                    }
                }
                else
                {
                    if (Directory.Exists(textBox1.Text))
                    {
                        Directory.SetCurrentDirectory(textBox1.Text);
                        valido = true;
                    }
                    else
                    {
                        MessageBox.Show("No existe el directorio", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Clear();
                        textBox1.Focus();
                        listBox1.Items.Clear();
                    }
                }

                directory = new DirectoryInfo(Directory.GetCurrentDirectory());
                if (valido)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("..");
                    foreach (DirectoryInfo directories in directory.GetDirectories())
                    {
                        listBox1.Items.Add(directories.Name);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Variable incorrecta", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() == "..")
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Directory.GetParent(Directory.GetCurrentDirectory());
            }
        }
    }
}
