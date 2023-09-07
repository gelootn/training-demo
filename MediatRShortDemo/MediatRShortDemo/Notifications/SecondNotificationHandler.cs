
namespace MediatRShortDemo.Notifications
{
    internal class SecondNotificationHandler : INotificationHandler<NotificationMessage>
    {
        private readonly ILogger<SecondNotificationHandler> _logger;

        public SecondNotificationHandler(ILogger<SecondNotificationHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("NOT002: {NotificationMessage}", notification.Message);
            return Task.CompletedTask;
        }
    }
}
