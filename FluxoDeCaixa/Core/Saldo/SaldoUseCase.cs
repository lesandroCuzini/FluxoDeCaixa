namespace FluxoDeCaixa.Core.Saldo
{
    public class SaldoUseCase
    {
        private readonly ILancamentoRepository _lancamentoRepository;

        public SaldoUseCase(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository ?? throw new ArgumentException(nameof(lancamentoRepository));
        }

        public async Task<SaldoDiarioDTO> SaldoDiario(DateTime data)
        {
            var lancamentosDia = await _lancamentoRepository.FiltroPorData(data);
            var saldoDia = lancamentosDia.GroupBy(x => x._data).Select(x => new SaldoDiarioDTO()
            {
                Data = x.Key,
                Valor = ((x.Where(y => y._tipo.Equals("C")).Select(y => y._valor).Sum()) - (x.Where(y => y._tipo.Equals("D")).Select(y => y._valor).Sum()))
            }).FirstOrDefault();

            return saldoDia;
        }
    }
}
