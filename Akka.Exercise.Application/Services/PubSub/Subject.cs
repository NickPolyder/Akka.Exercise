using Akka.Actor;
using System;
using System.Collections.Generic;

namespace Akka.Exercise.Application.Services.PubSub.Messages
{
    public sealed class Subject : IDisposable
    {
        public object Id { get; private set; }

        public HashSet<IActorRef> Subscribers { get; private set; }

        public Subject(object id, HashSet<IActorRef> initialActorRefs)
        {
            Id = id;
            Subscribers = initialActorRefs;
        }

        public void AddSubscriber(IActorRef actorRef)
        {
            Subscribers.Add(actorRef);
        }

        public bool RemoveSubscriber(IActorRef actorRef)
        {
            return Subscribers.Remove(actorRef);
        }

        public void Publish(object message, IActorRef sender = null)
        {
            foreach (var subscriber in Subscribers)
            {
                subscriber.Tell(message, sender);
            }
        }

        public void Dispose()
        {
            Subscribers.Clear();
            Subscribers = null;
            (Id as IDisposable)?.Dispose();
            Id = null;
        }
    }
}