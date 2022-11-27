using AppNet6.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet6.Infrestructuras.Validators
{
    public class SeguridadValidator : AbstractValidator<SeguridadDTO>
    {
        public SeguridadValidator()
        {
            RuleSet("Token", () =>
            {
                RuleFor(x => x.Usuario)
                           .NotNull();

                RuleFor(x => x.Contrasena)
                    .NotNull();
            });
        }
    }
}
