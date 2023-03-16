using FluxoDeCaixa.Core;
using FluxoDeCaixa.Core.Saldo;
using FluxoDeCaixa.Infrastructure.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoDeCaixa
{
    public static class Dependencies
    {
        public static IServiceCollection UseFluxoDeCaixa(this IServiceCollection serviceCollection, string connectionString)
        {
            return serviceCollection
                .AddDbContext<FluxoDeCaixaDbContext>()
                .AddTransient(_ => CreateFluxoDeCaixaDbContext(connectionString))
                .AddTransient<SaldoUseCase>()
                .AddTransient<ILancamentoRepository, LancamentoRepository>();
        }

        private static FluxoDeCaixaDbContext CreateFluxoDeCaixaDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FluxoDeCaixaDbContext>();
            optionsBuilder.UseNpgsql(connectionString);
            return new FluxoDeCaixaDbContext(optionsBuilder.Options);
        }
    }
}
