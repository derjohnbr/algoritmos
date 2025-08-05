programa { // 35
  funcao inicio() {
    inteiro numero, soma = 0

    enquanto(numero != 0){
      escreva("Digite um número [0 - Sair]: ")
      leia(numero)

      soma += numero
    }
    escreva("Soma dos número: ",soma)
  }
}
