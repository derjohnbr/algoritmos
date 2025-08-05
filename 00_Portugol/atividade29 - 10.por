programa { //29
  funcao inicio() {
    real tamanho, velocidade, tempo
    escreva("Digite o tamanho do arquivo em MB: ")
    leia(tamanho)
    escreva("Digite a velocidade da internet em  Mbps: ")
    leia(velocidade)
  tempo = (tamanho * 8) / velocidade

  escreva("O tempo em minuros é: ", tempo)
  }
}
