using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatRShortDemo.Notifications
{
    internal class SecondNotificationHandler : INotificationHandler<NotificationMessage>
    {
        private readonly ILogger<App> _logger;

        public SecondNotificationHandler(ILogger<App> logger)
        {
            _logger = logger;
        }
        public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"NOT002: {notification.Message}");
            return Task.CompletedTask;
        }
    }
}
