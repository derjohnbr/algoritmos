using System;

class CalculoIMC
{
	static void Main()
	{
		double peso, altura, imc;
		
		Console.WriteLine("Digite seu peso (Kg):");
		//Console.ReadLine() é equivalente ao Leia no Portugol
		peso = Double.Parse(Console.ReadLine());
		
		Console.WriteLine("Digite sua Altura (m):");
		altura = Double.Parse(Console.ReadLine());
		
		imc = peso / (altura * altura);
		
		if(imc < 18.5)
		{
			Console.WriteLine("Classificação: Abaixo do peso normal, IMC é: {0:F3}", imc);
		}else if(imc < 25)
		{
			Console.WriteLine("Classificação: Peso Normal, IMC é: {0:F3}", imc);
		}else
		{
			Console.WriteLine("Classificação: Acima do peso normal, IMC é: {0:F3}", imc);
		}		
	}
}