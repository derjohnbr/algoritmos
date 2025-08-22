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

            int digX = CalcularDigitoVerificador(new string(cpfVetor), 9, 10);
            if (digX != int.Parse(cpfVetor[9].ToString()))
            {
                Console.WriteLine($"CPF inválido! Resto: {digX}");
                return;
            }


            int digY = CalcularDigitoVerificador(new string(cpfVetor), 10, 11);
            if (digY != int.Parse(cpfVetor[10].ToString()))
            {
                Console.WriteLine($"CPF inválido! Resto: {digY}");
                return;
            }

            Console.WriteLine($"CPF: {cpf} VÁLIDO!!");
        }

        public static int CalcularDigitoVerificador(string cpf, int qtdNumeros, int peso)
        {
            int somaVetor = 0;
            int dig;

            if (qtdNumeros == 9)
                dig = 2;
            else
                dig = 1;

            foreach (char i in cpf.Take(cpf.Length - dig))
                {           
                    somaVetor += (int.Parse(i.ToString()) * peso);
                    peso -= 1;
                    qtdNumeros -= 1;
                }
            int digito = somaVetor % 11;
            if (digito < 2)
                digito = 0;
            else
                digito = (11 - digito);

            return digito;
        }

    }
}
