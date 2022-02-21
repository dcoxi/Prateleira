using FluentValidation.Results;
using MediatR;
using Prateleira.Application.Categoria.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Prateleira.Application.Categoria.Command
{
    public class CreateCategoriaCommand : IRequest<bool>
    {
        
        public string Descricao { get; set; }
        [JsonIgnore]
        public ValidationResult validationResult { get; }
        public CreateCategoriaCommand(string descricao)
        {
            Descricao = descricao;
            var validator = new CreateCategoriaCommandValidator();
            validationResult = validator.Validate(this);
        }
    }
}
