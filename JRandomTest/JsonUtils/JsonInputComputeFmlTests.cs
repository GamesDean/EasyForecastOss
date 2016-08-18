
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            // deserialize Json string 'readJsonInputFromFile' in class 'JsonInputModel'
            JsonInputModel jsonInputModel = JsonConvert.DeserializeObject<JsonInputModel>(ConstantsJsonSamples.JsonSampleInputData2);
            JsonInputComputeFml jsonInputComputeFml = new JsonInputComputeFml();
            JsonInputModel jsonInputModel2 = JsonConvert.DeserializeObject<JsonInputModel>(ConstantsJsonSamples.JsonSampleInputData2_ElaboratedWithComputeFmlOnJsonInput);
            string jsonInputModelString2 = JsonConvert.SerializeObject(jsonInputModel2);

            // ACT
            jsonInputComputeFml.ComputeFml(jsonInputModel);
            string jsonInputModelString = JsonConvert.SerializeObject(jsonInputModel);

            // ASSERT
            Assert.Equal(jsonInputModelString, jsonInputModelString2);
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
