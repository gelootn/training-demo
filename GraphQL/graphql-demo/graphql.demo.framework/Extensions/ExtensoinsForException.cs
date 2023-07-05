namespace graphql.demo.framework.Extensions
{
    public static class ExtensoinsForException
    {
        public static List<Message> GetMessages(this Exception exception)
        {
            var messages = new List<Message>();

            var message = new Message
            {
                MessageContent = exception.Message,
                MessageType = MessageType.Error
            };

            messages.Add(message);

            if(exception.InnerException != null)
            {
                messages.AddRange(exception.InnerException.GetMessages());
            }
            return messages;
        }
    }
}
