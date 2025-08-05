programa { // 19
  funcao inicio() {
    inteiro n1, n2, n3
    escreva("Digite número 1: ")
    leia(n1)
    escreva("Digite número 2: ")
    leia(n2)
    escreva("Digite número 3: ")
    leia(n3)
    se(n1 > n2 e n1 > n3){
      escreva(n1," maior que ",n2," e ",n3)
    }senao se(n2 > n1 e n2 > n3){
      escreva(n2," maior que ",n1," e ",n3)
    }senao{
      escreva(n3," maior que ",n1," e ",n2)
    }
  }
}
