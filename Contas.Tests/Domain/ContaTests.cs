using Contas.Domain.Entities;

namespace Contas.Tests.Domain;

public class ContaTests
{
    [Test]
    public void CriarContaDeveTerCincoDiasVencidos()
    {
        //Act
        var conta = new Conta("Conta de Teste", DateTime.Now.AddDays(-5), DateTime.Now, 1);
        
        //Test
        Assert.That(conta.DiasEmAtraso, Is.EqualTo(5));
    }

    [Test]
    public void CriarContaDeveTerValorCorrigidoPorMultaEJuros3Dias()
    {
        //Arrange
        var valor = 150m;
        //Juros compostos = montante * (1 + taxa)^dias
        var valorEsperado = Math.Round((valor * 0.02m) + valor * (decimal)Math.Pow(1 + 0.001d, 3), 2); 
        
        //Act
        var conta = new Conta("Conta de Teste", DateTime.Now.AddDays(-3), DateTime.Now, valor);
        
        //Test
        Assert.That(conta.ValorCorrigido, Is.EqualTo(valorEsperado));
    }
    
    [Test]
    public void CriarContaDeveTerValorCorrigidoPorMultaEJuros5Dias()
    {
        //Arrange
        var valor = 150m;
        //Juros compostos = montante * (1 + taxa)^dias
        var valorEsperado = Math.Round((valor * 0.03m) + valor * (decimal)Math.Pow(1 + 0.002d, 5), 2); 
        
        //Act
        var conta = new Conta("Conta de Teste", DateTime.Now.AddDays(-5), DateTime.Now, valor);
        
        //Test
        Assert.That(conta.ValorCorrigido, Is.EqualTo(valorEsperado));
    }
    
    [Test]
    public void CriarContaDeveTerValorCorrigidoPorMultaEJuros11Dias()
    {
        //Arrange
        var valor = 150m;
        //Juros compostos = montante * (1 + taxa)^dias
        var valorEsperado = Math.Round((valor * 0.05m) + valor * (decimal)Math.Pow(1 + 0.003d, 11), 2); 
        
        //Act
        var conta = new Conta("Conta de Teste", DateTime.Now.AddDays(-11), DateTime.Now, valor);
        
        //Test
        Assert.That(conta.ValorCorrigido, Is.EqualTo(valorEsperado));
    }
}