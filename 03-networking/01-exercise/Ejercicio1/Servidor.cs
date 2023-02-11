using System.Net;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;

namespace Ejercicio1
{
    internal class Servidor
    {
        public static bool close = false;
        public static Socket s;
        static void Main(string[] args)
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, 5005);
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Bind(ie);
            s.Listen(10);
            Console.WriteLine($"Server waiting at port {ie.Port}");
            try
            {
                while (!close)
                {
                    Socket client = s.Accept();
                    Thread thread = new Thread(threadClient);
                    thread.Start(client);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.StackTrace.ToString());
            }
        }

        static void threadClient(object socket)
        {
            string message;
            Socket client = (Socket)socket;
            IPEndPoint ieClient = (IPEndPoint)client.RemoteEndPoint;
            Console.WriteLine($"Connected with client {ieClient.Address} at port {ieClient.Port}");
            using (NetworkStream ns = new NetworkStream(client))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                sw.WriteLine("Welcome to Nuno Server");
                sw.Flush();

                try
                {
                    message = sr.ReadLine();
                    string[] text = message.Split(" ");
                    switch (text[0])
                    {
                        case "time":
                            sw.WriteLine(DateTime.Now.ToString("H:mm"));
                            break;

                        case "date":
                            sw.WriteLine(DateTime.UtcNow.ToString("dd-MM-yyyy"));

                            break;

                        case "all":
                            sw.WriteLine(DateTime.Now);
                            break;

                        case "close":
                            StreamReader reader = null;
                            try
                            {
                                reader = new StreamReader(Environment.GetEnvironmentVariable("PROGRAMDATA") + "\\password.txt");
                            }
                            catch (FileNotFoundException e)
                            {
                                Console.WriteLine(e.Message);
                            }

                            if (text.Length > 1 && text[1] == reader.ReadLine())
                            {
                                sw.WriteLine("Close operation");
                                close = true;
                                s.Close();
                            }
                            else
                            {
                                sw.WriteLine("Password invalid");
                            }
                            reader.Close();
                            break;

                        default:
                            sw.WriteLine("Command invalid");
                            break;
                    }
                }
                catch (IOException e)
                {
                    sw.WriteLine(e.Message);
                }
                sw.Flush();
                Console.WriteLine("Finish connection");
                client.Close();
            }
        }
    }
}