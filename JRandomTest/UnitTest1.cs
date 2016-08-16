
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EasyForecast.SymEngine.Json
{

    [TestClass]
    public class JsonInputTest
    {

        // static string path = "C:\\Users\\Lorenzo\\Documents\\Visual Studio 2015\\Projects\\JsonRandom\\JsonRandom\\json_sample\\";
        static string path = Environment.CurrentDirectory + "\\TestData\\";
        

        // read the json input from file,then parse it 

        static string readJsonInputFromFile = System.IO.File.ReadAllText(path + "json_sample_input.json");
        //static string jsonInputResult = JsonConvert.DeserializeObject(readJsonInputFromFile).ToString();
        //JToken jtokenJsoninput = JObject.Parse(jsonInputResult);
        JToken jtokenJsoninput = JObject.Parse(readJsonInputFromFile);


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
