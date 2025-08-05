programa { // 27
  funcao inicio() {
    cadeia sexo
    escreva("Digite seu sexo (F - M): ")
    leia(sexo)

    se(sexo == "F"){
      escreva("Sexo Feminino")
    }senao se(sexo == "M"){
      escreva("Sexo Masculino")
    }senao{
      escreva("Sexo Inválido")
    }
  }
}
