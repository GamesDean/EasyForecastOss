
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

[assembly: CLSCompliant(true)]

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
            string path = Environment.CurrentDirectory + "\\TestData\\";

            // read the json input from file, then parse it 

            string readJsonInputFromFile = System.IO.File.ReadAllText(path + "json_sample_input.json");

            //string jsonInputResult = JsonConvert.DeserializeObject(readJsonInputFromFile).ToString();
            //JToken jtokenJsoninput = JObject.Parse(jsonInputResult);
            JToken jtokenJsoninput = JObject.Parse(readJsonInputFromFile);

            // read the json output from file,then parse it   

            string readJsonOutputFromFile = System.IO.File.ReadAllText(path + "json_sample_output.json");
            //string jsonOutputResult = (string)JsonConvert.DeserializeObject(readJsonOutputFromFile).ToString();
            //JToken jtokenJsonOutput = JObject.Parse(jsonOutputResult);
            JToken jtokenJsonOutput = JObject.Parse(readJsonOutputFromFile);



            JsonOutput jOutput = new JsonOutput();

            // input json fields to shuffle, you can choose one of them
            
            string numArrayNameXYZ1 = jOutput.NumArrayNameXYZ1;
            string numArrayNameXYZ2 = jOutput.NumArrayNameXYZ2;
            string numArrayNameXYZ3 = jOutput.NumArrayNameXYZ3;

            // output json fields takin' the shuffled values
            
            string numColumnNameXYZ1 = jOutput.NumColumnNameXYZ1;
            string numColumnNameXYZ2 = jOutput.NumColumnNameXYZ2;
            string numColumnNameXYZ3 = jOutput.NumColumnNameXYZ3;

            string jsonOutput = jOutput.Jreplace( jtokenJsoninput, numArrayNameXYZ1, numColumnNameXYZ1, jtokenJsonOutput);

            Console.WriteLine(jsonOutput);
            Console.ReadLine();


        }
    }
}
