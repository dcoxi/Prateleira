using FluentValidation;
using Prateleira.Application.Categoria.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prateleira.Application.Categoria.Validation
{
    public class CreateCategoriaCommandValidator : AbstractValidator<CreateCategoriaCommand>
    {
        public CreateCategoriaCommandValidator()
        {
            RuleFor(x => x.Descricao)
                          .NotNull()
                          .NotEmpty()
                          .MaximumLength(50);
        }
    }
}
