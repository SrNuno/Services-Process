﻿using System.Net.Sockets;
using System.Net;

namespace Ejercicio2
{
    internal class Server
    {
        static void Main(string[] args)
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, 5005);
            Socket s = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
            s.Bind(ie);
            s.Listen(10);
            Console.WriteLine("Server waiting at port {0}", ie.Port);
            while (true)
            {
                Socket cliente = s.Accept();
                Thread hilo = new Thread(hiloCliente);
                hilo.Start(cliente);
            }
        }

        static void hiloCliente(object socket)
        {
            string mensaje;
            Socket cliente = (Socket)socket;
            IPEndPoint ieCliente = (IPEndPoint)cliente.RemoteEndPoint;
            Console.WriteLine("Connected with client {0} at port {1}",
            ieCliente.Address, ieCliente.Port);
            using (NetworkStream ns = new NetworkStream(cliente))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                string welcome = "Wellcome to this great Server";
                sw.WriteLine(welcome);
                sw.Flush();
                while (true)
                {
                    try
                    {
                        mensaje = sr.ReadLine();
                        sw.WriteLine(mensaje);
                        sw.Flush();
                        //El mensaje es null al cerrar 
                        if (mensaje != null)
                        {
                            Console.WriteLine("{0} says: {1}",
                            ieCliente.Address, mensaje);
                        }
                    }
                    catch (IOException)
                    {
                        //Salta al acceder al socket
                        //y no estar permitido
                        break;
                    }
                }
                Console.WriteLine("Finished connection with {0}:{1}",
                ieCliente.Address, ieCliente.Port);
            }
            cliente.Close();
        }
    }
}