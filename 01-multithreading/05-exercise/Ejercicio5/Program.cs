using System.Diagnostics;

namespace Ejercicio5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int apuesta;
            bool repBucle = false;
            string[] names = { "Rocinante", "Dorado", "Joselito", "Rogelio", "Mamut" };
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{i}. {names[i]}");
            }

           
        }
    }
}