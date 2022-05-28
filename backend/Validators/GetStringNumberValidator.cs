using backend.Queries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Validators
{
    public class GetStringNumberValidator : AbstractValidator<GetStringNumber>
    {
        public GetStringNumberValidator()
        {
            RuleFor(c => c.values).NotNull();
            RuleFor(c => c.values).NotEmpty();
            RuleFor(c => c.values).Must(c => {
                string[] subs = c.Split(',');
                bool result = true;
                for (int i = 0; i < subs.Length; i++)
                {
                    if (!float.TryParse(subs[i], out var _))
                    {
                        result = false;
                        break;
                    }
                }
                return result;
            }).WithMessage("Number sequence invalid.");

        }

        //public string StringNumberValidator()

        //    FluentValidation
    }
}
