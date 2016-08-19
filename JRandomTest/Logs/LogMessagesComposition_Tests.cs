using Xunit;
using EasyForecast.SymEngine.Logs;
using EasyForecast.SymEngine.ObjUtils;

namespace EasyForecast.SymEngine.Tests
{
    // REMEMBER  Test that each pure function does not modify the input parameters with CompareObjectsContent.TestContentIsEqualToSavedObject

    public class LogMessagesComposition_Tests
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void LogMessage_Test_Success_On_Message_To_Log()
        {
            // ARRANGE
            string classNameInError = "Class Name";
            string methodNameInError = "Method Name";
            string parametersInError = "Parameter1 + Parameter2";
            string messageToLog = "Message to log";
            // test immutability of input parameters: save phase
            CompareObjectsContent<string> testImmutabilityOf_classNameInError = new CompareObjectsContent<string>(classNameInError);
            CompareObjectsContent<string> testImmutabilityOf_methodNameInError = new CompareObjectsContent<string>(methodNameInError);
            CompareObjectsContent<string> testImmutabilityOf_parametersInError = new CompareObjectsContent<string>(parametersInError);
            CompareObjectsContent<string> testImmutabilityOf_messageToLog = new CompareObjectsContent<string>(messageToLog);
            // prepare log message as it should be
            string logMessageAsItShouldBe = messageToLog + " (Class '" + classNameInError + "' ; Method '" + methodNameInError + "' ; Parameters '" + parametersInError + "')";

            // ACT
            string logMessage = LogMessagesComposition.ComposeLogMessage(classNameInError, methodNameInError, parametersInError, messageToLog);

            // ASSERT
            Assert.True(logMessage == logMessageAsItShouldBe);
            // test immutability of input parameters: test phase
            Assert.True(testImmutabilityOf_classNameInError.TestContentIsEqualToSavedObject(classNameInError));
            Assert.True(testImmutabilityOf_methodNameInError.TestContentIsEqualToSavedObject(methodNameInError));
            Assert.True(testImmutabilityOf_parametersInError.TestContentIsEqualToSavedObject(parametersInError));
            Assert.True(testImmutabilityOf_messageToLog.TestContentIsEqualToSavedObject(messageToLog));
        }
    }
}
