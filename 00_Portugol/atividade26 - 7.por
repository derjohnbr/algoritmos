programa { // 26
  funcao inicio() {
    real horas, valor, valor_total, ir, inss, sindicato
    escreva("Digite o valor da hora: R$ ")
    leia(valor)
    escreva("Digite a quantidade de hora trabalhada: ")
    leia(horas)
    valor_total = horas * valor
    ir = valor_total * 0.11
    inss = valor_total * 0.08
    sindicato = valor_total * 0.05

    escreva("\n\nSalário Bruto: R$ ", valor_total)
    escreva("\nIR (11%): R$ ", ir)
    escreva("\nINSS (8%): R$ ", inss)
    escreva("\nSindicato (5%): R$ ", sindicato)
    escreva("\nSalário Líquido: R$ ", (valor_total - (ir + inss - sindicato)))



  }
}
