using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prateleira.Application.Estoque;
using Prateleira.Application.Estoque.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prateleira.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : Controller
    {
        private readonly IMediator _mediator;

        public EstoqueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{idProduto:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductStok([FromRoute] Guid idProduto, CancellationToken cancellation)
        {
            var estoque = await _mediator.Send(new GetAllProdutoEstoqueQuery {
               IdProduto = idProduto
            }, cancellation).ConfigureAwait(false);

            return estoque == null ? NoContent() : Ok(estoque);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> novoRegisto(CreateEstoqueCommand command, CancellationToken cancellation)
        {
            var resposta = await _mediator.Send(command, cancellation).ConfigureAwait(false);
            return resposta ? Ok("Armazenamento efectuado com sucesso.") : BadRequest();

        }
    }
}
