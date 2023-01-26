using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Ejercicio1
{
    internal class Servidor
    {
        static void Main(string[] args)
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, 5005);
            using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
            ProtocolType.Tcp))
            {
                s.Bind(ie);
                s.Listen(10);
                Console.WriteLine($"Server listening at port:{ie.Port}");
                Socket sClient = s.Accept();
                IPEndPoint ieClient = (IPEndPoint)sClient.RemoteEndPoint;
                Console.WriteLine("Client connected:{0} at port {1}", ieClient.Address,
               ieClient.Port);
                using (NetworkStream ns = new NetworkStream(sClient))
                using (StreamReader sr = new StreamReader(ns))
                using (StreamWriter sw = new StreamWriter(ns))
                {
                    string welcome = "Welcome to Nuno Server";
                    sw.WriteLine(welcome);
                    sw.Flush();
                    string msg = sr.ReadLine();
                    while (msg != null)
                    {
                        try
                        {
                            string[] text = msg.Split(" ");
                            switch (text[0])
                            {
                                case "time":
                                    sw.WriteLine(DateTime.Now.ToString("h:mm"));
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
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }

                                    if (text.Length > 1 && text[1] == reader.ReadLine())
                                    {
                                        sw.WriteLine("Close operation");
                                    }
                                    else
                                    {
                                        sw.WriteLine("Password invalid");
                                    }
                                    break;

                                default:
                                    sw.WriteLine("Command invalid");
                                    break;
                            }
                            sw.Flush();
                        }
                        catch (IOException)
                        {
                            msg = null;
                        }
                    }
                    Console.WriteLine("Client disconnected.\nConnection closed");
                }
                //sClient.Close();
            }
        }
    }
}