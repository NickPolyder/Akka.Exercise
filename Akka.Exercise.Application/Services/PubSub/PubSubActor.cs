using Akka.Actor;
using Akka.Exercise.Application.Services.PubSub.Messages;
using System;

namespace Akka.Exercise.Application.Services.PubSub
{
    public class PubSubActor : ReceiveActor
    {
        private Subject _subject;

        public PubSubActor(Subject subject)
        {
            _subject = subject;
            Receive<Subscribe>(sub => OnSubscribe(sub));
            Receive<UnSubscribe>(unSub => OnUnSubscribe(unSub));
            Receive<PublishMessage>(pub => OnPublishMessage(pub));
        }

        private void OnSubscribe(Subscribe subscribe)
        {
            if (_subject.Id.Equals(subscribe.Subject))
            {
                _subject.AddSubscriber(subscribe.Subscriber);
            }
            else
            {
                UnhandledMessage(subscribe.Subject);
            }
        }
        
        private void OnUnSubscribe(UnSubscribe unSubscribe)
        {
            if (_subject.Id.Equals(unSubscribe.Subject))
            {
                if (unSubscribe.Subscriber == null)
                {
                    _subject?.Dispose();
                    Self.Tell(PoisonPill.Instance);
                }
                else
                {
                    _subject.RemoveSubscriber(unSubscribe.Subscriber);
                }
            }
            else
            {
                UnhandledMessage(unSubscribe);
            }
        }

        private void OnPublishMessage(PublishMessage publishMessage)
        {
            if (_subject.Id.Equals(publishMessage.Subject))
            {
                _subject.Publish(publishMessage.Message,Self);
            }
            else
            {
                UnhandledMessage(publishMessage.Subject);
            }
        }

        private void UnhandledMessage(object subject)
        {
            Sender.Tell(
                new ErrorMessage(Self,
                    new ArgumentException(
                        $"The Subject: {subject} is not being handled by actor path: {Self.Path}")));
        }

        public static Props CreateProps(Subject subject)
        {
            return Props.Create(() => new PubSubActor(subject));
        }
    }
}