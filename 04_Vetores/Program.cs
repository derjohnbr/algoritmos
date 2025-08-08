using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Vetores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaração de Variável
            // Sintaxe: tipo nomeVariavel = valor;
            string nome = "Fulado de Tal";

            // Reatribuição de valor em uma variável
            nome = "Beltrano";
            Console.WriteLine(nome);

            // Declaração de Vetores
            // Sintaxe: tipo[] novaVariavel = {valor1, valor2, valor3};
            string[] nomes = {"Fulado de Tal", "Beltrano", "Sicrano", "João", "José", "Maria"};
            Console.WriteLine(nomes[0]);
            Console.WriteLine(nomes[1]);
            Console.WriteLine(nomes[2]);

            // Loo FOR
            // Sintax: for(indice; controle; incremento)
            for (int i = 0; i < nomes.Length; i++)
            {
                Console.WriteLine("{0}º Nome {1}", i+1, nomes[i]);
            }

            // Impressão dos 100 primeiros números pares
            for(int i = 0;i <= 100; i+=2)
            {
                Console.WriteLine(i);
            }

            // Loop foreach
            // Sintax: foreach(variavel in vetor)
            foreach (string varNome in nomes)
            { 
                Console.WriteLine("Nome: {0}",varNome);
            }
        }
    }
}
