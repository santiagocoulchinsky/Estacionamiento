using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamientoMedido.Modelos;
using FluentValidation;

namespace EstacionamientoMedido.Validaciones
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(20);

            RuleFor(x => x.Apellido)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(20);

            RuleFor(x => x.DNI)
                .NotEmpty()
                .NotNull()
                .MinimumLength(7)
                .MaximumLength(8);

            RuleFor(x => x.Telefono)
                .NotEmpty()
                .NotNull()
                .MinimumLength(6)
                .MaximumLength(12);

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(20);
        }
    }
}
