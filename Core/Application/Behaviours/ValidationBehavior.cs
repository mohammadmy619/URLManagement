using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Behaviours
{
  public class ValidationBehavior<TRequest, TRespone> : IPipelineBehavior<TRequest, TRespone>
        where TRequest : IRequest<TRespone>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }
        public async Task<TRespone> Handle(TRequest request, RequestHandlerDelegate<TRespone> next, CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                var validationContext = new ValidationContext<TRequest>(request);

                var validationResult = await Task.WhenAll(validators.Select(x => x.ValidateAsync(validationContext, cancellationToken)));
                var errors = validationResult.SelectMany(x => x.Errors).Where(x => x != null).ToList();
                if (errors.Count != 0)
                {
                    foreach (var item in errors)
                    {
                        throw new ValidationException(item.ErrorMessage);
                    }
                  
                }
            }
            return await next();
        }
     
    }

}
