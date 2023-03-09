using System;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace ClienteForm
{

    public partial class Form1 : Form
    {
        public string ip = "192.168.20.100";
        public int puerto = 1516;
        public string DNI = "53817232s";

        private ConexionEj2 cnx;
        public Form1()
        {
            InitializeComponent();
            cnx = new ConexionEj2(this);
            LeerDatos();

        }

        private void BtnComando(object sender, EventArgs e)
        {
            string comando = ((Button)sender).Text;
            if (cnx.Conectar())
            {
                cnx.Comando(comando);
            }
        }

        private void LeerDatos()
        {
            StreamReader sr = null;
            try
            {
                string direccion = Environment.GetEnvironmentVariable("USERPROFILE") + "\\config.ini";

                if (!File.Exists(direccion))
                {
                    File.WriteAllText(direccion, ip + ":" + puerto + ":" + DNI);
                }
                
                sr = new StreamReader(direccion);
                string content;
                if ((content = sr.ReadLine()) != null)
                {
                    string[] aux = content.Split(":");
                    if (aux.Length > 2)
                    {
                        this.ip = aux[0];
                        lblIp.Text = "IP: " + this.ip;
                        if (Int32.TryParse(aux[1], out puerto))
                        {

                        }
                        lblPuerto.Text = "Puerto: " + this.puerto;
                        this.DNI = aux[2];
                        lblDNI.Text = "DNI: " + DNI;
                    }
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        private void btnDatos_Click(object sender, EventArgs e)
        {
            FormDatos frmDatos = new FormDatos();
            frmDatos.ShowDialog();
            if (frmDatos.DialogResult == DialogResult.OK)
            {
                LeerDatos();
            }
        }
    }
}