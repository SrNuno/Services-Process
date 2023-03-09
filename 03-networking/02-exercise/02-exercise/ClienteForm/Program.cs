using System.Net.Sockets;
using System.Net;

namespace ClienteForm
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        public static void connection()
        {
            const string IP_SERVER = "192.168.20.100";
            string msg;
            string userMsg;

            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(IP_SERVER), 1516);
            Console.WriteLine("Starting client. Press a key to init connection");

            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ie);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Error connection: {0}\nError code: {1}({2})",
                e.Message, (SocketError)e.ErrorCode, e.ErrorCode);
                Console.ReadKey();
                return;
            }

            using (NetworkStream ns = new NetworkStream(server))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                msg = sr.ReadLine();
                Console.WriteLine(msg);
                while (true)
                {
                    userMsg = Console.ReadLine();
                    sw.WriteLine(userMsg);
                    sw.Flush();
                    msg = sr.ReadLine();
                    Console.WriteLine(msg);
                }
            }
            Console.WriteLine("Ending connection");
            server.Close();
        }
    }
}