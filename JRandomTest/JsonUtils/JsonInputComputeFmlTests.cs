
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using CSharpFunctionalExtensions;
using EasyForecast.SymEngine.JsonUtils;
using EasyForecast.SymEngine.JsonModels;
using EasyForecast.SymEngine.Tests.Constants;


namespace EasyForecast.SymEngine.Tests.JsonUtils
{
    // REMEMBER  Test that each pure function does not modify the input parameters

    public class JsonElaborationsTests
    {

        [Fact]
        public void ComputeFmlOnJsonInput_Test_Success_On_Json_Conversion()
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
        public void ComputeFmlOnJsonInput_Test_Error_On_Input_Parameter()
        {
            // ARRANGE
            JsonInputComputeFml jsonInputComputeFml = new JsonInputComputeFml();

            // ACT
            Result result = jsonInputComputeFml.ComputeFml(null);

            // ASSERT
            Assert.True(result.IsFailure);
        }

        // TODONOW test MergeJsonInputAndWriteJsonOutput
        // crea classe Json Input da stringa Json 
        // unisci Input in Output
        // serializza Output in stringa
        // confronta stringa Output salvata con Output serializzato
        // controlla che l'oggetto di input NON sia modificato, serializzandolo con JSON >>> scrivi JsonUtils to serialize/deserialize automatically, maybe storing the original object???

    }
}
