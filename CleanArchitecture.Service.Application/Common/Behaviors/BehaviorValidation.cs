using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.Common.Behaviors
{
    public class BehaviorValidation<TRequest,TRespons> : IPipelineBehavior<TRequest,TRespons>
        where TRequest : IRequest<TRespons>
    {
        private readonly ILogger<TRequest> logger;
        private readonly IEnumerable<IValidator<TRequest>> validators;
        private ValidationContext<TRequest> Context;

        public BehaviorValidation(ILogger<TRequest> logger,IEnumerable<IValidator<TRequest>> validators)
        {
            this.logger = logger;
            this.validators = validators;
        }
        public async Task<TRespons> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TRespons> next)
        {
            if(validators.Any())
            {
                logger.LogInformation($"Request Validation Handle {request.GetType().Name}");

                Context = new ValidationContext<TRequest>(request);

                var Failures = validators.Select(c => c.Validate(Context)).SelectMany(d => d.Errors).Where(e => e != null).ToList();

                if(Failures.Any())
                {
                    logger.LogError($"Request Validation Error {request.GetType().Name}", Failures);
                    throw new ValidationException(Failures);
                }
            }

            return await next();
        }
    }
}
