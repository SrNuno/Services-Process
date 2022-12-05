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
    public partial class Form2 : Form
    {
        DriveInfo[] unidades;
        public Form2()
        {
            InitializeComponent();
            unidades = DriveInfo.GetDrives();
            foreach (DriveInfo item in unidades)
            {
                comboBox1.Items.Add(item.Name);
            }
            comboBox1.SelectedIndex= 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
