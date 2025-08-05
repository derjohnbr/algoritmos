programa {
  funcao inicio() {
    real preco, valor_total
    inteiro qtd
    escreva("Digite a Quantidade de produto: ")
    leia(qtd)
    escreva("Digite o preço unitátio: R$ ")
    leia(preco)

    valor_total = preco * qtd

    escreva("Valor total é: ", valor_total)
  }
}
