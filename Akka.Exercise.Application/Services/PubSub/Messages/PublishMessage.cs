namespace Akka.Exercise.Application.Services.PubSub.Messages
{
    public class PublishMessage
    {
        public object Subject { get; }
        public object Message { get; }

        public PublishMessage(object subject, object message)
        {
            Subject = subject;
            Message = message;
        }
    }
}