using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prateleira.Application.Produto.Command;
using System.Threading;
using System.Threading.Tasks;
using Pratelerira.Infrastructure.Data.Mensagens;
using Pratelerira.Infrastructure.Data.Extensoes;
using Prateleira.Application.Produto.Query;
using System.Linq;

namespace Prateleira.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var produtos = await _mediator.Send(new GetAllProductsQuery(), cancellationToken)
                                    .ConfigureAwait(false);
            return produtos.Any() ? Ok(produtos) : NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> novo(CreateProductCommand createProductCommand, CancellationToken cancellationToken)
        {
            if (!createProductCommand.ValidationResult.IsValid)
                return BadRequest(createProductCommand.ValidationResult.Errors);

            var resultado = await _mediator.Send(createProductCommand, cancellationToken)
                                           .ConfigureAwait(false);
          return  Ok(resultado ? MsgProduto.MSG_P.StringFormat(createProductCommand.Descricao) : "");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateProductCommand update, CancellationToken cancellation)
        {
            var resposta = await _mediator.Send(update, cancellation)
                                          .ConfigureAwait(false);
            return Ok(resposta ? MsgProduto.MSG_PUpdate : "");
        }
        
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(DeleteProductCommand command, CancellationToken cancellation)
        {
            var resposta = await _mediator.Send(command, cancellation)
                                    .ConfigureAwait(false);
            return Ok(resposta ? MsgProduto.Apagar:"");
        }
    }
}
