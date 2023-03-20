namespace MediatR.Demo.Framework;

public class Message
    {
        public string? MessageContent { get; set; }
        public MessageType MessageType { get; set; }
        public string? Property { get; set; }
    }