using FluentValidation.Results;
using MediatR;
using Prateleira.Application.Produto.Validation;
using Prateleira.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Prateleira.Application.Produto.Command
{
    public class CreateProductCommand : IRequest<bool>
    {
        public string Descricao { get; set; }
        public Guid[] IdCategorias { get; set; } 

        [JsonIgnore]
        public ValidationResult ValidationResult;

        public CreateProductCommand(Guid id, string descricao, Guid[] idCategorias)
        {
            this.Descricao    = descricao;
            this.IdCategorias = idCategorias;

            var validator = new CreateProductCommandValidator();
            ValidationResult = validator.Validate(this);
        }
    }
}
