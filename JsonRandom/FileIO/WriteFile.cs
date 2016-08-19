using System;
using CSharpFunctionalExtensions;

namespace EasyForecast.SymEngine.FileIO
{
    public static class WriteFile
    {
        /// <summary>Write a file from a string.
        /// SIDE EFFECT: write a file.
        /// ERRORS: Result.Fail() with write file error.</summary>
        /// <param name="inputFilePath">file to write</param>
        /// <returns>Return status with object</returns>       
        public static Result WriteStringToFile(string stringToWrite, string OutputFilePath)
        {

            // see "How to: Use the Try/Catch Block to Catch Exceptions" https://msdn.microsoft.com/en-us/library/xtd0s8kd%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396
            // "try-catch (C# Reference)" https://msdn.microsoft.com/en-us/library/0yd65esw.aspx?f=255&MSPPError=-2147217396
            try
            {
                // from https://msdn.microsoft.com/en-us/library/8bh11f1k.aspx
                System.IO.File.WriteAllText(OutputFilePath, stringToWrite);

                return Result.Ok();
            }
            catch (Exception e)
            {
                return Result.Fail<string>("An exception has occurred " + e.Message);
            }
        }
    }
}
