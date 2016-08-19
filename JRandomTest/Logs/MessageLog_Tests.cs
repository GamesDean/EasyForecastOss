using Xunit;
using EasyForecast.SymEngine.Logs;
using CSharpFunctionalExtensions;
using EasyForecast.SymEngine.ObjUtils;

namespace EasyForecast.SymEngine.Tests
{
    // REMEMBER  Test that each pure function does not modify the input parameters with CompareObjectsContent.TestContentIsEqualToSavedObject

    public class MessageLog_Tests
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void LogMessage_Test_Success_On_Message_To_Log()
        {
            // ARRANGE
            MessageLog logMessage = new MessageLog();
            string messageToLog = "Message to log";
            // test immutability of input parameters: save phase
            CompareObjectsContent<string> testImmutabilityOfMessageToLog = new CompareObjectsContent<string>(messageToLog);

            // ACT
            Result logResult = logMessage.LogMessage(LogLevels.Debug, messageToLog);

            // ASSERT
            Assert.True(logResult.IsSuccess);
            // test immutability of input parameters: test phase
            Assert.True(testImmutabilityOfMessageToLog.TestContentIsEqualToSavedObject(messageToLog));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void LogMessage_Test_Failure_On_NullMessage_To_Log()
        {
            // ARRANGE
            MessageLog messageLog = new MessageLog();

            // ACT
            Result logResult = messageLog.LogMessage(LogLevels.Debug, null);

            // ASSERT
            Assert.True(logResult.IsFailure);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void LogMessage_Test_Failure_On_EmptyMessage_To_Log()
        {
            // ARRANGE
            MessageLog messageLog = new MessageLog();

            // ACT
            Result logResult = messageLog.LogMessage(LogLevels.Debug, "");

            // ASSERT
            Assert.True(logResult.IsFailure);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void LogMessage_Test_Failure_On_WhitespacesMessage_To_Log()
        {
            // ARRANGE
            MessageLog messageLog = new MessageLog();

            // ACT
            Result logResult = messageLog.LogMessage(LogLevels.Debug, "     ");

            // ASSERT
            Assert.True(logResult.IsFailure);
        }
    }
}
