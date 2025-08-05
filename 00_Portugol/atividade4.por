programa {
  funcao inicio() {
    real num1, num2, soma, multiplicacao, subtracao, divisao
    escreva("Digite o primeiro número: ")
    leia(num1)
    escreva("Digite o segundo número: ")
    leia(num2)

    soma = num1 + num2
    multiplicacao = num1 * num2
    subtracao = num1 - num2
    divisao = num1 / num2

    escreva("\nA Soma dos números é: ", soma)
    escreva("\nA Multiplicação dos números é: ", multiplicacao)
    escreva("\nA Subtração dos números é: ", subtracao)
    escreva("\nA Divisão dos números é: ", divisao)
  }
}
