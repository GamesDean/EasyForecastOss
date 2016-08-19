using System;
using CSharpFunctionalExtensions;
using EasyForecast.SymEngine.Constants;


namespace EasyForecast.SymEngine.JsonIO
{
    public class JsonReadInput
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public Result<string> ReadJsonStringFromFile(string inputFilePath)
        {
            // TODOLATER add code to catch file reading errors; if exception, return Result.Fail
            string readJsonInputFromFile = System.IO.File.ReadAllText(inputFilePath);

            return Result.Ok(readJsonInputFromFile);
        }
    }
}
