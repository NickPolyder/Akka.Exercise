using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;

namespace Akka.Exercise.Application.Services.Logger
{
    /// <summary>
    /// An Extension point of <see cref="ILogger"/> to be used with the <see cref="ILoggingService"/>
    /// </summary>
    public static class LoggingServiceExtensions
    {
        //------------------------------------------DEBUG------------------------------------------//

        /// <summary>
        /// Formats and writes a debug log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogDebugAsync(0, exception, "Error while processing request from {Address}", address)</example>
        public static Task LogDebugAsync(this ILoggingService loggingService, EventId eventId, Exception exception, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Debug, eventId, exception, message, args);
        }

        /// <summary>
        /// Formats and writes a debug log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogDebugAsync(0, "Processing request from {Address}", address)</example>
        public static Task LogDebugAsync(this ILoggingService loggingService, EventId eventId, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Debug, eventId, message, args);
        }

        /// <summary>
        /// Formats and writes a debug log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogDebugAsync(exception, "Error while processing request from {Address}", address)</example>
        public static Task LogDebugAsync(this ILoggingService loggingService, Exception exception, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Debug, exception, message, args);
        }

        /// <summary>
        /// Formats and writes a debug log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogDebugAsync("Processing request from {Address}", address)</example>
        public static Task LogDebugAsync(this ILoggingService loggingService, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Debug, message, args);
        }

        //------------------------------------------TRACE------------------------------------------//

        /// <summary>
        /// Formats and writes a trace log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogTraceAsync(0, exception, "Error while processing request from {Address}", address)</example>
        public static Task LogTraceAsync(this ILoggingService loggingService, EventId eventId, Exception exception, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Trace, eventId, exception, message, args);
        }

        /// <summary>
        /// Formats and writes a trace log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogTraceAsync(0, "Processing request from {Address}", address)</example>
        public static Task LogTraceAsync(this ILoggingService loggingService, EventId eventId, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Trace, eventId, message, args);
        }

        /// <summary>
        /// Formats and writes a trace log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogTraceAsync(exception, "Error while processing request from {Address}", address)</example>
        public static Task LogTraceAsync(this ILoggingService loggingService, Exception exception, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Trace, exception, message, args);
        }

        /// <summary>
        /// Formats and writes a trace log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogTraceAsync("Processing request from {Address}", address)</example>
        public static Task LogTraceAsync(this ILoggingService loggingService, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Trace, message, args);
        }

        //------------------------------------------INFORMATION------------------------------------------//

        /// <summary>
        /// Formats and writes an informational log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogInformationAsync(0, exception, "Error while processing request from {Address}", address)</example>
        public static Task LogInformationAsync(this ILoggingService loggingService, EventId eventId, Exception exception, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Information, eventId, exception, message, args);
        }

        /// <summary>
        /// Formats and writes an informational log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogInformationAsync(0, "Processing request from {Address}", address)</example>
        public static Task LogInformationAsync(this ILoggingService loggingService, EventId eventId, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Information, eventId, message, args);
        }

        /// <summary>
        /// Formats and writes an informational log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogInformationAsync(exception, "Error while processing request from {Address}", address)</example>
        public static Task LogInformationAsync(this ILoggingService loggingService, Exception exception, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Information, exception, message, args);
        }

        /// <summary>
        /// Formats and writes an informational log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogInformationAsync("Processing request from {Address}", address)</example>
        public static Task LogInformationAsync(this ILoggingService loggingService, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Information, message, args);
        }

        //------------------------------------------WARNING------------------------------------------//

        /// <summary>
        /// Formats and writes a warning log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogWarningAsync(0, exception, "Error while processing request from {Address}", address)</example>
        public static Task LogWarningAsync(this ILoggingService loggingService, EventId eventId, Exception exception, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Warning, eventId, exception, message, args);
        }

        /// <summary>
        /// Formats and writes a warning log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogWarningAsync(0, "Processing request from {Address}", address)</example>
        public static Task LogWarningAsync(this ILoggingService loggingService, EventId eventId, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Warning, eventId, message, args);
        }

        /// <summary>
        /// Formats and writes a warning log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogWarningAsync(exception, "Error while processing request from {Address}", address)</example>
        public static Task LogWarningAsync(this ILoggingService loggingService, Exception exception, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Warning, exception, message, args);
        }

        /// <summary>
        /// Formats and writes a warning log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogWarningAsync("Processing request from {Address}", address)</example>
        public static Task LogWarningAsync(this ILoggingService loggingService, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Warning, message, args);
        }

        //------------------------------------------ERROR------------------------------------------//

        /// <summary>
        /// Formats and writes an error log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogErrorAsync(0, exception, "Error while processing request from {Address}", address)</example>
        public static Task LogErrorAsync(this ILoggingService loggingService, EventId eventId, Exception exception, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Error, eventId, exception, message, args);
        }

        /// <summary>
        /// Formats and writes an error log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogErrorAsync(0, "Processing request from {Address}", address)</example>
        public static Task LogErrorAsync(this ILoggingService loggingService, EventId eventId, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Error, eventId, message, args);
        }

        /// <summary>
        /// Formats and writes an error log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogErrorAsync(exception, "Error while processing request from {Address}", address)</example>
        public static Task LogErrorAsync(this ILoggingService loggingService, Exception exception, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Error, exception, message, args);
        }

        /// <summary>
        /// Formats and writes an error log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogErrorAsync("Processing request from {Address}", address)</example>
        public static Task LogErrorAsync(this ILoggingService loggingService, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Error, message, args);
        }

        //------------------------------------------CRITICAL------------------------------------------//

        /// <summary>
        /// Formats and writes a critical log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogCriticalAsync(0, exception, "Error while processing request from {Address}", address)</example>
        public static Task LogCriticalAsync(this ILoggingService loggingService, EventId eventId, Exception exception, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Critical, eventId, exception, message, args);
        }

        /// <summary>
        /// Formats and writes a critical log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogCriticalAsync(0, "Processing request from {Address}", address)</example>
        public static Task LogCriticalAsync(this ILoggingService loggingService, EventId eventId, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Critical, eventId, message, args);
        }

        /// <summary>
        /// Formats and writes a critical log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogCriticalAsync(exception, "Error while processing request from {Address}", address)</example>
        public static Task LogCriticalAsync(this ILoggingService loggingService, Exception exception, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Critical, exception, message, args);
        }

        /// <summary>
        /// Formats and writes a critical log message.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>loggingService.LogCriticalAsync("Processing request from {Address}", address)</example>
        public static Task LogCriticalAsync(this ILoggingService loggingService, string message, params object[] args)
        {
            return loggingService.LogAsync(LogLevel.Critical, message, args);
        }

        /// <summary>
        /// Formats and writes a log message at the specified log level.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static Task LogAsync(this ILoggingService loggingService, LogLevel logLevel, string message, params object[] args)
        {
            return loggingService.LogAsync(logLevel, 0, null, message, args);
        }

        /// <summary>
        /// Formats and writes a log message at the specified log level.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static Task LogAsync(this ILoggingService loggingService, LogLevel logLevel, EventId eventId, string message, params object[] args)
        {
            return loggingService.LogAsync(logLevel, eventId, null, message, args);
        }

        /// <summary>
        /// Formats and writes a log message at the specified log level.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static Task LogAsync(this ILoggingService loggingService, LogLevel logLevel, Exception exception, string message, params object[] args)
        {
            return loggingService.LogAsync(logLevel, 0, exception, message, args);
        }

        /// <summary>
        /// Formats and writes a log message at the specified log level.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to write to.</param>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static Task LogAsync(this ILoggingService loggingService, LogLevel logLevel, EventId eventId, Exception exception, string message, params object[] args)
        {
            if (loggingService == null)
            {
                throw new ArgumentNullException(nameof(loggingService));
            }

            return loggingService.LogAsync(logLevel, eventId, new FormattedLogValues(message, args), exception, (state, ex) => state.ToString());
        }

        //------------------------------------------Scope------------------------------------------//

        /// <summary>
        /// Formats the message and creates a scope.
        /// </summary>
        /// <param name="loggingService">The <see cref="ILoggingService"/> to create the scope in.</param>
        /// <param name="messageFormat">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A disposable scope object. Can be null.</returns>
        /// <example>
        /// using(loggingService.BeginScope("Processing request from {Address}", address))
        /// {
        /// }
        /// </example>
        public static Task<IDisposable> BeginScopeAsync(
            this ILoggingService loggingService,
            string messageFormat,
            params object[] args)
        {
            if (loggingService == null)
            {
                throw new ArgumentNullException(nameof(loggingService));
            }

            return loggingService.BeginScopeAsync(new FormattedLogValues(messageFormat, args));
        }


    }
}