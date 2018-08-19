using System.Threading.Tasks;
using Akka.Actor;
using Akka.Exercise.Application.Services.PubSub.Messages;

namespace Akka.Exercise.Application.Services.PubSub
{
    public interface ISubscriberService
    {
        void Subscribe(object subject, IActorRef subscriber, IActorRef sender = null);
        void Subscribe(Subscribe subscription, IActorRef sender = null);
        Task SubscribeAsync(object subject, IActorRef subscriber);
        Task SubscribeAsync(Subscribe subscription);

        void UnSubscribe(object subject, IActorRef subscriber, IActorRef sender = null);
        void UnSubscribe(UnSubscribe unSubscription, IActorRef sender = null);
        Task UnSubscribeAsync(object subject, IActorRef subscriber);
        Task UnSubscribeAsync(UnSubscribe unSubscription);

        void PublishMessage(object subject, object message, IActorRef sender = null);
        void PublishMessage(PublishMessage publishMessage, IActorRef sender = null);
    }
}