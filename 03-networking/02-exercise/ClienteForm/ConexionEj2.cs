using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClienteForm
{
    internal class ConexionEj2
    {
        private Socket conexion;
        private Form1 form;
        private string ipserver;
        private int port;


        public ConexionEj2(Form1 form)
        {
            this.form = form;
        }

        public bool Conectar()
        {
            ipserver = form.ip;
            port = form.puerto;

            string userMsg;
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(ipserver), port);

            Socket server = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
            conexion = server;
            try
            {
                server.Connect(ie);
                form.lblOutput.Text = "Conectado";
            }
            catch (SocketException e)
            {
                form.lblOutput.Text = "Error de conexión\nAsegúrese de que los datos sean válidos";
                return false;
            }
            return true;
        }

        public void Comando(String comando)
        {
            string msg;
            using (NetworkStream ns = new NetworkStream(conexion))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                sw.WriteLine("user " + form.DNI);
                sw.Flush();

                string aux = sr.ReadLine();
                if (aux == "OK")
                {
                    sw.WriteLine(comando);
                    sw.Flush();
                    aux = sr.ReadLine();


                    if (aux != "ERROR01")
                    {
                        if (aux.Contains("ERROR:"))
                        {
                            form.lblOutput.Text = "Usuario ya existe en la lista";
                        }
                        else
                        {
                            aux = sr.ReadToEnd();
                            form.lblOutput.Text = aux;
                        }
                    }
                    else
                    {
                        form.lblOutput.Text = "Comando inválido";
                    }
                }
                else
                {
                    form.lblOutput.Text = "Usuario inválido";
                }
                sw.Flush();
            }
            Console.WriteLine("Conexión cerrada");
            conexion.Close();
        }


    }
}
