using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatRShortDemo.Notifications
{
    internal class NotificationHandler : INotificationHandler<NotificationMessage>
    {
        private readonly ILogger<App> _logger;

        public NotificationHandler(ILogger<App> logger)
        {
            _logger = logger;
        }
        public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"NOT001: {notification.Message}");
            return Task.CompletedTask;
        }
    }
}
