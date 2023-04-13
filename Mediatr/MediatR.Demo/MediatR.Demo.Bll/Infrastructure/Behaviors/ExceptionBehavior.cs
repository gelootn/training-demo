using FluentValidation;
using MediatR.Demo.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatR.Demo.Bll.Infrastructure.Behaviors
{
    internal class ExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var result = await next();
                stopwatch.Stop();
                return result;
            }
            catch (Exception ex)
            {
                var resultType = typeof(TResponse).GetGenericArguments()[0];
                var failedValidationResponseType = typeof(Response<>).MakeGenericType(resultType);
                var invalidResponse = Activator.CreateInstance(failedValidationResponseType, origjero) as TResponse;

                //LOG ex;
                return invalidResponse;
               
            }

            
        }
    }
}
