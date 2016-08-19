using CSharpFunctionalExtensions;

namespace EasyForecast.SymEngine.Logs
{
    public class MessageLog
    {
        /// <summary>Log a message. Side effects: write log. Failure when 'MessageToLog' is empty.</summary>
        /// <param name="MessageToLog">Message to log</param>
        /// <returns>Return object with status.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public Result LogMessage(string MessageToLog)
        {
            // TODO implement log

            if (string.IsNullOrEmpty(MessageToLog))
                return Result.Fail("input paramater is empty");

            return Result.Ok();
        }
    }
}

