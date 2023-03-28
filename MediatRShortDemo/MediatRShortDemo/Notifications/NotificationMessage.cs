using MediatR;

namespace MediatRShortDemo.Notifications
{
    internal class NotificationMessage : INotification
    {
        public string Message { get; set; }
    }
}
    