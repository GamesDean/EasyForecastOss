using Xunit;
using EasyForecast.SymEngine.ObjUtils;
using EasyForecast.SymEngine.Fml;

namespace EasyForecast.SymEngine.Tests
{
    // REMEMBER  Test that each pure function does not modify the input parameters with CompareObjectsContent.TestContentIsEqualToSavedObject

    public class ComputeFml_Tests
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void EvaluateNumberFml_Test_Success()  
        {
            // ARRANGE
            string fmlToTest = "1";
            // test immutability of input parameters: save phase
            CompareObjectsContent<string> testImmutabilityOf_fmlToTest = new CompareObjectsContent<string>(fmlToTest);

            // ACT
            decimal fmlResult = ComputeFml.EvaluateNumberFml(fmlToTest);

            // ASSERT
            Assert.True(fmlResult == 10);
            // test immutability of input parameters: test phase
            Assert.True(testImmutabilityOf_fmlToTest.TestContentIsEqualToSavedObject(fmlToTest));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void EvaluateStringFml_Test_Success()
        {
            // ARRANGE
            string fmlToTest = "aaa";
            // test immutability of input parameters: save phase
            CompareObjectsContent<string> testImmutabilityOf_fmlToTest = new CompareObjectsContent<string>(fmlToTest);

            // ACT
            string fmlResult = ComputeFml.EvaluateStringFml(fmlToTest);

            // ASSERT
            Assert.True(fmlResult == "aaaXXX");
            // test immutability of input parameters: test phase
            Assert.True(testImmutabilityOf_fmlToTest.TestContentIsEqualToSavedObject(fmlToTest));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void EvaluateDateFml_Test_Success()
        {
            // ARRANGE
            string fmlToTest = "aaa";
            // test immutability of input parameters: save phase
            CompareObjectsContent<string> testImmutabilityOf_fmlToTest = new CompareObjectsContent<string>(fmlToTest);

            // ACT
            string fmlResult = ComputeFml.EvaluateDateFml(fmlToTest);

            // ASSERT
            Assert.True(fmlResult == "aaaXXX");
            // test immutability of input parameters: test phase
            Assert.True(testImmutabilityOf_fmlToTest.TestContentIsEqualToSavedObject(fmlToTest));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void EvaluateStringFml_Test_Success_With_Null_Input()
        {
            // ARRANGE

            // ACT
            string fmlResult = ComputeFml.EvaluateStringFml(null);

            // ASSERT
            Assert.True(fmlResult == "XXX");
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void EvaluateDateFml_Test_Success_With_Null_Input()
        {
            // ARRANGE

            // ACT
            string fmlResult = ComputeFml.EvaluateDateFml(null);

            // ASSERT
            Assert.True(fmlResult == "XXX");
        }
    }
}
