
using Newtonsoft.Json;
using Xunit;
using CSharpFunctionalExtensions;
using EasyForecast.SymEngine.JsonUtils;
using EasyForecast.SymEngine.JsonModels;
using EasyForecast.SymEngine.Tests.Constants;


namespace EasyForecast.SymEngine.Tests
{
    // REMEMBER  Test that each pure function does not modify the input parameters

    public class JsonInputComputeFmlTests
    {

        [Fact]
        public void ComputeFml_Test_Success_On_Json_Conversion()
        {
            // ARRANGE
            JsonInputModel jsonInputModel = JsonConvert.DeserializeObject<JsonInputModel>(ConstantsJsonSamples.JsonSampleInputData2);
            JsonInputComputeFml jsonInputComputeFml = new JsonInputComputeFml();

            // ACT
            Result result = jsonInputComputeFml.ComputeFml(jsonInputModel);

            // ASSERT
            Assert.True(result.IsSuccess);
            Assert.True(JsonCompareModelToString.Compare<JsonInputModel>(jsonInputModel, ConstantsJsonSamples.JsonSampleInputData2_ElaboratedWithComputeFmlOnJsonInput));
        }

        [Fact]
        public void ComputeFml_Test_Error_On_Input_Parameter()
        {
            // ARRANGE
            JsonInputComputeFml jsonInputComputeFml = new JsonInputComputeFml();

            // ACT
            Result result = jsonInputComputeFml.ComputeFml(null);

            // ASSERT
            Assert.True(result.IsFailure);
        }

    }
}
