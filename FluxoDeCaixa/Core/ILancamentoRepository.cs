namespace FluxoDeCaixa.Core
{
    public interface ILancamentoRepository
    {
        Task<Lancamento> Add(Lancamento lancamento);
        Task<IEnumerable<Lancamento>> FiltroPorData(DateTime data);
    }
}
