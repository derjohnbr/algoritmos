programa { // 25
  funcao inicio() {
    real peso, excesso, valor
    escreva("Digite o peso de peixes(Kg): ")
    leia(peso)

    se(peso > 50){
      excesso = peso - 50
      valor = excesso * 4
      escreva("O valor da multa é R$ ",valor)
    }senao{
      escreva("Peso dentro do padrão")
    }

    
  }
}
