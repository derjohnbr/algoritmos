programa { // 23
  funcao inicio() {
    inteiro idade
    escreva("Digite sua idade: ")
    leia(idade)

    se(idade <= 12){
      escreva("Você é Criança")
    }senao se(idade >= 13 e idade <= 17){
      escreva("Você é Adolecente")
    }senao{
      escreva("Você é Adulto")
    }
  }
}
