namespace Contas.Application.Dto;

public class ResumoContaDto
{
    public long Id { get; set; }
    public string Nome { get; set; } = "";
    public double ValorOriginal { get; set; }
    public DateTime DataVencimento { get; set; }
    public DateTime DataPagamento { get; set; } = DateTime.Now;
    public int DiasEmAtraso { get; set; }
    public double ValorCorrigido { get; set; }
}