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
            Console.WriteLine("Visualizar Calendário [ 1 - Anual ou 2 - Mensal ] ?");
            int opcao = int.Parse(Console.ReadLine());
            Console.Write("Digite o Ano (ex: 2023): ");
            int ano = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                for (int mes = 1; mes <= 12; mes++)
                    ImprimirCalendario(CriarCalendario(mes, ano), mes, ano);
            }
            else if (opcao == 2)
            {
                Console.Write("Digite o Mes (ex: 1..12): ");
                int mes = int.Parse(Console.ReadLine());
                ImprimirCalendario(CriarCalendario(mes, ano), mes, ano);
            }
            else
                Console.WriteLine("Opção inválida!");

            Console.ReadKey();
        }

        static int[,] CriarCalendario(int mes, int ano)
        {
            int diasDoMes = DateTime.DaysInMonth(ano, mes);
            int diaSemanaInicio = (int)new DateTime(ano, mes, 1).DayOfWeek;
            int[,] calendario = new int[6, 7];
            int dia = 1;

            for (int semana = 0; semana < 6; semana++)
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                    calendario[semana, diaSemana] = (semana == 0 && diaSemana < diaSemanaInicio) || dia > diasDoMes ? 0 : dia++;

            return calendario;
        }

        static void ImprimirCalendario(int[,] calendario, int mes, int ano)
        {
            Console.WriteLine($"\nCalendário de {new DateTime(ano, mes, 1):MMMM} de {ano}");
            Console.WriteLine("Dom\tSeg\tTer\tQua\tQui\tSex\tSab");

            var feriados = RetornaFeriados(mes, ano);

            for (int semana = 0; semana < 6; semana++)
            {
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                {
                    int dia = calendario[semana, diaSemana];
                    if (feriados.Contains(dia) || diaSemana == 0)
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write((dia == 0 ? "  " : dia.ToString("00")) + "\t");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            Console.Write("\nFeriados: ");
            foreach (var f in feriados.Where(f => f != 0))
                Console.Write(f.ToString("00") + "\t");
            Console.WriteLine();
        }

        public static List<int> RetornaFeriados(int mes, int ano)
        {
            var feriados = new List<int>();
            if (mes == 1) feriados.Add(1);
            if (mes == 4) { feriados.Add(4); feriados.Add(21); }
            if (mes == 5) feriados.Add(1);
            if (mes == 7) feriados.Add(9);
            if (mes == 9) feriados.Add(7);
            if (mes == 10) feriados.Add(12);
            if (mes == 11) { feriados.Add(2); feriados.Add(15); feriados.Add(20); }
            if (mes == 12) feriados.Add(25);

            DateTime pascoa = DomingoDePascoa(ano);
            if (pascoa.Month == mes) feriados.Add(pascoa.Day);
            DateTime carnaval = pascoa.AddDays(-47);
            if (carnaval.Month == mes) feriados.Add(carnaval.Day);
            DateTime sextaSanta = pascoa.AddDays(-2);
            if (sextaSanta.Month == mes) feriados.Add(sextaSanta.Day);
            DateTime corpusChristi = pascoa.AddDays(60);
            if (corpusChristi.Month == mes) feriados.Add(corpusChristi.Day);

            feriados.Sort();
            return feriados;
        }

        public static DateTime DomingoDePascoa(int ano)
        {
            int X = 24, Y = 5;
            if (ano <= 1699) { X = 22; Y = 2; }
            else if (ano <= 1799) { X = 23; Y = 3; }
            else if (ano <= 1899) { X = 24; Y = 4; }
            else if (ano <= 2099) { X = 24; Y = 5; }
            else if (ano <= 2199) { X = 24; Y = 6; }
            else if (ano <= 2299) { X = 24; Y = 7; }

            int a = ano % 19, b = ano % 4, c = ano % 7;
            int d = (19 * a + X) % 30, g = (2 * b + 4 * c + 6 * d + Y) % 7;
            int dia = d + g > 9 ? d + g - 9 : d + g + 22;
            int mes = d + g > 9 ? 4 : 3;
            return new DateTime(ano, mes, dia);
        }
    }
}
