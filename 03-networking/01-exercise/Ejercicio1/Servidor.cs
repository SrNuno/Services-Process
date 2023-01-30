using System.Net;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;

namespace Ejercicio1
{
    internal class Servidor
    {
        static void Main(string[] args)
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, 5005);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Bind(ie);
            s.Listen(10);
            Console.WriteLine($"Server waiting at port {ie.Port}");
            while (true)
            {
                Socket client = s.Accept();
                Thread thread = new Thread(threadClient);
                thread.Start(client);
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
                while (true)
                {
                    try
                    {
                        message = sr.ReadLine();
                        string[] text = message.Split(" ");
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
                                    sw.WriteLine("\nClose operation");
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
                    }
                    catch (IOException)
                    {
                        break;
                    }
                Console.WriteLine("Finish connection");
            }
            client.Close();
        }
    }
}