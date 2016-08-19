using System;
using Xunit;
using CSharpFunctionalExtensions;

namespace EasyForecast.SymEngine.Tests
{
    // Those are tests wrote only to show how CSharpFunctionalExtensions works

    public class CSharpFunctionalExtensions_Tests
    {

        [Fact]
        public void Result_Test_OkAndTrue_Value_From_Result()
        {
            // ARRANGE

            // ACT
            Result<bool> result = SourceForTestOfResultReturnValues("some value");

            // ASSERT
            Assert.True(result.IsSuccess);
            Assert.True(result.Value);
        }

        [Fact]
        public void Result_Test_OkAndFalse_Value_From_Result()
        {
            // ARRANGE

            // ACT
            Result<bool> result = SourceForTestOfResultReturnValues("other value");

            // ASSERT
            Assert.True(result.IsSuccess);
            Assert.False(result.Value);
        }

        [Fact]
        public void Result_Test_Failure_From_Result()
        {
            // ARRANGE

            // ACT
            Result<bool> result = SourceForTestOfResultReturnValues("");

            // ASSERT
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Result_Test_Exception_From_TryingToRead_ResultValue_When_IsFailure()
        {
            // ARRANGE

            // ACT
            Result<bool> result = SourceForTestOfResultReturnValues("");

            // ASSERT
            Assert.True(result.IsFailure);
            Assert.ThrowsAny<InvalidOperationException>(() => result.Value);
        }

        /// <summary>method used only to do tests about the return value of Result. Return failure when 'valueToProcess' is empty or Null.</summary>
        /// <param name="ValueToProcess">string to process.</param>
        /// <returns>Return True if 'valueToProcess' = "some value".</returns>
        /// <returns>Return False if 'valueToProcess' != "some value".</returns>
        private Result<bool> SourceForTestOfResultReturnValues(string valueToProcess)
        {
            if (string.IsNullOrWhiteSpace(valueToProcess))
                return Result.Fail<bool>("input paramater 'valueToProcess' is empty");

            if (valueToProcess == "some value")
            { return Result.Ok(true); }
            else
            { return Result.Ok(false); }
        }
    }
}
