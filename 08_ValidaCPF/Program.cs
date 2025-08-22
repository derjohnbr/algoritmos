using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _08_ValidaCPF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o CPF:");
            string cpf = Console.ReadLine();

            //Limpeza do CPF
            string cpfLimpo = Regex.Replace(cpf, "[^0-9]", "");

            //TransformaCPF
            char[] cpfVetor = cpfLimpo.ToCharArray();

            if (cpfVetor.Length != 11)
            {
                Console.WriteLine("CPF inválido! Deve conter 11 dígitos.");
                return;
            }

            if (cpfLimpo.Distinct().Count() == 1)
            {
                Console.WriteLine("CPF inválido! Todos os dígitos são iguais.");
                return;
            }

            Console.WriteLine($"CPF: {new string(cpfVetor)}");

            //Verificação do primeiro dígito
            int somaVetorX = 0;
            int x = 10;
            foreach (char i in cpfVetor.Take(cpfVetor.Length - 2))
            {
                // Console.WriteLine($"Valor: {i}");
                somaVetorX += (int.Parse(i.ToString()) * x);
                x -= 1;
            }
            int restoX = somaVetorX % 11;
            if (restoX < 2)
            {
                restoX = 0;
            }
            else
            {
                restoX = (11 - restoX);
                // Console.WriteLine($"Resto da soma dos dígitos do CPF X {cpfVetor[9]}: {restoX}");
            }
            if (restoX != int.Parse(cpfVetor[9].ToString()))
            {
                Console.WriteLine($"CPF inválido! Resto: {restoX}");
                return;
            }

            //Verificação do segundo dígito
            int somaVetorY = 0;
            int y = 11;
            foreach (char i in cpfVetor.Take(cpfVetor.Length - 1))
            {
                // Console.WriteLine($"Valor: {i}");
                somaVetorY += (int.Parse(i.ToString()) * y);
                y -= 1;
            }
            int restoY = somaVetorY % 11;
            if (restoY < 2)
            {
                restoY = 0;
            }
            else
            {
                restoY = (11 - restoY);
                // Console.WriteLine($"Resto da soma dos dígitos do CPF Y: {restoY}");
            }
            if (restoY != int.Parse(cpfVetor[10].ToString()))
            {
                Console.WriteLine($"CPF inválido! Resto: {restoY}");
                return;
            }

            Console.WriteLine($"CPF: {cpf} VÁLIDO!!");
        }
    }
}
