programa { // 24
  funcao inicio() {
    real peso, altura, imc
    cadeia res_imc
    escreva("Digite seu peso (Kg): ")
    leia(peso)
    escreva("Digite sua altura (m): ")
    leia(altura)

    imc = peso / (altura * altura)
    
    se(imc < 18.5){
      res_imc = "Abaixo do peso normal"
    }senao se(imc >= 18.5 e imc <= 24.9){
      res_imc = "Peso normal"
    }senao se(imc >= 25.0 e imc <= 29.9){
      res_imc = "Excesso xe peso"
    }senao se(imc >= 30.0 e imc <= 34.9){
      res_imc = "Obesidade Classe I"
    }senao se(imc >= 35.0 e imc <= 39.9){
      res_imc = "Obesidade Classe II"
    }senao{
      res_imc = "Obesidade Classe III"
    }

    escreva("Seu IMC é: ", imc)
    escreva("\nClassificação: ", res_imc)

  }
}
