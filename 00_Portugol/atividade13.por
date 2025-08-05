programa {
  inclua biblioteca Calendario
  funcao inicio() {
      cadeia nome
      inteiro ano, idade
      escreva("Digite o Nome: ")
      leia(nome)
      escreva("Digite o ano de nascimento (xxxx): ")
      leia(ano)
      idade = Calendario.ano_atual() - ano
      escreva(nome, " sua idade é ", idade, " anos")
      
      se(idade >= 18){
        escreva("\nAcesso Liberado!")
      } senao{
        escreva("\nAcesso Negado!")
      }
  }
}
