using Contas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contas.Data;

public class ContaDbContext : DbContext
{
    public ContaDbContext(DbContextOptions<ContaDbContext> contextOptions) : base(contextOptions)
    {
    }
    
    public DbSet<Conta> Contas { get; set; }
}