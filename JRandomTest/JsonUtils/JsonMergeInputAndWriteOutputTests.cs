
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

    // TODONOW test MergeAndWrite
    // crea classe Json Input da stringa Json 
    // unisci Input in Output
    // serializza Output in stringa
    // confronta stringa Output salvata con Output serializzato
    // controlla che l'oggetto di input NON sia modificato, serializzandolo con JSON >>> scrivi JsonUtils to serialize/deserialize automatically, maybe storing the original object???

    public class JsonMergeInputAndWriteOutputTests
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void MergeAndWrite_Test_Success_On_Json_Merge()
        {
            // ARRANGE

            // ACT

            // ASSERT
        }

    }
}
