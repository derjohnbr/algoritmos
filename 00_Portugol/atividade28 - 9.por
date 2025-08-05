programa { // 28
  funcao inicio() {
    cadeia letra
    escreva("Digite uma letra: ")
    leia(letra)

    se(letra == "a" ou letra == "e" ou letra == "i" ou letra == "o" ou letra == "u"){
      escreva("Você digitou uma vogal")
    }senao{
      escreva("Você digitou uma consoante")
    }
  }
}
