namespace MediatRShortDemo.Requests;

public class RequestWithErrorHandler : IRequestHandler<RequestWithError,DummyResponse>
{
    public Task<DummyResponse> Handle(RequestWithError request, CancellationToken cancellationToken)
    {
        throw new Exception("Something went wrong");
    }
}