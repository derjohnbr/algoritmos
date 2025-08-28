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
            int mes = 0, ano = 0;

            if (opcao == 1)
            {
                Console.Write("Digite o Ano (ex: 2023)");
                ano = int.Parse(Console.ReadLine());

                for (mes = 1; mes <= 12; mes++)
                {
                    int[,] calendario = CriarCalendario(mes, ano);
                    ImprimirCalendario(calendario, mes, ano);
                    Console.WriteLine();
                }
            }
            else if (opcao == 2)
            {
                Console.Write("Digite o Mes (ex: 1..12)");
                mes = int.Parse(Console.ReadLine());

                Console.Write("Digite o Ano (ex: 2023)");
                ano = int.Parse(Console.ReadLine());

                int[,] calendario = CriarCalendario(mes, ano);
                ImprimirCalendario(calendario, mes, ano);
            }
            else
                Console.WriteLine("Opção inválida!");

            Console.ReadKey();
        }

        static int[,] CriarCalendario(int mes, int ano)
        {
            int diasDoMes = DateTime.DaysInMonth(ano, mes);
            DateTime primeiroDiaMes = new DateTime(ano, mes, 1);
            int diaSemanaInicio = (int)primeiroDiaMes.DayOfWeek;

            int[,] calendario = new int[6, 7];
            int dia = 1;

            for (int semana = 0; semana < 6; semana++)
            {
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                {
                    if (semana == 0 && diaSemana < diaSemanaInicio)
                    {
                        calendario[semana, diaSemana] = 0;
                    }
                    else if (dia <= diasDoMes)
                    {
                        calendario[semana, diaSemana] = dia;
                        dia++;
                    }
                }
            }
            return calendario;
        }

        static void ImprimirCalendario(int[,] calendario, int mes, int ano)
        {
            DateTime primeiroDiaMes = new DateTime(ano, mes, 1);
            Console.WriteLine($"\nCalendário de {primeiroDiaMes.ToString("MMMM")} de {ano}");
            Console.WriteLine($"\nDom\tSeg\tTer\tQua\tQui\tSex\tSab");

            int[] diasFeriados = RetornaFeriados(mes, ano);

            for (int semana = 0; semana < 6; semana++)
            {
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                {
                    if (diasFeriados.Contains(calendario[semana, diaSemana]) || diaSemana == 0)
                        Console.ForegroundColor = ConsoleColor.Red;

                    int diaCalendario = calendario[semana, diaSemana];
                    Console.Write((diaCalendario == 0 ? "  " : diaCalendario.ToString("00")) + "\t");

                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            Console.Write($"\nFeriados: ");
            foreach (var feriado in diasFeriados)
            {
                if (feriado != 0)
                    Console.Write(feriado.ToString("00") + "\t");
            }
        }



        public static int[] RetornaFeriados(int mes, int ano)
        {
            int[] feriados = new int[15];
            int indice = 0;
            //feriados[indice++] = 11;
            //feriados[indice++] = 21;
            if (mes == 1)
                feriados[indice++] = 1; //Confraternização Universal
            else if (mes == 4)
            {
                feriados[indice++] = 4; //Aniverssário de Marília
                feriados[indice++] = 21;  //Tiradentes
            }
            else if (mes == 5)
                feriados[indice++] = 1; //Dia do Trabalho
            else if (mes == 7)
                feriados[indice++] = 9;
            else if (mes == 9)
                feriados[indice++] = 7; //Independência do Brasil
            else if (mes == 10)
                feriados[indice++] = 12; //Nossa Senhora Aparecida
            else if (mes == 11)
            {
                feriados[indice++] = 2; //Finados
                feriados[indice++] = 15; //Proclamação da República
                feriados[indice++] = 20; //Consciência Negra
            }
            else if (mes == 12)
                feriados[indice++] = 25; //Natal

            DateTime pascoa = DomingoDePascoa(ano);
            if (pascoa.Month == mes)
                feriados[indice++] = pascoa.Day; // adiciona o dia da Páscoa
            DateTime carnaval = pascoa.AddDays(-47);
            if (carnaval.Month == mes)
                feriados[indice++] = carnaval.Day; 
            DateTime sextaSanta = pascoa.AddDays(-2);
            if (sextaSanta.Month == mes)
                feriados[indice++] = sextaSanta.Day;
            DateTime corpusChristi = pascoa.AddDays(60);
            if (corpusChristi.Month == mes)
                feriados[indice++] = corpusChristi.Day;
            //Console.WriteLine($"Pascoa: {pascoa.ToString("dd/MM/yyyy")} Carnaval {carnaval.ToString("dd/MM/yyyy")} " +
            //    $"sextaSanta {sextaSanta.ToString("dd/MM/yyyy")} corpusChristi {corpusChristi.ToString("dd/MM/yyyy")}");
            Array.Sort(feriados);
            
            return feriados;
        }

        public static DateTime DomingoDePascoa(int ano)
        {
            DateTime domingoDePascoa;
            int X = 24, Y = 5;

            if (ano <= 1699)
            {
                X = 22;
                Y = 2;
            }
            else if (ano <= 1799)
            {
                X = 23;
                Y = 3;
            }
            else if (ano <= 1899)
            {
                X = 24;
                Y = 4;
            }
            else if (ano <= 2099)
            {
                X = 24;
                Y = 5;
            }
            else if (ano <= 2199)
            {
                X = 24;
                Y = 6;
            }
            else if (ano <= 2299)
            {
                X = 24;
                Y = 7;
            }

            int a = ano % 19;
            int b = ano % 4;
            int c = ano % 7;
            int d = (19 * a + X) % 30;
            int g = (2 * b + 4 * c + 6 * d + Y) % 7;

            int dia, mes;

            if (d + g > 9)
            {
                dia = d + g - 9;
                mes = 4; // Abril
            }
            else
            {
                dia = d + g + 22;
                mes = 3; // Março
            }

            // cria a variável e atribui
            domingoDePascoa = new DateTime(ano, mes, dia);

            return domingoDePascoa;
        }

    }
}
