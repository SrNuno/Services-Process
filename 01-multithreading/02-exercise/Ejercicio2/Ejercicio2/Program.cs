namespace Ejercicio2
{
    internal class Program
    {
        public delegate void MyDelegate();
        public static void MenuGenerator(string[] names, MyDelegate[] funciones)
        {
            bool flag = false;
            int respuesta = 0;

            try
            {
                while (!flag)
                {
                    for (int i = 0; i < names.Length; i++)
                    {
                        Console.WriteLine($"{i}. {names[i]}");
                    }
                    Console.WriteLine($"{names.Length}. Exit");
                    flag = true;
                }
            }
            catch
            {

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
            new MyDelegate[] { f1, f2, f3 });
            Console.ReadKey();
        }
    }
}