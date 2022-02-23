using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prateleira.Application.Categoria.Command;
using Prateleira.Application.Categoria.Query;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Prateleira.Infrastruture.Data;
using Pratelerira.Infrastructure.Data.Mensagens;
using Pratelerira.Infrastructure.Data.Extensoes;

namespace Prateleira.Api.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {

        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategories(CancellationToken cancellationToken)
        {
            var categorias = await _mediator.Send(new GetAllCategoriasQuery(), cancellationToken)
                                            .ConfigureAwait(false);
           return categorias.Any() ? Ok(categorias) : NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> novo(CreateCategoriaCommand createCategoryCommand, CancellationToken cancellationToken)
        {
            if (!createCategoryCommand.ValidationResult.IsValid)
                return BadRequest(createCategoryCommand.ValidationResult.Errors);

            var resultado = await _mediator.Send(createCategoryCommand, cancellationToken)
                                           .ConfigureAwait(false);

            return Ok(resultado? MsgCategoria._200.StringFormat(createCategoryCommand.Descricao): "");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateCategoryCommand updateCategoryCommand, CancellationToken cancellationToken)
        {
            var retorno = await _mediator.Send(updateCategoryCommand, cancellationToken)
                                         .ConfigureAwait(false);
           return Ok(retorno? MsgCategoria.MSG_Actualizacao.StringFormat(updateCategoryCommand.Descricao): "");
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(DeleteCategoryCommand deleteCategory, CancellationToken cancellationToken)
        {
            var retorno = await _mediator.Send(deleteCategory, cancellationToken)
                                         .ConfigureAwait(false);
           return Ok(retorno? MsgCategoria.MSG_Rmover: "");
        }

    }
}
