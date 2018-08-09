using System;
using Microsoft.Extensions.Logging;

namespace Akka.Exercise.Application.Services.Logger.Messages
{
    public class LogItemBuilder
    {
        public LogLevel LogLevel { get; private set; }
        public EventId EventId { get; private set; }
        public object State { get; private set; }
        public Exception Exception { get; private set; }
        public Func<object, Exception, string> Formatter { get; private set; }

        public LogItemBuilder SetLogLevel(LogLevel logLevel)
        {
            LogLevel = logLevel;
            return this;
        }

        public LogItemBuilder SetEventId(EventId eventId)
        {
            EventId = eventId;
            return this;
        }

        public LogItemBuilder SetState(object state)
        {
            State = state;
            return this;
        }

        public LogItemBuilder SetException(Exception exception)
        {
            Exception = exception;
            return this;
        }

        public LogItemBuilder SetFormatter(Func<object, Exception, string> formatter)
        {
            Formatter = formatter;
            return this;
        }

        public LogItem Build()
        {
            return new LogItem(LogLevel, EventId, State, Exception, Formatter);
        }
    }
}