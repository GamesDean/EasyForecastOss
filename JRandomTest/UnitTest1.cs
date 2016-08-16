
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EasyForecast.SymEngine.Json;

[assembly: CLSCompliant(true)]

namespace EasyForecast.SymEngine.Json.Tests
{

    [TestClass]
    public class JsonInputTest
    {

        // parse input Json
        JToken jtokenJsoninput = JObject.Parse(ConstantsJsonSamples.JsonSampleInputData1);

        [TestMethod]
        public void GetFecFieldValuesTestXYZ1()
        {
            JsonInput jTest = new JsonInput();
           
            var result = jTest.GetFecFieldValues("'NumArrayNameXYZ1'", jtokenJsoninput);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },result);
        }

        [TestMethod]
        public void GetFecFieldValuesTestXYZ2()
        {
            JsonInput jTest = new JsonInput();
            var result = jTest.GetFecFieldValues("'NumArrayNameXYZ2'", jtokenJsoninput);
            CollectionAssert.AreEqual(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 }, result);
        }

        [TestMethod]
        public void GetFecFieldValuesTestXYZ3()
        {
            JsonInput jTest = new JsonInput();
            var result = jTest.GetFecFieldValues("'NumArrayNameXYZ3'", jtokenJsoninput);
            CollectionAssert.AreEqual(new int[] { 5, 4, 3, 2, 1, 9, 8, 7, 6 }, result);
        }


    }
}
