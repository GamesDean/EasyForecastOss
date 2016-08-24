using System;
using CSharpFunctionalExtensions;

namespace EasyForecast.SymEngine.Logs
{
    public class MessageLog
    {
        /// <summary>Log a message.
        /// SIDE EFFECTS: write log.
        /// ERRORS: Returns Result.Fail() when 'MessageToLog' is empty or null.</summary>
        /// <param name="logLevel">Log level</param>
        /// <param name="MessageToLog">Message to log</param>
        /// <returns>Return Result.Ok().</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public Result LogMessage(LogLevels logLevel, string MessageToLog)
        {
            // TODO implement a better log

            Console.WriteLine("(ErrorLevel " + logLevel  + ") " + MessageToLog);

            if (string.IsNullOrWhiteSpace(MessageToLog))
                return Result.Fail("input paramater is empty");

            return Result.Ok();
        }
    }
}
