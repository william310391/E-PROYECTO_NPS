using AppNet6.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet6.Infrestructuras.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioDTO>
    {
        public UsuarioValidator()
        {
            RuleSet("Login", () =>
            {
                RuleFor(x => x.Cuenta)
                           .NotNull();

                RuleFor(x => x.Contrasena)
                    .NotNull();
            });
        }

    }
}
