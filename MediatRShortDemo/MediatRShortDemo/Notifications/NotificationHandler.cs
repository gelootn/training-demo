
namespace MediatRShortDemo.Notifications
{
    internal class NotificationHandler : INotificationHandler<NotificationMessage>
    {
        private readonly ILogger<NotificationHandler> _logger;

        public NotificationHandler(ILogger<NotificationHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("NOT001: {NotificationMessage}", notification.Message);
            return Task.CompletedTask;
        }
    }
}
