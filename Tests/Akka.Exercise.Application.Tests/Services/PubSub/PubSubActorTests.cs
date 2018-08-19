using System;
using System.Collections.Generic;
using Akka.Actor;
using Akka.Exercise.Application.Services;
using Akka.Exercise.Application.Services.PubSub;
using Akka.Exercise.Application.Services.PubSub.Messages;
using Shouldly;
using Xunit;

namespace Akka.Exercise.Application.Tests.Services.PubSub
{
    public class PubSubActorTests : TestKit.Xunit.TestKit
    {
        [Fact]
        public void Should_Be_Able_To_Subscribe()
        {
            var subject = new Subject(Guid.NewGuid(), new HashSet<IActorRef>());
            var sut = Sys.ActorOf(PubSubActor.CreateProps(subject));
            var subscriber = CreateTestActor("subscriber");
            var subscribe = new Subscribe(subject.Id, subscriber);
           
            sut.Tell(subscribe);

            ExpectNoMsg();
        }

        [Fact]
        public void Should_Not_Be_Able_To_Subscribe_To_Wrong_Subject()
        {
            var subject = new Subject(Guid.NewGuid(), new HashSet<IActorRef>());
            var sut = Sys.ActorOf(PubSubActor.CreateProps(subject));
            var subscriber = CreateTestActor("subscriber");
            var subscribe = new Subscribe(Guid.NewGuid(), subscriber);

            sut.Tell(subscribe);

            var result = ExpectMsg<ErrorMessage>();

            result.Error.ShouldBeAssignableTo(typeof(ArgumentException));
        }

        [Fact]
        public void Should_Be_Able_To_UnSubscribe()
        {
            var subject = new Subject(Guid.NewGuid(), new HashSet<IActorRef>());
            var sut = Sys.ActorOf(PubSubActor.CreateProps(subject));
            var subscriber = CreateTestActor("subscriber");
            var subscribe = new UnSubscribe(subject.Id, subscriber);

            sut.Tell(subscribe);

            ExpectNoMsg();
        }

        [Fact]
        public void Should_Not_Be_Able_To_UnSubscribe_To_Wrong_Subject()
        {
            var subject = new Subject(Guid.NewGuid(), new HashSet<IActorRef>());
            var sut = Sys.ActorOf(PubSubActor.CreateProps(subject));
            var subscriber = CreateTestActor("subscriber");
            var message = new UnSubscribe(Guid.NewGuid(), subscriber);

            sut.Tell(message);

            var result = ExpectMsg<ErrorMessage>();

            result.Error.ShouldBeAssignableTo(typeof(ArgumentException));
        }

        [Fact]
        public void Should_Be_Able_To_Publish_Message()
        {
            const string message = "This is a test!";
            var subject = new Subject(Guid.NewGuid(), new HashSet<IActorRef>());
            var sut = Sys.ActorOf(PubSubActor.CreateProps(subject));
            var subscriber = CreateTestActor("subscriber");
            var subscribe = new Subscribe(subject.Id, subscriber);
            sut.Tell(subscribe);
            var publishMessage = new PublishMessage(subject.Id, message);

            sut.Tell(publishMessage);
            var result = ExpectMsg<string>();

            result.ShouldBe(message);

        }
    }
}