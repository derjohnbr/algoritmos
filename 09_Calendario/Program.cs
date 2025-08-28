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

            Console.WriteLine($"\nCanlendário de {primeiroDiaMes.ToString("MMMM")} de {ano}");
            Console.WriteLine($"\nDom\tSeg\tTer\tQua\tQui\tSex\tSab");

            int[] diasFeriados = RetornaFeriados(mes, ano);
            
            //Imprimir o calendário
            for (int semana = 0; semana < 6; semana++)
            {
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                {
                    if(diasFeriados.Contains(calendario[semana, diaSemana]) || diaSemana == 0)
                        Console.ForegroundColor = ConsoleColor.Red;

                    int diaCalendario = calendario[semana, diaSemana];
                    Console.Write((diaCalendario == 0 ? "  " : diaCalendario.ToString("00")) + "\t");
                    
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            int[] feriados = RetornaFeriados(mes, ano);
            Console.Write($"\nFeriados: ");
            for (int i = 0; i < feriados.Length; i++)
            {
                if (feriados[i] != 0)
                    Console.Write(feriados[i].ToString("00") + "\t");
            }

            Console.ReadKey();
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
