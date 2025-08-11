using System;

namespace _06_Tabuada
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string continuar = "S";
            

            while (continuar.ToUpper() == "S") {
                int numero = 0;
                bool digitacaoValida = false;
                //Console.WriteLine("Digite um Número");
                //numero = int.Parse(Console.ReadLine());

                while (!digitacaoValida)
                {
                    Console.WriteLine("Digite um Número");
                    digitacaoValida = int.TryParse(Console.ReadLine(), out numero);

                    if (!digitacaoValida)
                        Console.WriteLine("Valor inválido. Tente novamente.\n");
                }

                //Console.WriteLine("\nTabuada do {0}\n", numero);
                Console.WriteLine($"\nTabuada do {numero}\n"); //$ -> Interpolação
                for (int i = 0; i <= 10; i++)
                {
                    //Console.WriteLine("{0} x {1} = {2}", i, numero, numero * i);
                    Console.WriteLine($"{i} x {numero} = {numero * i}");
                }

                Console.WriteLine($"\nDeseja continuar (S/N)");
                continuar = Console.ReadLine();

            }
        }
    }
}
