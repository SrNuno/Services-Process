using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Cliente()
        {
            InitializeComponent();
        }

        private void connection(string command)
        {
            const string IP_SERVER = "127.0.0.1";
            string msg;
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(IP_SERVER), 5005);
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
            DialogResult dr;
            dr = form.ShowDialog();
        }
    }
}
