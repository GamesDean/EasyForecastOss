
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Xunit;
using FluentAssertions;

namespace EasyForecast.SymEngine.Json
{
    public class JsonInputTest2
    {

        // static string path = "C:\\Users\\Lorenzo\\Documents\\Visual Studio 2015\\Projects\\JsonRandom\\JsonRandom\\json_sample\\";
        static string path = Environment.CurrentDirectory + "\\TestData\\";
        

        // read the json input from file,then parse it 

        static string readJsonInputFromFile = System.IO.File.ReadAllText(path + "json_sample_input.json");
        static string jsonInputResult = JsonConvert.DeserializeObject(readJsonInputFromFile).ToString();
        JToken jtokenJsoninput = JObject.Parse(jsonInputResult);


        [Fact]
        public void GetFecFieldValuesTestXYZ1xUnit()
        {
            JsonInput jTest = new JsonInput();
            int[] result = jTest.GetFecFieldValues("'NumArrayNameXYZ1'", jtokenJsoninput);
            result.Should().BeEquivalentTo(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        }

        [Fact]
        public void GetFecFieldValuesTestXYZ2xUnit()
        {
            JsonInput jTest = new JsonInput();
            int[] result = jTest.GetFecFieldValues("'NumArrayNameXYZ2'", jtokenJsoninput);
            result.Should().BeEquivalentTo(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 });
        }

        [Fact]
        public void GetFecFieldValuesTestXYZ3xUnit()
        {
            JsonInput jTest = new JsonInput();
            int[] result = jTest.GetFecFieldValues("'NumArrayNameXYZ3'", jtokenJsoninput);
            result.Should().BeEquivalentTo(new int[] { 5, 4, 3, 2, 1, 9, 8, 7, 6 });
        }


    }
}
