using FluxoDeCaixa.Core.Saldo;
using Microsoft.AspNetCore.Mvc;

namespace FluxoDeCaixa.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaldosController : ControllerBase
    {
        private readonly ILogger<SaldosController> _logger;

        public SaldosController(ILogger<SaldosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> SaldoDiario([FromServices] SaldoUseCase useCase, DateTime data)
        {
            var saldoDiario = await useCase.SaldoDiario(data);
            return Ok(saldoDiario);
        }
    }
}
