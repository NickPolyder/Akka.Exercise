using Akka.Actor;

namespace Akka.Exercise.Application.Services.PubSub.Messages
{
    public class Subscribe
    {
        public object Subject { get; }
        public IActorRef Subscriber { get;  }

        public Subscribe(object subject,IActorRef subscriber)
        {
            Subject = subject;
            Subscriber = subscriber;
        }
    }

    public class UnSubscribe
    {
        public object Subject { get; }
        public IActorRef Subscriber { get; }

        public UnSubscribe(object subject, IActorRef subscriber)
        {
            Subject = subject;
            Subscriber = subscriber;
        }
    }
}