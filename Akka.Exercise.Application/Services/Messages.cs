using Akka.Actor;
using System;

namespace Akka.Exercise.Application.Services
{
    public class ErrorMessage
    {
        public IActorRef Sender { get; }
        public Exception Error { get; }
        public string Message => Error?.Message;

        public ErrorMessage(IActorRef sender, Exception error)
        {
            Sender = sender;
            Error = error;
        }
    }
}