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
        private readonly ILogger<OneWayAsyncHandler> _logger;

        public OneWayAsyncHandler(ILogger<OneWayAsyncHandler> logger)
        {
            _logger = logger;
        }
        Task IRequestHandler<OneWayAsync>.Handle(OneWayAsync request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("In Async One Way Handler");
            return Task.CompletedTask;
        }
    }
}
