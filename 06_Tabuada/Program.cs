using System;

namespace _06_Tabuada
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero;
            string continuar = "S";

            while (continuar.ToUpper() == "S") {
                Console.WriteLine("Digite um Número");
                numero = int.Parse(Console.ReadLine());

                Console.WriteLine("\nTabuada do {0}\n", numero);
                for (int i = 0; i <= 10; i++)
                {
                    Console.WriteLine("{0} x {1} = {2}", i, numero, numero * i);
                }

                Console.WriteLine("\nDeseja continuar (S/N)");
                continuar = Console.ReadLine();

            }
        }
    }
}
