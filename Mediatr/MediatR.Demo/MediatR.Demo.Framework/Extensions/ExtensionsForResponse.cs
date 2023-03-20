namespace MediatR.Demo.Framework.Extensions;

public static class ExtensionsForResponse
{
    public static Response<T> AddMessage<T>(this Response<T> response, string message, MessageType messageType)
    {
        response.Messages.Add(new Message
        {
            MessageType = messageType,
            MessageContent = message
        });
        return response;
    }
    
    public static Response<T> AddErrorMessage<T>(this Response<T> response, string message)
    {
        return response.AddMessage(message, MessageType.Error);
    }
    
    public static Response<T> AddErrorMessage<T>(this Response<T> response, Exception ex)
    {
        if (ex.InnerException != null)
            response.AddErrorMessage(ex);
        return response.AddMessage(ex.Message, MessageType.Error);
    }
    
    public static Response<T> AddWarningMessage<T>(this Response<T> response, string message)
    {
        return response.AddMessage(message, MessageType.Warning);
    }
}