
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using FluentAssertions;
using EasyForecast.SymEngine.Json;

namespace EasyForecast.SymEngine.Json.Tests
{
    // TODO  Test that each pure function does not modify the input parameters

    public class JsonInputTest2
    {

        // parse input/output Json
        JToken jtokenJsonInput = JObject.Parse(ConstantsJsonSamples.JsonSampleInputData1);
        JToken jtokenJsonOutput = JObject.Parse(ConstantsJsonSamples.JsonSampleOutputData1);


        [Fact]
        public void GetFecFieldValuesTestXYZ1xUnit()
        {
            JsonInput jTest = new JsonInput();
            int[] result = jTest.GetFecFieldValues("'NumArrayNameXYZ1'", jtokenJsonInput);
            result.Should().BeEquivalentTo(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        }

        [Fact]
        public void GetFecFieldValuesTestXYZ2xUnit()
        {
            JsonInput jTest = new JsonInput();
            int[] result = jTest.GetFecFieldValues("'NumArrayNameXYZ2'", jtokenJsonInput);
            result.Should().BeEquivalentTo(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 });
        }

        [Fact]
        public void GetFecFieldValuesTestXYZ3xUnit()
        {
            JsonInput jTest = new JsonInput();
            int[] result = jTest.GetFecFieldValues("'NumArrayNameXYZ3'", jtokenJsonInput);
            result.Should().BeEquivalentTo(new int[] { 5, 4, 3, 2, 1, 9, 8, 7, 6 });
        }

        [Fact]
        public void Jreplace_test_input_pars_not_changed()
        {
            // ARRANGE
            JsonOutput jOutput = new JsonOutput();

            string numArrayName = jOutput.NumArrayNameXYZ1;
            string numArrayNameSaved = jOutput.NumArrayNameXYZ1;
            string NumColumnName = jOutput.NumColumnNameXYZ1;
            string NumColumnNameSaved = jOutput.NumColumnNameXYZ1;
            JToken jtokenJsonInput = JObject.Parse(ConstantsJsonSamples.JsonSampleInputData1);
            JToken jtokenJsonInputSaved = JObject.Parse(ConstantsJsonSamples.JsonSampleInputData1);
            JToken jtokenJsonOutput = JObject.Parse(ConstantsJsonSamples.JsonSampleOutputData1);
            JToken jtokenJsonOutputSaved = JObject.Parse(ConstantsJsonSamples.JsonSampleOutputData1);

            // ACT
            string jsonOutput = jOutput.Jreplace(jtokenJsonInput, numArrayName, NumColumnName, jtokenJsonOutput);

            // ASSERT
            Assert.Equal(numArrayName, numArrayNameSaved);
            Assert.Equal(NumColumnName, NumColumnNameSaved);
            Assert.Equal(jtokenJsonInput, jtokenJsonInputSaved);
            Assert.Equal(jtokenJsonOutput, jtokenJsonOutputSaved);  // FAIL -> jOutput.Jreplace have side effects, change input parameter!!!

        }

    }
}
