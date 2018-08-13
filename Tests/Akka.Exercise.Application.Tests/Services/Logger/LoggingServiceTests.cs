using System;
using Akka.Exercise.Application.Services.Logger;
using Shouldly;
using Xunit;

namespace Akka.Exercise.Application.Tests.Services.Logger
{
    public class LoggingServiceTests
    {
        [Fact]
        public void Should_Throw_ArgumentNullException_If_ActorSelection_Is_Null()
        {
            Should.Throw<ArgumentNullException>(() => new LoggingService(null));
        }

    }
}