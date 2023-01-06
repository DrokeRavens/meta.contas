using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Contas.Domain.Entities;

public class Conta
{
    [Key] public long Id { get; set; }
    [Required] public string Nome { get; set; } = "";
    [Required] [Precision(18, 2)] public decimal ValorOriginal { get; set; }
    [Required] public DateTime DataVencimento { get; private set; }
    [Required] public DateTime DataPagamento { get; private set; }
    public int DiasEmAtraso { get; set; }
    [Precision(18, 2)] public decimal ValorCorrigido { get; set; }

    //Para o entity
    public Conta()
    {
    }

    public Conta(string nome, DateTime dataVencimento, DateTime dataPagamento, decimal valorOriginal)
    {
        DataVencimento = dataVencimento;
        DataPagamento = dataPagamento;
        ValorOriginal = valorOriginal;
        Nome = nome;

        ValidaCampos();
        CalculaDiasEmAtraso();
        CalculaValorCorrigido();
    }

    private void CalculaValorCorrigido()
    {
        var multa = 0m;
        var porcentagemDeJuros = 0.00m;
        
        if (DiasEmAtraso > 0 && DiasEmAtraso <= 3)
        {
            multa += ValorOriginal * 0.02m;
            porcentagemDeJuros = 0.001m;
        }
        else if (DiasEmAtraso > 3 && DiasEmAtraso <= 10)
        {
            multa += ValorOriginal * 0.03m;
            porcentagemDeJuros = 0.002m;
        }
        else if (DiasEmAtraso > 10)
        {
            multa += ValorOriginal * 0.05m;
            porcentagemDeJuros = 0.003m;
        }

        //Considerando juros compostos
        var baseCalculoJuros = Math.Pow(1 + (double)porcentagemDeJuros, DiasEmAtraso) - 1;
        var juros = ValorOriginal * (decimal)baseCalculoJuros;

        ValorCorrigido = ValorOriginal + multa + juros;
    }

    private void CalculaDiasEmAtraso()
    {
        var diferencaPagamentoVencimento = DataPagamento - DataVencimento;
        DiasEmAtraso = (int)diferencaPagamentoVencimento.TotalDays;
    }

    private void ValidaCampos()
    {
        if (string.IsNullOrEmpty(Nome)) throw new Exception("Informe um nome válido.");

        if (ValorOriginal < 0) throw new Exception("O valor não deve ser negativo.");
    }
}