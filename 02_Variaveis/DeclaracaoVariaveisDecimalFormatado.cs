using System;

class DeclaracaoVariaveisDecimamFormatado
{
	static void Main(string[] args)
	{
		/*
		UTILIZANDO PLACEHOLDER PARA DEMONSTRAR O CONTEUDO
		DE UMA VARIAVEL NO TEXTO
		{0:C}
		0 = Posição de marcação
		C = Formatação de Moeda (Currency)
		*/
		decimal x = 0.999m;
		decimal y = 9999999999999999999999999999m;
		Console.WriteLine("Minha quantia = {0:C}", x);
		Console.WriteLine("Sua quantia = {0:C}", y);
		Console.WriteLine("Valor de x = R$ {0:F3} e Valor de y = {1:C}",x,y);
		
		/* Interpolação de String */
		/*
		Console.WriteLine($"Minha quantia = {x:C}");
		Console.WriteLine($"Sua quantia = {y:C}");
		Console.WriteLine($"Valor de x = R$ {x:F3} e Valor de y = {y:C}");
		*/
	}
}