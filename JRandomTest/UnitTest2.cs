
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using FluentAssertions;
using EasyForecast.SymEngine.Json;

namespace EasyForecast.SymEngine.Json.Tests
{
    public class JsonInputTest2
    {

        // parse input Json
        JToken jtokenJsoninput = JObject.Parse(ConstantsJsonSamples.JsonSampleInputData1);


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
