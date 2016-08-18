using CSharpFunctionalExtensions;

namespace EasyForecast.SymEngine.Logs
{
    public class MessageLog
    {
        /// <summary>Log a message. Side effects: write log. Failure when 'MessageToLog' is empty.</summary>
        /// <param name="MessageToLog">Message to log</param>
        /// <returns>Return object with status.</returns>
        public Result LogMessage(string MessageToLog)
        {
            // TODO implement log

            if (MessageToLog == "")
                return Result.Fail("input paramater is empty");

            return Result.Ok();
        }
    }
}

