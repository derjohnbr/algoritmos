programa {
  funcao inicio() {
    real valor, preco_final
    escreva("Digite o Valor do produto: R$ ")
    leia(valor)

    preco_final = valor - (valor * 0.1) 

    escreva("Valor Final com desconto de 10% é: R$ ", preco_final)
  }
}
