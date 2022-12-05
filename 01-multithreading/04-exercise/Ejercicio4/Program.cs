namespace Ejercicio4
{
    internal class Program
    {
        static readonly object l = new object();
        static bool finish;
        static int val = 0;
        static void Main(string[] args)
        {
            finish = false;
            Thread thread = new Thread(() => increment());
            Thread thread1 = new Thread(() => decrement());
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
                        if (val == 1000)
                        {
                            finish = true;
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
                        if (val == -1000)
                        {
                            finish = true;
                        }
                        val--;
                    }
                }
            }
            Console.ReadKey();
        }
    }
}