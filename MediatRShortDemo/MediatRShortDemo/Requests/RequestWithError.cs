namespace MediatRShortDemo.Requests;

public class RequestWithError : IRequest<DummyResponse>
{
    
}

public class DummyResponse
{
    public string Prop { get; set; }
}