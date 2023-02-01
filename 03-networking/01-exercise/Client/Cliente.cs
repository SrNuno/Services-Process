using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Cliente : Form
    {
        string ip = "127.0.0.1";
        int port = 5005;
        IPEndPoint ipep;
        string path = Environment.GetEnvironmentVariable("HOMEPATH") + "\\config.ini";

        public Cliente()
        {
            InitializeComponent();
        }

        private void connection(string command)
        {
            string msg = "";
            ipep = new IPEndPoint(IPAddress.Parse(ip), port);
            Socket socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socketServer.Connect(ipep);
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
            }

            using (NetworkStream ns = new NetworkStream(socketServer))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                msg = sr.ReadLine();
                this.Text = msg;
                sw.WriteLine(command);
                sw.Flush();
                txtResults.Text = sr.ReadLine();
            }
            socketServer.Close();
        }

        private void time_Click(object sender, EventArgs e)
        {
            connection("time");
        }

        private void date_Click(object sender, EventArgs e)
        {
            connection("date");
        }

        private void all_Click(object sender, EventArgs e)
        {
            connection("all");
        }

        private void close_Click(object sender, EventArgs e)
        {
            connection("close " + pwd.Text.ToString().Trim());
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IP_Port form = new IP_Port();
            DialogResult res;
            res = form.ShowDialog();
            StreamWriter sw;
            bool portValid = false;

            switch (res)
            {
                case DialogResult.OK:
                    if (Int32.Parse(form.textPort.Text) >= 0 && Int32.Parse(form.textPort.Text) <= 65535)
                    {
                        sw = new StreamWriter(path);
                        sw.WriteLine(IPAddress.Parse(form.textIP.Text) + ":" + Int32.Parse(form.textPort.Text));
                        sw.Close();
                    }
                    else
                    {
                        Debug.WriteLine("Port invalid");
                    }

                    string line;
                    StreamReader sr;
                    sr = new StreamReader(path);
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        ip = line.Split(':')[0];
                        port = Int32.Parse(line.Split(':')[1]);
                        line= sr.ReadLine();
                    }
                    sr.Close();
                    break;
            }
        }
    }
}
