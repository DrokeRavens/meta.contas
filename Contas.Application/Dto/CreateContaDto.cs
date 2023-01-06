namespace Contas.Application.Dto;

public class CreateContaDto
{
    public string Nome { get; set; } = "";
    public decimal ValorOriginal { get; set; }
    public DateTime DataVencimento { get; set; }
    public DateTime DataPagamento { get; set; } = DateTime.Now;
}