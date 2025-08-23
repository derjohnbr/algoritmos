using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Calendario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o Mês (1..12)");
            int mes = int.Parse(Console.ReadLine());

            Console.Write("Digite o Ano (ex: 2023)");
            int ano = int.Parse(Console.ReadLine());

            //Descobre a quantidade de dias de um mês
            int diasDoMes = DateTime.DaysInMonth(ano, mes);

            //Descobre o dia da semana do primeiro dia do mês
            // 0 = Domingo, 1 = Segunda, ..., 6 = Sábado
            DateTime primeiroDiaMes = new DateTime(ano, mes, 1);
            int diaSemanaInicio = (int)primeiroDiaMes.DayOfWeek;

            //Matriz de 6 semanas e 7 dias
            int[,] calendario = new int[6, 7];
            int dia = 1;

            //Preenche a matriz com os dias do mês
            for (int semana = 0; semana < 6; semana++)
            {
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                { 
                    if (semana == 0 && diaSemana < diaSemanaInicio)
                    {
                        calendario[semana, diaSemana] = 0; // Dias vazios antes do início do mês
                    }
                    else if (dia <= diasDoMes)
                    {
                        calendario[semana, diaSemana] = dia;
                        dia++;
                    }
                }
            }

            Console.WriteLine($"Canlendário de {primeiroDiaMes.ToString("MMMM")} de {ano}");
            Console.WriteLine($"Dom\tSeg\tTer\tQua\tQui\tSex\tSab");
            //Imprimir o calendário
            for (int semana = 0; semana < 6; semana++)
            {
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                {
                    Console.Write(calendario[semana, diaSemana].ToString().PadLeft(3) + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
