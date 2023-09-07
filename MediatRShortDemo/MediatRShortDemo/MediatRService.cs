using MediatR;
using MediatRShortDemo.Notifications;
using MediatRShortDemo.Requests;

namespace MediatRShortDemo
{
    public class MediatorService : IMediatorService
    {
        private readonly IMediator _mediator;
        public MediatorService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Notify(string notifyText)
        {
            await _mediator.Publish(new NotificationMessage { Message = notifyText });
        }
        
        public async Task TriggerNotifyWrong()
        {
            await _mediator.Publish(new WrongNotification());
        }

        public async Task<string> RequestResponse()
        {
            return await _mediator.Send(new Ping());
        }

        public async Task OneWay()
        {
            await _mediator.Send(new OneWayAsync());
        }

        public async Task TriggerWrongRequest()
        {
            await _mediator.Send(new WrongRequest());
        }

        public async Task TriggerErrorRequest()
        {
            await _mediator.Send(new RequestWithError());
        }
    }
}
