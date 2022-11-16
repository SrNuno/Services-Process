namespace Ejercicio2
{
    internal class Program
    {
        public delegate void MyDelegate();
        public static void MenuGenerator(string[] names, MyDelegate[] funciones)
        {
            bool flag = false;
            int respuesta;

            if (names != null && funciones != null && names.Length == funciones.Length)
            {
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

                        if (respuesta - 1 == names.Length)
                        {
                            flag = true;
                            Console.WriteLine("Thanks and come back soon!");
                        }
                        else
                        {
                            if (respuesta > names.Length || respuesta <= 0)
                            {
                                Console.WriteLine("Option invalid");
                            }
                            else
                            {
                                funciones[respuesta - 1]();
                            }
                        }
                        Console.WriteLine();
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
            else
            {
                Console.WriteLine("Table no created");
            }
        }

        static void Main(string[] args)
        {
            MenuGenerator(new string[] { "Opción", "Opción", "Opción", "Opción", "ww" },
            new MyDelegate[] { () => Console.WriteLine("A"), () => Console.WriteLine("B"), () => Console.WriteLine("C"), () => Console.WriteLine("D"), () => Console.WriteLine("e") });
            Console.ReadKey();
        }
    }
}