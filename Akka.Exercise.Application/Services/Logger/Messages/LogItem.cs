using System;
using Microsoft.Extensions.Logging;

namespace Akka.Exercise.Application.Services.Logger.Messages
{
    public class LogItem
    {
        public LogItem(LogLevel logLevel, EventId eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            LogLevel = logLevel;
            EventId = eventId;
            State = state;
            Exception = exception;
            Formatter = formatter;
        }

        public LogLevel LogLevel { get; }
        public EventId EventId { get; }
        public object State { get; }
        public Exception Exception { get; }
        public Func<object, Exception, string> Formatter { get; }
    }
}