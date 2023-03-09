using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;

namespace Ej1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, 1516);
            using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
            ProtocolType.Tcp))
            {
                s.Bind(ie);
                s.Listen(10);
                Console.WriteLine($"Server listening at port:{ie.Port}");
                while (true)
                {
                    Socket sClient = s.Accept();
                    
                    Thread hilo = new Thread(()=>hiloCliente(sClient));
                    hilo.Start();
                }
                
                

            }
        }

        public static void hiloCliente(Socket sClient)
        {
            IPEndPoint ieClient = (IPEndPoint)sClient.RemoteEndPoint;
            Console.WriteLine("Client connected:{0} at port {1}", ieClient.Address,
           ieClient.Port);
            bool hecho = false;
            using (NetworkStream ns = new NetworkStream(sClient))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                string welcome = "Bienvenido al submundo al que nunca has querido entrar" +
                "(PD: Yo no me fiaría de un pelirrojo y tampoco vendemos fotos de pies)";
                sw.WriteLine(welcome);
                sw.Flush();
                string msg = "";
                while (msg != null&&!hecho)
                {
                    try
                    {
                        hecho = true;
                        msg = sr.ReadLine();
                        if (msg != null)
                        {
                            DateTime dt = DateTime.Now;
                            msg+=" ";
                            String[] text = msg.Split(" ");
                            switch (text[0])
                            {
                                case "time":
                                    
                                    sw.WriteLine(dt.Hour+":"+dt.Minute+":"+dt.Second);
                                   
                                    break;
                                case "date":
                                    sw.WriteLine(dt.DayOfWeek+" "+dt.Day+"/"+dt.Month+"/"+dt.Year);
                                    break;
                                case "all":
                                    sw.WriteLine(dt.Hour + ":" + dt.Minute + ":" + dt.Second+"\n"+ dt.DayOfWeek + " " + dt.Day + "/" + dt.Month + "/" + dt.Year);
                         
                                    break;
                                case "close":
                                    StreamReader reader = null;
                                    try
                                    {
                                        reader = new StreamReader(Environment.GetEnvironmentVariable("HOMEPATH") + "/Documents/Contrasenha.txt");

                                    }catch(Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }

                                    if (text[1] == reader.ReadLine())
                                    {
                                        sw.WriteLine("Cerrando server");
                                     
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        if (text[1]=="")
                                        {
                                            sw.WriteLine("No se ha enviado ninguna contraseña");
                                        }
                                        else
                                        {
                                            sw.WriteLine("La contraseña es incorrecta");

                                        }
                                        hecho = false;
                                    }

                                    break;
                                default:
                                    hecho = false;
                                    sw.WriteLine("Mande un comando válido");
                                    break;

                            }
                            
                            Console.WriteLine(msg);
                            
                            sw.Flush();
                        }
                    }
                    catch (IOException e)
                    {
                        msg = null;
                    }
                }
                Console.WriteLine("Client disconnected.\nConnection closed");
            }
            sClient.Close(); // Este no se abre con using, pues lo devuelve el accept.
        }


    }

}