using System;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Exercise.Application.Services.Logger;
using Akka.Exercise.Application.Services.Logger.Messages;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace Akka.Exercise.Application.Tests.Services.Logger
{
    public class LoggingActorTests: TestKit.Xunit.TestKit
    {

        [Fact]
        public void Should_Receive_BeginScope()
        {
            var mockDisposable = new Mock<IDisposable>();
            var logger = new Moq.Mock<ILogger>();

            logger.Setup(
                tt => tt.BeginScope(It.IsAny<object>())).Returns(mockDisposable.Object);

            var sut = Sys.ActorOf(LoggingActor.CreateProps(logger.Object));

             sut.Tell(new BeginScopeItem(LogLevel.Critical));

            var result = ExpectMsg<IDisposable>();
            result.ShouldBe(mockDisposable.Object);

            logger.Verify(tt => tt.BeginScope(It.IsAny<object>()), Times.AtLeastOnce);
        }


        [Fact]
        public void Should_Receive_IsEnabled()
        {
            var logger = new Moq.Mock<ILogger>();
            logger.Setup(
                tt => tt.IsEnabled(It.IsAny<LogLevel>())).Returns(true);
           
            var sut = Sys.ActorOf(LoggingActor.CreateProps(logger.Object));
            sut.Tell(new LogEnabledItem(LogLevel.Critical));

            var result = ExpectMsg<bool>();

            result.ShouldBeTrue();
            logger.Verify(tt => tt.IsEnabled(It.IsAny<LogLevel>()), Times.AtLeastOnce);
        }

        [Fact]
        public void Should_Receive_Log()
        {
            var logger = new Moq.Mock<ILogger>();

            var sut = Sys.ActorOf(LoggingActor.CreateProps(logger.Object));
            sut.Tell(new LogItemBuilder()
                .SetLogLevel(LogLevel.Critical)
                .SetEventId(1)
                .SetState("state")
                .SetException(null)
                .SetFormatter((o, ex) => "")
                .Build());

            var result = ExpectMsg<Task>();

            result.ShouldBe(Task.CompletedTask);

            logger.Verify(
                tt => tt.Log(It.IsAny<LogLevel>(), It.IsAny<EventId>(), It.IsAny<object>(), It.IsAny<Exception>(),
                    It.IsAny<Func<object, Exception, string>>()), Times.AtLeastOnce);
        }
    }
}