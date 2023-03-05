using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    internal class Program
    {
        private const int PORT = 5005;
        private static IPEndPoint ipEP;
        private static Socket socketServer;
        private static Socket socketClient;

        private static void Server()
        {
            ipEP = new IPEndPoint(IPAddress.Any, PORT);
            Console.WriteLine("Start server");

            using (socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    socketServer.Bind(ipEP);
                    Console.WriteLine("Bind established");
                }
                catch (SocketException s)
                {
                    Console.WriteLine($"Port {ipEP.Port} in use!");
                    try
                    {
                        ipEP.Port++;
                        socketServer.Bind(ipEP);
                    }
                    catch (SocketException se)
                    {
                        Console.WriteLine($"Port {ipEP.Port} in use!");
                        return;
                    }
                }
                socketServer.Listen(10);
                Connection();
            }
            socketServer.Close();
        }

        private static void Connection()
        {
            string command;
            bool isAlive = true;
            Console.WriteLine("Waiting for connection");

            while (isAlive)
            {
                using (socketClient = socketServer.Accept())
                using (NetworkStream ns = new NetworkStream(socketClient))
                using (StreamReader sr = new StreamReader(ns))
                using (StreamWriter sw = new StreamWriter(ns))
                {
                    Console.WriteLine($"New connection - {DateTime.UtcNow}");
                    sw.WriteLine("Connected");
                    sw.Flush();
                    try
                    {
                        command = sr.ReadLine();
                        if (string.IsNullOrEmpty(command))
                        {
                            Console.WriteLine("Command invalid");
                        }
                        else
                        {
                            string[] text = command.Split(" ");
                            switch (text[0].Trim())
                            {
                                case "time":
                                    sw.WriteLine(DateTime.UtcNow.ToString("H:mm"));
                                    break;

                                case "date":
                                    sw.WriteLine(DateTime.UtcNow.ToString("dd-MM-yyyy"));
                                    break;

                                case "all":
                                    sw.WriteLine(DateTime.Now);
                                    break;

                                case "close":
                                    StreamReader srPath = null;
                                    try
                                    {
                                        srPath = new StreamReader(Environment.GetEnvironmentVariable("PROGRAMDATA") + "\\password.txt");
                                    }
                                    catch (FileNotFoundException fnfe)
                                    {
                                        Debug.Write(fnfe.Message);
                                    }

                                    if (text.Length > 1 && text[1] == sr.ReadLine())
                                    {
                                        sw.WriteLine("Close operation");
                                        isAlive = false;
                                        socketServer.Close();
                                    }
                                    else
                                    {
                                        sw.WriteLine("Password invalid");
                                    }
                                    srPath.Close();
                                    break;

                                default:
                                    sw.WriteLine("Command invalid");
                                    break;
                            }
                        }
                    }
                    catch (IOException ioe)
                    {
                        Console.WriteLine(ioe.Message);
                    }
                    sw.Flush();
                    Console.WriteLine("Finish connection");
                    socketClient.Close();
                }
            }
        }

        public static void Main(string[] args)
        {
            Server();
        }
    }
}