namespace MediatRShortDemo
{
    public interface IMediatorService
    {
        Task Notify(string notifyText);
        Task TriggerNotifyWrong();
        Task<string> RequestResponse();
        Task OneWay();
        Task TriggerWrongRequest();
        Task TriggerErrorRequest();
    }
}
