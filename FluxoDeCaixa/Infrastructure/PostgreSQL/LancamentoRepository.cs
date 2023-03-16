using FluxoDeCaixa.Core;

namespace FluxoDeCaixa.Infrastructure.PostgreSQL
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly FluxoDeCaixaDbContext _dbContext;

        public LancamentoRepository(FluxoDeCaixaDbContext dbContext) => _dbContext = dbContext;

        public async Task<Lancamento> Add(Lancamento lancamento)
        {
            _dbContext.Add(lancamento);
            _dbContext.SaveChanges();
            return lancamento;
        }

        public async Task<IEnumerable<Lancamento>> FiltroPorData(DateTime data)
        {
            var lancamentos = _dbContext.Lancamentos
                .Where(l => l._data == data)
                .ToList();
            return lancamentos;
        }
    }
}
