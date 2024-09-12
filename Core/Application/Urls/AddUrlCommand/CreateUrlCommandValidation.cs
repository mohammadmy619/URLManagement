using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Urls.AddUrlCommand
{
    public class CreateUrlCommandValidation : AbstractValidator<CreateUrlCommand>
    {
        public CreateUrlCommandValidation()
        {
            RuleFor(a => a.Path)
             .NotEmpty().WithMessage("{Path} is required")
             .NotNull()
             .MaximumLength(400).WithMessage("{Path} must not exceed 400 characters");

            RuleFor(a => a.Name)
            .NotEmpty().WithMessage("{Name} is required")
             .NotNull()
             .MaximumLength(100).WithMessage("{Name} must not exceed 100 characters");

            RuleFor(a => a.description)
         .NotEmpty().WithMessage("{description} is required")
          .MaximumLength(400).WithMessage("{description} must not exceed 400 characters");


        }
    }
}
