using Application.Service.Challenge.Dtos;
using Application.Service.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Challange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitacoesController : ControllerBase
    {
        private readonly SolicitacaoModelsService _service;

        public SolicitacoesController(SolicitacaoModelsService service)
        {
            _service = service;
        }

        // POST: api/solicitacoes
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] SolicitacaoCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var solicitacao = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = solicitacao.Id }, solicitacao);
        }

        // GET: api/solicitacoes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            try
            {
                var solicitacao = await _service.ObterPorIdAsync(id);
                if (solicitacao == null)
                    return NotFound(new { message = "Solicitação não encontrada." });

                return Ok(solicitacao);
            }
            catch (Exception ex)
            {
                // logar erro detalhado
                return StatusCode(500, new { message = "Erro interno ao buscar solicitação.", detail = ex.Message });
            }
        }

        // GET: api/solicitacoes
        [HttpGet]
        public async Task<IActionResult> Listar(
            [FromQuery] string? status,
            [FromQuery] string? prioridade,
            [FromQuery] string? search,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var solicitacoes = await _service.ListarAsync(status, prioridade, search, page, pageSize);
            if (solicitacoes == null || !solicitacoes.Any())
                return Ok(new { message = "Nenhuma solicitação encontrada." });

            return Ok(solicitacoes);
        }

        // PUT: api/solicitacoes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] SolicitacaoUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // retorna erros de validação do DTO
            }

            try
            {
                
                var solicitacao = await _service.AtualizarAsync(id, dto);
                if (solicitacao == null)
                    return NotFound(new { message = "Solicitação não encontrada." });

                return Ok(solicitacao);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/solicitacoes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                var sucesso = await _service.ExcluirAsync(id);
                if (!sucesso)
                    return NotFound(new { message = "Solicitação não encontrada." });

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
    //public class SolicitacoesController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }
    //}
}
