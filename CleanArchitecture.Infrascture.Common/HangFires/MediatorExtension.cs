using Hangfire;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrascture.Common.HangFires
{
    public static class MediatorExtension
    {
        public static string Schedule<TRespons>(this IMediator mediator,IRequest<TRespons> request,TimeSpan timedelay)
        {
           var Result = BackgroundJob.Schedule<MediatorHangfireBridge>(c => c.Send(request, request.GetType().Name),timedelay);
           
            return Result;
        }

        public async static Task ContinueJobWith<TRespons>(this IMediator mediator, IRequest<TRespons> request, string JobId)
        {
            var Result = BackgroundJob.ContinueJobWith<MediatorHangfireBridge>(JobId,c => c.Send(request, request.GetType().Name));
           
            await Task.FromResult(Result);
        }

       

        
    }
}
