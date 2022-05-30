using backend.Queries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Validators
{
    public class RegistryUserValidator : AbstractValidator<RegistryUser>
    {
        public RegistryUserValidator()
        {
            RuleFor(c => c.AccountName).NotNull().NotEmpty();
            RuleFor(c => c.Password).NotNull().NotEmpty();
            RuleFor(c => c.RePassword).NotNull().NotEmpty();
            RuleFor(c => c.Password).MinimumLength(6);
            RuleFor(c => c).Custom((p, context) =>
            {
                if (p.Password != p.RePassword)
                {
                    context.AddFailure("Password and RePassword must be the same");
                }
            });
        }
    }
}
