using System.Diagnostics;

namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] v = { 2, 2, 6, 7, 1, 10, 3 };
            Array.ForEach(v, (x) =>
            {
                Console.ForegroundColor = x >= 5 ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed;
                Console.WriteLine($"Student grade: {x,3}.");
                Console.ResetColor();
            });

            int res = Array.FindLastIndex(v, x => x >= 5);
            Console.WriteLine($"The last passing student is number {res + 1} in the list.");

            Array.ForEach(v, (x) =>
            {
                Console.WriteLine($"Inv: {1.0 / x}");
            });
        }
    }
}