programa { // 17
  funcao inicio() {
    logico estudante
    inteiro idade
    escreva("Você é estudante? 1-SIM/0-NÃO: ")
    leia(estudante)
    escreva("Digite sua idade: ")
    leia(idade)

    se(estudante e idade < 18){
      escreva("Tem direiro ao desconto!")
    }senao{
      escreva("Não tem direito ao desconto!")
    }
  }
}
