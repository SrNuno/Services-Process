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
                        val++;
                    }
                }
                if (val == 1000)
                {
                    finish = true;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("T1 WIN");
                    Console.ResetColor();
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
                        val--;
                    }
                }
                if (val == -1000)
                {
                    finish = true;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("T2 WIN");
                    Console.ResetColor();
                }
            }
            Console.ReadKey();
        }
    }
}