programa { // 34
  funcao inicio() {
    inteiro contador = 0, tabuada
    escreva("Digite a Tabuada desejada: ")
    leia(tabuada)
    enquanto(contador <= 10){
      escreva(tabuada," x ",contador," = ",(tabuada * contador),"\n")
      contador += 1
    }
  }
}
