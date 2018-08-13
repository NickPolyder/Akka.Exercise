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
            Receive<BeginScopeItem>(ReceiveBeginScopeItem);
            Receive<LogEnabledItem>(ReceiveLogEnabledItem);
            Receive<LogItem>(ReceiveLog);
        }
        

        private bool ReceiveBeginScopeItem(BeginScopeItem beginScopeItem)
        {
            Sender.Tell(_logger.BeginScope(beginScopeItem.State));

            return true;
        }

        private bool ReceiveLogEnabledItem(LogEnabledItem logEnabledItem)
        {
            Sender.Tell(_logger.IsEnabled(logEnabledItem.LogLevel));
            return true;
        }

        private bool ReceiveLog(LogItem logItem)
        {
            _logger.Log(logItem.LogLevel,
                logItem.EventId, 
                logItem.State,
                logItem.Exception,
                logItem.Formatter ?? ((o, exception) => o?.ToString()));
            Sender.Tell(System.Threading.Tasks.Task.CompletedTask);
            return true;
        }


        public static Props CreateProps(ILogger logger)
        {
            return Props.Create(() => new LoggingActor(logger));
        }
    }
}