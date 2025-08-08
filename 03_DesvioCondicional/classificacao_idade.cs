using System;

class classificacao_idade
{
	static void Main()
	{
		int idade;
		Console.WriteLine("Digite sua idade:");
		idade = int.Parse(Console.ReadLine());
		
		if(idade <= 12)
			Console.WriteLine("Você é criança");
		else if(idade <= 17)
			Console.WriteLine("Você é adolecente");
		else if(idade < 60)
			Console.WriteLine("Você é adulto");
		else
			Console.WriteLine("Você é um idoso");
	}
}