using Dapper.Demo.Framework.Extensions;

namespace Dapper.Demo.Framework;

public class Response<T>
{
    public List<Message> Messages { get; } = new List<Message>();
    public bool IsSuccess => !Messages.Any();

    private List<T> _objects;

    public T? Value { 
        get => _objects.FirstOrDefault();
        set
        {
            switch (_objects.Count)
            {
                case > 1:
                    throw new InvalidOperationException("Can't set Value if response contains more than one value, please use Values property instead");
                case > 0:
                    _objects.RemoveAt(0);
                    break;
            }

            if (value != null) _objects.Add(value);
        }    
    }

    public List<T> Values
    {
        get => _objects;
        set => _objects = value;
    }
    public Response(T value)
    {
        _objects = new List<T> { value };
    }

    public Response(IEnumerable<T> values)
    {
        _objects = values.ToList();
    }
    
    public Response()
    {
        _objects = new List<T>();
    }

    public Response(IEnumerable<Message> messages)
    {
        this.Messages = messages.ToList();
        this._objects = new List<T>();
    }

    public static Response<T> SuccessResponse()
    {
        return new Response<T>();
    }
    
    public static Response<T> FailResponse(string message)
    {
        var response = new Response<T>();
        response.AddErrorMessage(message);
        return response;
    }
}