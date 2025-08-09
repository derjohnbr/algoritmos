using System;

namespace _05_Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Criação de um vetor para armazenamento de 100 elementos
            string[] nomes = new string[100];
            string continuar = "S";
            int contador = 0; // começa em 0 porque arrays são indexados a partir do zero

            // LOOP while
            while (continuar.ToUpper() == "S" && contador < nomes.Length)
            {
                Console.WriteLine("Digite o {0}º nome", contador + 1);

                // Armazena diretamente no índice
                nomes[contador] = Console.ReadLine();

                // Incrementa o contador
                contador++;

                Console.WriteLine("Deseja continuar? (S/N)");
                continuar = Console.ReadLine();
            }

            Console.WriteLine("\nNomes Informados:");
            foreach (string str in nomes)
            {
                if(str != null)
                    Console.WriteLine(str);
            }
        }
    }
}
