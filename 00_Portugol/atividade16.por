programa { // 16
  funcao inicio() {
    real nota1, nota2, media
    escreva("Digite nota 1: ")
    leia(nota1)
    escreva("Digite nota 2: ")
    leia(nota2)
    media = (nota1 + nota2) / 2
    se(media >= 9){
      escreva("EXCELENTE!!!!")
    }senao se(media >= 6){
      escreva("APROVADO!")
    }senao{
      escreva("REPROVADO!")
    }
  }
}
