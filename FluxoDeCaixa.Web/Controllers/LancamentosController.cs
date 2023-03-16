using FluxoDeCaixa.Core;
using FluxoDeCaixa.Infrastructure.PostgreSQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluxoDeCaixa.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentosController : ControllerBase
    {
        private readonly ILogger<LancamentosController> _logger;
        private readonly ILancamentoRepository _lancamentoRepository;

        public LancamentosController(ILogger<LancamentosController> logger, ILancamentoRepository lancamentoRepository)
        {
            _logger = logger;
            _lancamentoRepository = lancamentoRepository ?? throw new ArgumentNullException(nameof(lancamentoRepository));
        }

        [HttpPost]
        public async Task<IActionResult> AddLancamento(Models.LancamentoRequest request)
        {
            var lancamento = new Lancamento(request.Data, request.Valor, request.Tipo);
            var lancamentoAdded = await _lancamentoRepository.Add(lancamento);
            return Ok(lancamentoAdded);
        }
    }
}
