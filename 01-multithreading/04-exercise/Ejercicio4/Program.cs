namespace Ejercicio4
{
    internal class Program
    {
        static readonly object l = new object();
        static bool finish = false;
        static int val = 950;
        static string ganador;
        static void Main(string[] args)
        {
            Thread thread = new Thread(increment);
            Thread thread1 = new Thread(decrement);
            thread.Start();
            thread1.Start();
            thread.Join();
            thread1.Join();
        }

        static void increment()
        {
            while (!finish)
            {
                lock (l)
                {
                    if (!finish)
                    {
                        Console.WriteLine("T1: " + val);
                        int aux = val;
                        if (aux == 1000)
                        {
                            finish = true;
                            ganador = "Hilo 1";

                        }
                        val++;
                    }
                }
            }
            Console.ReadKey();
        }

        static void decrement()
        {
            while (!finish)
            {
                lock (l)
                {
                    if (!finish)
                    {
                        Console.WriteLine("T2: " + val);
                        int aux = val;
                        if (aux == -1000)
                        {
                            finish = true;
                            ganador = "Hilo 2";
                        }
                        val--;
                    }
                }
            }
            Console.ReadKey();
        }
    }
}