using Microsoft.Extensions.Logging;

namespace Akka.Exercise.Application.Services.Logger.Messages
{
    public class LogEnabledItem
    {
        public LogLevel LogLevel { get; }

        public LogEnabledItem(LogLevel logLevel)
        {
            LogLevel = logLevel;
        }
    }
}