namespace Ejercicio2
{
    internal class Program
    {
        public delegate void MyDelegate();
        public static void MenuGenerator(string[] names, MyDelegate[] funciones)
        {
            bool flag = false;
            int respuesta;

            while (!flag)
            {
                try
                {
                    Console.WriteLine("Menu:");
                    for (int i = 0; i < names.Length; i++)
                    {
                        Console.WriteLine($"{i + 1,5}. {names[i]}");
                    }
                    Console.WriteLine($"{names.Length + 1,5}. Exit");
                    Console.Write("Enter option: ");
                    respuesta = Convert.ToInt32(Console.ReadLine());

                    if (respuesta != 4)
                    {
                        funciones[respuesta - 1]();
                        Console.WriteLine();
                    }
                    else
                    {
                        flag = true;
                        Console.WriteLine("Thanks and come back soon!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error, you don't use characters only numbers to the options\n");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error, range excedeed\n");
                }
            }
        }

        static void f1()
        {
            Console.WriteLine("A");
        }
        static void f2()
        {
            Console.WriteLine("B");
        }
        static void f3()
        {
            Console.WriteLine("C");
        }

        static void Main(string[] args)
        {
            MenuGenerator(new string[] { "Opción", "Opción", "Opción" },
            new MyDelegate[] { () => f1(), () => f2(), () => f3()});
            Console.ReadKey();
        }
    }
}