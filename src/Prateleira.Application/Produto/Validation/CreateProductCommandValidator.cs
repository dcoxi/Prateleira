using FluentValidation;
using Prateleira.Application.Produto.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prateleira.Application.Produto.Validation
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {

            RuleFor(p => p.Descricao)
                          .NotNull()
                          .NotEmpty()
                          .MaximumLength(300);
            RuleFor(c => c.IdCategorias)
                        .Cascade(CascadeMode.Stop)
                        .NotNull()
                        .Must(x => x.Length > 0);
        }
    }
}
