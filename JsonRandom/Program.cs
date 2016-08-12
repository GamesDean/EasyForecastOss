
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EasyForecast.SymEngine.Json
{
    public class Program
    {

        static void Main()
        {

            string path = "C:\\Users\\Lorenzo\\Documents\\Visual Studio 2015\\Projects\\JsonRandom\\JsonRandom\\json_sample\\";

            ///read the json input from file,then parse it 

            string readJsonInputFromFile = System.IO.File.ReadAllText(path + "json_sample_input.json");
            string jsonInputResult = JsonConvert.DeserializeObject(readJsonInputFromFile).ToString();
            JToken jtokenJsoninput = JObject.Parse(jsonInputResult);

            ///read the json output from file,then parse it   

            string readJsonOutputFromFile = System.IO.File.ReadAllText(path + "json_sample_output.json");
            string jsonOutputResult = (string)JsonConvert.DeserializeObject(readJsonOutputFromFile).ToString();
            JToken jtokenJsonOutput = JObject.Parse(jsonOutputResult);



            JsonOutput jOutput = new JsonOutput();

            /// input json fields to shuffle,you can choose one of them
            
            string numArrayNameXYZ1 = jOutput.NumArrayNameXYZ1;
            string numArrayNameXYZ2 = jOutput.NumArrayNameXYZ2;
            string numArrayNameXYZ3 = jOutput.NumArrayNameXYZ3;

            /// output json fields takin' the shuffled values
            
            string numColumnNameXYZ1 = jOutput.NumColumnNameXYZ1;
            string numColumnNameXYZ2 = jOutput.NumColumnNameXYZ2;
            string numColumnNameXYZ3 = jOutput.NumColumnNameXYZ3;

            string jsonOutput = jOutput.Jreplace( jtokenJsoninput, numArrayNameXYZ1, numColumnNameXYZ1, jtokenJsonOutput);

            Console.WriteLine(jsonOutput);
            Console.ReadLine();


        }
    }
}
