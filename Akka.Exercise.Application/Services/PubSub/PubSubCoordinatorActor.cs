using Akka.Actor;
using Akka.Exercise.Application.Services.PubSub.Messages;
using System.Collections.Generic;

namespace Akka.Exercise.Application.Services.PubSub
{
    public class PubSubCoordinatorActor : ReceiveActor
    {
        private readonly Dictionary<object, IActorRef> _mappingActors;

        public PubSubCoordinatorActor()
        {
            _mappingActors = new Dictionary<object, IActorRef>();

            Receive<Subscribe>(sub => OnSubscribe(sub));
            Receive<UnSubscribe>(unSub => OnUnSubscribe(unSub));
            Receive<PublishMessage>(pub => OnPublishMessage(pub));
        }

        private void OnSubscribe(Subscribe subscribe)
        {
            if (_mappingActors.ContainsKey(subscribe.Subject))
            {
                _mappingActors[subscribe.Subject].Tell(subscribe, Self);
            }
            else
            {
                _mappingActors.Add(subscribe.Subject, Context.ActorOf(PubSubActor.CreateProps(CreateSubject(subscribe))));
            }
        }

        private void OnUnSubscribe(UnSubscribe unSubscribe)
        {
            if (_mappingActors.ContainsKey(unSubscribe.Subject))
            {
                if (unSubscribe.Subscriber == null)
                {
                    _mappingActors[unSubscribe.Subject].Tell(PoisonPill.Instance, Self);
                    _mappingActors.Remove(unSubscribe.Subject);
                }
                else
                {
                    _mappingActors[unSubscribe.Subject].Tell(unSubscribe, Self);
                }
            }
        }

        private void OnPublishMessage(PublishMessage publishMessage)
        {
            if (_mappingActors.ContainsKey(publishMessage.Subject))
            {
                _mappingActors[publishMessage.Subject].Tell(publishMessage, Self);
            }
        }
        
        private Subject CreateSubject(Subscribe sub)
        {
            return new Subject(sub.Subject, new HashSet<IActorRef>(new[] { sub.Subscriber }));
        }

        public static Props CreateProps() => Props.Create<PubSubCoordinatorActor>();
    }
}