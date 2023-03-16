namespace FluxoDeCaixa.Web.Models
{
    public class LancamentoRequest
    {
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string? Tipo { get; set; }
    }
}
