using CSharpFunctionalExtensions;

namespace EasyForecast.SymEngine.Logs
{
    public static class LogMessagesComposition
    {
        /// <summary>Compose a message to be used with log.
        /// Side effects: none.
        /// Errors: none.</summary>
        /// <returns>String useful to log an error.</returns>
        public static string ComposeLogMessage(string classNameInError, string methodNameInError, string parametersInError, string messageToLog)
        {
            string _classNameInError;
            string _methodNameInError;
            string _parametersInError;
            string _messageToLog;
            string _returnMessage;

            // filter out null strings

            if (string.IsNullOrWhiteSpace(classNameInError))
            { _classNameInError = ""; }
            else
            { _classNameInError = classNameInError; }

            if (string.IsNullOrWhiteSpace(methodNameInError))
            { _methodNameInError = ""; }
            else
            { _methodNameInError = methodNameInError; }

            if (string.IsNullOrWhiteSpace(parametersInError))
            { _parametersInError = ""; }
            else
            { _parametersInError = parametersInError; }

            if (string.IsNullOrWhiteSpace(messageToLog))
            { _messageToLog = ""; }
            else
            { _messageToLog = messageToLog; }

            _returnMessage = _messageToLog + " (Class '" + _classNameInError + "' ; Method '" + _methodNameInError + "' ; Parameters '" + _parametersInError + "')";

            return _returnMessage;
        }
    }
}
