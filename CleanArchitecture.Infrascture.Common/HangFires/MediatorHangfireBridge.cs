using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrascture.Common.HangFires
{
    public class MediatorHangfireBridge
    {
        private readonly IMediator mediator;

        public MediatorHangfireBridge(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [DisplayName("{0}")]
        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request,string JobName)
        {
          return await mediator.Send(request);
        }

        [DisplayName("{0}")]
        public async Task Send(IRequest request, string JobName)
        {
            await mediator.Send(request);
        }


    }
}
