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
    public partial class Client : Form
    {
        private string IP_SERVER = "127.0.0.1";
        private int PORT = 5005;
        private Socket serverSocket;

        private void ConnectionServer(string command)
        {
            IPEndPoint ipEP = new IPEndPoint(IPAddress.Parse(IP_SERVER), PORT);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                serverSocket.Connect(ipEP);
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
                    this.Text = sr.ReadLine();
                    sw.WriteLine(command);
                    sw.Flush();
                    try
                    {
                        txtResult.Text = "Result: " + sr.ReadLine();
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
            string command = (sender as Button).Text.ToLower();
            command = command == "close" ? $"{command} {textBox1.Text}" : command;
            ConnectionServer(command);
        }

        public Client()
        {
            InitializeComponent();
        }

        private void Config_Click(object sender, EventArgs e)
        {
            Configuration config = new Configuration(IP_SERVER, PORT);
            if (config.ShowDialog() == DialogResult.Yes)
            {
                IP_SERVER = config.IP_SERVER;
                PORT = config.PORT;
            }
        }

    }
}
