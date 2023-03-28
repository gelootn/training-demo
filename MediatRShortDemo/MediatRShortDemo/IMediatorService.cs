namespace MediatRShortDemo
{
    public interface IMediatorService
    {
        void Notify(string notifyText);
        string RequestResponse();
        void OneWay();
    }
}
