using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamientoMedido.Modelos;
using FluentValidation;

namespace EstacionamientoMedido.Validaciones
{
    public class PlazaValidator : AbstractValidator<PlazaEstacionamiento>
    {
        public PlazaValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty()
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(10);
        }
    }
}
