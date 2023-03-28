using Dapper.Demo.Framework;
using FluentValidation.Results;

namespace Dapper.Demo.Bll.Infrastructure.Extensions;

public static class ExtensionsForValidationResult
{
    public static List<Message> GetErrorMessages(this ValidationResult result)
    {
        return result.Errors.Select(e => new Message
        {
            MessageContent = e.ErrorMessage,
            Property = e.PropertyName,
            MessageType = MessageType.Error
        }).ToList();
    }   
}