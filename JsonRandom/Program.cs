using System;
using CSharpFunctionalExtensions;
using EasyForecast.SymEngine.JsonUtils;
using EasyForecast.SymEngine.Data.IO.Command;
using EasyForecast.SymEngine.Data.IO.Model;
using EasyForecast.SymEngine.Constants;
using EasyForecast.SymEngine.Logs;
using EasyForecast.SymEngine.FileIO;
using EasyForecast.SymEngine.Logic.IO.Query;

[assembly: CLSCompliant(false)]

namespace EasyForecast.SymEngine.Json
{
    public class Program
    {
        // this is the "Composition root" as defined in http://blog.ploeh.dk/2011/07/28/CompositionRoot/
        private static void MainSteps()
        {
            // new log instance
            MessageLog log = new MessageLog();

            // read the json input from file
            Result<string> jsonInputFromFile = ReadFile.ReadStringFromFile(Environment.CurrentDirectory + FileConstants.TestDataPath + FileConstants.JsonSampleInputFileName);
            if (jsonInputFromFile.IsFailure)
            {
                log.LogMessage(LogLevels.FatalForInternalProblem, jsonInputFromFile.Error);
                return;
            }

            // deserialize Json string 'jsonInputFromFile' in class 'JsonInputModel'
            Result<JsonInputModel> jsonInputModel = JsonDeserializeObject<JsonInputModel>.DeserializeObject(jsonInputFromFile.Value);
            if (jsonInputModel.IsFailure)
            {
                log.LogMessage(LogLevels.FatalForInternalProblem, jsonInputModel.Error);
                return;
            }

            // compute FML from and generate Output 
            JsonWriteInputToOutput jsonWriteInputToOutput = new JsonWriteInputToOutput();
            Result<JsonOutputModel> jsonOutputModel = jsonWriteInputToOutput.ComputeFmlAndWriteOutput(jsonInputModel.Value, "Table1", 1);
            if (jsonOutputModel.IsFailure)
            {
                log.LogMessage(LogLevels.FatalForInvalidUserActionOrInput, jsonOutputModel.Error);
                return;
            }

            // serialize output
            Result<string> jsonOutputSerialized = JsonSerializeObject<JsonOutputModel>.SerializeObject(jsonOutputModel.Value, true);
            if (jsonOutputSerialized.IsFailure)
            {
                log.LogMessage(LogLevels.FatalForInvalidUserActionOrInput, jsonOutputSerialized.Error);
                return;
            }

            // write output to file
            Result jsonOutputToFile = WriteFile.WriteStringToFile(jsonOutputSerialized.Value, Environment.CurrentDirectory + FileConstants.TestDataPath + FileConstants.JsonSampleOutputFileName);
            if (jsonOutputToFile.IsFailure)
            {
                log.LogMessage(LogLevels.FatalForInternalProblem, jsonOutputToFile.Error);
                return;
            }

            // TODONOW controlla se un metodo è Pure con reflection
            // TODONOW controlla se tutti i metodi Pure testano la non modifica dei parametri di input

            // TODONOW fai prova con più FEC di Input ('JsonInputComputeFml+Tests') e più TABELLE di Output ('JsonOutputCommands+Tests' e 'JsonWriteInputToOutput+Tests') <le tabelle saranno create in automatico a partire dai FEC>

            // TODONOW rendi MainSteps una classe, estrai interfaccia di LOG e passa la classe una delle varie classi di Log da 'Main' a 'MainSteps' tra i parametri di chiamata alla funzione

            // end of Main steps
            return;

        }

        static void Main()
        {
            MainSteps();

            Console.WriteLine("All done");
            Console.ReadLine();
        }
    }
}
