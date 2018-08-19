using System;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Exercise.Application.Services.Logger.Messages;
using Microsoft.Extensions.Logging;

namespace Akka.Exercise.Application.Services.Logger
{
    public class LoggingService : ILoggingService
    {
        private ICanTell _loggingActors;

        public LoggingService(ICanTell loggingActorsPath)
        {
            _loggingActors = loggingActorsPath ?? throw new ArgumentNullException(nameof(loggingActorsPath));
        }

        public void Log<TState>(LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            _loggingActors.Tell(new LogItemBuilder()
                .SetLogLevel(logLevel)
                .SetEventId(eventId)
                .SetState(state)
                .SetException(exception)
                .SetFormatter((o, ex) => formatter?.Invoke((TState)o, ex))
                .Build(),null);
        }

        public Task LogAsync<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            return _loggingActors.Ask(new LogItemBuilder()
                .SetLogLevel(logLevel)
                .SetEventId(eventId)
                .SetState(state)
                .SetException(exception)
                .SetFormatter((o, ex) => formatter?.Invoke((TState)o, ex))
                .Build());
        }

        public Task<bool> IsEnabledAsync(LogLevel logLevel)
        {
            return _loggingActors.Ask<bool>(new LogEnabledItem(logLevel));
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return IsEnabledAsync(logLevel).GetAwaiter().GetResult();
        }

        public Task<IDisposable> BeginScopeAsync<TState>(TState state)
        {
            return _loggingActors.Ask<IDisposable>(new BeginScopeItem(state));
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return BeginScopeAsync(state).GetAwaiter().GetResult();
        }


    }
}