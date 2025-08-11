using System;

namespace _07_TempoDownload
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tamanho = 0, velocidade = 0, tempoSegundos = 0, tempoMinutos = 0;
            bool digitacaoValidaTamanho = false;
            bool digitacaoValidaVelocidade = false;

            while (!digitacaoValidaTamanho || tamanho < 0)
            {
                Console.WriteLine("Digite o Tamanho do arquivo em MB:");
                digitacaoValidaTamanho = double.TryParse(Console.ReadLine(), out tamanho);

                if (!digitacaoValidaTamanho || tamanho < 0)
                    Console.WriteLine($"Valor inválido. Tente novamente.\n");
            }
            while (!digitacaoValidaVelocidade || velocidade < 0)
            {
                Console.WriteLine("Digite a Velocidade da internet em Mbps:");
                digitacaoValidaVelocidade = double.TryParse(Console.ReadLine(), out velocidade);

                if (!digitacaoValidaTamanho || velocidade < 0)
                    Console.WriteLine($"Valor inválido. Tente novamente.\n");
            }

            tempoSegundos = (tamanho * 8) / velocidade;

            tempoMinutos = tempoSegundos / 60;

            Console.WriteLine($"Tempo aproximado de download: {tempoMinutos:F2} minutos");

        }
    }
}
