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
    public class BehaviorLogger<TRequest,TRespons> : IPipelineBehavior<TRequest,TRespons>
        where TRequest:IRequest<TRespons>
    {
        private readonly ILogger<TRequest> logger;

        public BehaviorLogger(ILogger<TRequest> logger)
        {
            this.logger = logger;
        }
        public async Task<TRespons> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TRespons> next)
        {
            logger.LogInformation($"Request By {request.GetType().Name}", request);

          return await next();
        }
    }
}
