using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using CSharpFunctionalExtensions;
using EasyForecast.SymEngine.JsonUtils;
using EasyForecast.SymEngine.JsonModels;
using EasyForecast.SymEngine.Constants;
using EasyForecast.SymEngine.Logs;


[assembly: CLSCompliant(false)]

namespace EasyForecast.SymEngine.Json
{
    public class Program
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "numColumnNameXYZ3")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "numColumnNameXYZ2")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "numArrayNameXYZ3")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "numArrayNameXYZ2")]
        static void Main()
        {
            // new log instance
            MessageLog log = new MessageLog();

            // read the json input from file
            string readJsonInputFromFile = System.IO.File.ReadAllText(Environment.CurrentDirectory + FileConstants.TestDataPath + FileConstants.JsonSampleInputFileName);

            // deserialize Json string 'readJsonInputFromFile' in class 'JsonInputModel'
            JsonInputModel jsonInputModel = JsonConvert.DeserializeObject<JsonInputModel>(readJsonInputFromFile);

            // do elaborations on 'JsonInputClass'+log error
            JsonInputComputeFml jsonInputComputeFml = new JsonInputComputeFml();
            Result result = jsonInputComputeFml.ComputeFml(jsonInputModel);
            if (result.IsFailure) { log.LogMessage(result.Error); }

            // TODONOW call MergeJsonInputAndWriteJsonOutput
            // merge Input in Output object
            // serialize output
            // write output to file

            // TODONOW commenta con XML metodi pubblici e modifica EasyForecastOss

            // TODONOW vedi se applicare interfacce, refactoring, SRP

            // Remove warnings

            Console.ReadLine();

        }
    }
}
