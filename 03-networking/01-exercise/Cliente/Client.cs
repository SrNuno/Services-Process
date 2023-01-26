using System.Net;
using System.Net.Sockets;

namespace Cliente
{
    internal class Client
    {
        static void Main(string[] args)
        {
            const string IP_SERVER = "127.0.0.1";
            string msg;
            string userMsg;
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(IP_SERVER), 5005);
            Console.WriteLine("Starting client. Press a key to init connection");
            Socket server = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
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
                userMsg = Console.ReadLine();
                sw.WriteLine(userMsg);
                sw.Flush();
                msg = sr.ReadLine();
                Console.WriteLine(msg);
            }
            Console.WriteLine("Ending connection");
            server.Close();
            Console.ReadLine();
        }

    }
}