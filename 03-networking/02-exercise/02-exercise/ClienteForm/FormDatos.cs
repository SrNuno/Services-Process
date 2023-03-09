using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteForm
{
    public partial class FormDatos : Form
    {
        
        public FormDatos()
        {
            InitializeComponent();
        }

        private void FormDatos_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            this.DialogResult= DialogResult.OK; 
            
        }


        private bool checkIp(String ipString)
        {
            int n;
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            for (int i = 0; i < splitValues.Length; i++)
            {
                if ((Int32.TryParse(splitValues[i], out n)))
                {
                    if (n < 0 || n > 255)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;

                }
            }

            return true;
        }

        private bool checkPuerto(String puerto)
        {
            int n;
            if(Int32.TryParse(puerto,out n))
            {
                if(!(n>0&& n < 65535))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (checkIp(txbIp.Text) && checkPuerto(txbPuerto.Text) && !String.IsNullOrEmpty(txbDNI.Text))
            {
                StreamWriter sw = null;
                try
                {
                    sw = new StreamWriter(Environment.GetEnvironmentVariable("HOMEPATH")+"/Documents/DatosClase.txt",false);
                    
                    sw.WriteLine(txbIp.Text+ ":" + txbPuerto.Text+":"+txbDNI.Text);
                    lblGuardar.Text = "Datos guardados";
                    sw.Close();
                }catch(Exception ex)
                {
                    lblGuardar.Text = "Hubo un error en el guardado de los datos";
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                lblGuardar.Text = "Hay datos erróneos";

            }
        }
    }
}
