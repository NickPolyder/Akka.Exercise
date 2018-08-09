using Akka.Actor;
using Akka.Exercise.Application.Services.Logger.Messages;
using Microsoft.Extensions.Logging;

namespace Akka.Exercise.Application.Services.Logger
{
    public class LoggingActor : ReceiveActor
    {
        private ILogger _logger;
        public LoggingActor(ILogger logger)
        {
            _logger = logger;
        }

        protected override void PreStart()
        {
            base.PreStart();
            Receive<BeginScopeItem>(ReceiveBeginScopeItem);
            Receive<LogEnabledItem>(ReceiveLogEnabledItem);
            Receive<LogItem>(ReceiveLog);
        }

        private bool ReceiveBeginScopeItem(BeginScopeItem beginScopeItem)
        {
            Self.Tell(_logger.BeginScope(beginScopeItem.State));

            return true;
        }

        private bool ReceiveLogEnabledItem(LogEnabledItem logEnabledItem)
        {
            return _logger.IsEnabled(logEnabledItem.LogLevel);
        }

        private bool ReceiveLog(LogItem logItem)
        {
            _logger.Log(logItem.LogLevel,
                logItem.EventId, 
                logItem.State,
                logItem.Exception,
                logItem.Formatter ?? ((o, exception) => o?.ToString()));

            return true;
        }
    }
}