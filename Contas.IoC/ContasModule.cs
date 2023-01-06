
using Contas.Application.Contracts;
using Contas.Application.Services;
using Contas.Common;
using Contas.Data;
using Contas.Data.Repositories;
using Contas.Domain.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Contas.IoC;

public static class ContasModule
{
    public static void AddContasDb(this IServiceCollection services)
    {
        var connectionString = $"Data Source={ContasVariables.ContaDbHost}\\SQLEXPRESS;Initial Catalog=contas;User=conta;Password=12*d9aD*AHJFzskd;TrustServerCertificate=true";

        services.AddDbContext<ContaDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }

    public static void AddContasDbRepositories(this IServiceCollection services)
    {
        services.AddTransient<IContaRepository, ContaRepository>();
    }

    public static void AddContasServices(this IServiceCollection services)
    {
        services.AddTransient<IContaApplicationService, ContaApplicationService>();
    }

    public static void UseMigration(this WebApplication webApp)
    {
        using var scope = webApp.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ContaDbContext>();
        
        dbContext.Database.Migrate();
    }
}