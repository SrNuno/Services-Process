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
    public partial class Form1 : Form
    {
        private string USER = "6";
        private string IP_SERVER = "192.168.20.100";
        private int PORT = 5001;
        private bool flag = false;
        private Socket serverSocket;
        private string function;
        private void ConnectionServer(string command)
        {
            IPEndPoint ipEP = new IPEndPoint(IPAddress.Parse(IP_SERVER), PORT);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                serverSocket.Connect(ipEP);
                flag = true;
            }
            catch (SocketException)
            {
                MessageBox.Show("No connected with server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (NetworkStream ns = new NetworkStream(serverSocket))
                using (StreamReader sr = new StreamReader(ns))
                using (StreamWriter sw = new StreamWriter(ns))
                {
                    if (flag)
                    {
                        lblConnect.ForeColor = Color.Green;
                        lblUser.Text = "User: " + USER;
                        lblIP.Text = "IP: " + IP_SERVER;
                        lblPort.Text = "Port: " + PORT.ToString();
                    }

                    sw.WriteLine(command);
                    sw.Flush();
                    try
                    {
                        if (sr.ReadLine() == "OK")
                        {
                            
                        }
                    }
                    catch (IOException IOe)
                    {
                        Debug.WriteLine(IOe.ToString());
                    }
                }
            }
            catch (IOException)
            {
                Debug.WriteLine("Server no connected");
            }

            serverSocket.Close();
        }

        private void SendCommand(object sender, EventArgs e)
        {
            string command = (sender as Button).Text;

            
            ConnectionServer(command);
        }

        public Form1()
        {
            InitializeComponent();
        }

    }
}
