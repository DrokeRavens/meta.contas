using Contas.Domain.Contracts;
using Contas.Domain.Entities;

namespace Contas.Data.Repositories;

public class ContaRepository : IContaRepository
{

    private ContaDbContext _contaDbContext;

    public ContaRepository(ContaDbContext contaDbContext)
    {
        _contaDbContext = contaDbContext;
    }
    
    public IEnumerable<Conta> GetContas()
    {
        var contasDb = _contaDbContext.Contas.AsQueryable();

        return contasDb;
    }

    public void CreateConta(Conta contaDb)
    {
        _contaDbContext.Contas.Add(contaDb);
        
        if (_contaDbContext.ChangeTracker.HasChanges())
            _contaDbContext.SaveChanges();
    }
}