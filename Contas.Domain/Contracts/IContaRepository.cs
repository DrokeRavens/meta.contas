using Contas.Domain.Entities;

namespace Contas.Domain.Contracts;

public interface IContaRepository
{
    IEnumerable<Conta> GetContas();
    void CreateConta(Conta contaDb);
}