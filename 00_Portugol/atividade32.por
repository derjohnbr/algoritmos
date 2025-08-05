programa { // 32
  funcao inicio() {
    inteiro inicial, final

    escreva("Digite valor inicial: ")
    leia(inicial)
    escreva("Digite valor final: ")
    leia(final)

    enquanto(inicial  <= final){
      se(inicial%2 == 0){
        escreva(inicial, " ")
      }
      inicial += 1
    }
  }
}
