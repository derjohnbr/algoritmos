programa { // 36
  funcao inicio() {
    inteiro idade, soma = 0, cont = 0
    real media = 0.0

    enquanto(idade != 0){
      escreva("Digite uma idade [0 - Sair]: ")
      leia(idade)
      se(idade != 0){
        soma += idade
        cont +=1
      }
    }
    media = soma/cont
    escreva("A média das idades é: ",media)
  }
}
