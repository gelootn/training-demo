using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatRShortDemo.Requests
{
    public class OneWayAsyncHandler : IRequestHandler<OneWayAsync>
    {
        Task IRequestHandler<OneWayAsync>.Handle(OneWayAsync request, CancellationToken cancellationToken)
        {
            Console.WriteLine("In Async One Way Handler");
            return Task.CompletedTask;
        }
    }
}
