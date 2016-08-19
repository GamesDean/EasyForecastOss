using System;
using CSharpFunctionalExtensions;
using EasyForecast.SymEngine.Constants;


namespace EasyForecast.SymEngine.JsonIO
{
    public class JsonReadInput
    {
        public Result<string> ReadJsonStringFromFile(string InputFilePath)
        {
            // TODOLATER add code to catch file reading errors; if exception, return Result.Fail
            string readJsonInputFromFile = System.IO.File.ReadAllText(InputFilePath);

            return Result.Ok(readJsonInputFromFile);
        }
    }
}
