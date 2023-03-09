using System.Net.Sockets;
using System.Net;

namespace Cliente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string IP_SERVER = "192.168.20.16";
            string msg;
            string userMsg;
            // Indicamos servidor al que nos queremos conectar y puerto
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(IP_SERVER), 1516);
            Console.WriteLine("Starting client. Press a key to init connection");
           
            Console.ReadKey();
            Socket server = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // El cliente inicia la conexión haciendo petición con Connect
                server.Connect(ie);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Error connection: {0}\nError code: {1}({2})",
                e.Message, (SocketError)e.ErrorCode, e.ErrorCode);
                Console.ReadKey();
                return;
            }

            // Si la conexión se ha establecido se crean los Streams
            // y se inicial la comunicación siguiendo el protocolo
            // establecido en el servidor
            using (NetworkStream ns = new NetworkStream(server))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                // Leemos mensaje de bienvenida ya que es lo primero que envía el
                 msg = sr.ReadLine();
                Console.WriteLine(msg);
                while (true)
                {
                    // Lo siguiente es pedir un mensaje al usuario
                    userMsg = Console.ReadLine();
                    //Enviamos el mensaje de usuario al servidor
                    // que que el servidor está esperando que le envíen algo
                    sw.WriteLine(userMsg);
                    sw.Flush();
                    //Recibimos el mensaje del servidor
                    msg = sr.ReadLine();
                    Console.WriteLine(msg);
                }
            }
            Console.WriteLine("Ending connection");
            //Indicamos fin de transmisión.
            server.Close();


        }
    }
}