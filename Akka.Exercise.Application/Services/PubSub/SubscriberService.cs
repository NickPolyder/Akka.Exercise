using Akka.Actor;
using Akka.Exercise.Application.Services.PubSub.Messages;
using System.Threading.Tasks;

namespace Akka.Exercise.Application.Services.PubSub
{
    public class SubscriberService : ISubscriberService
    {
        private readonly IActorRef _coordinatorActor;
        public SubscriberService(ActorSystem system)
        {
            _coordinatorActor = system.ActorOf(PubSubCoordinatorActor.CreateProps(), "subscribe-coordinator");
        }
        public void Subscribe(object subject, IActorRef subscriber, IActorRef sender = null)
        {
            Subscribe(new Subscribe(subject, subscriber), sender);
        }

        public void Subscribe(Subscribe subscription, IActorRef sender = null)
        {
            _coordinatorActor.Tell(subscription, sender);
        }

        public Task SubscribeAsync(object subject, IActorRef subscriber)
        {
            return SubscribeAsync(new Subscribe(subject, subscriber));
        }

        public Task SubscribeAsync(Subscribe subscription)
        {
            return _coordinatorActor.Ask(subscription);
        }

        public void UnSubscribe(object subject, IActorRef subscriber, IActorRef sender = null)
        {
            UnSubscribe(new UnSubscribe(subject, subscriber), sender);
        }

        public void UnSubscribe(UnSubscribe unSubscription, IActorRef sender = null)
        {
            _coordinatorActor.Tell(unSubscription, sender);
        }

        public Task UnSubscribeAsync(object subject, IActorRef subscriber)
        {
            return UnSubscribeAsync(new UnSubscribe(subject, subscriber));
        }

        public Task UnSubscribeAsync(UnSubscribe unSubscription)
        {
            return _coordinatorActor.Ask(unSubscription);
        }

        public void PublishMessage(object subject, object message, IActorRef sender = null)
        {
            PublishMessage(new PublishMessage(subject, message), sender);
        }

        public void PublishMessage(PublishMessage publishMessage, IActorRef sender = null)
        {
            _coordinatorActor.Tell(publishMessage, sender);
        }
    }
}