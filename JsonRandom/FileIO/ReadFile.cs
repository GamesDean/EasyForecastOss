using System;
using CSharpFunctionalExtensions;

namespace EasyForecast.SymEngine.FileIO
{
    public static class ReadFile
    {
        /// <summary>Read a file in a string.
        /// Side effect: none.
        /// ERRORS: Result.Fail() with read file error.</summary>
        /// <param name="inputFilePath">file to read</param>
        /// <returns>Return status with object</returns>       
        public static Result<string> ReadStringFromFile(string inputFilePath)
        {
            // see "How to: Use the Try/Catch Block to Catch Exceptions" https://msdn.microsoft.com/en-us/library/xtd0s8kd%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396
            // "try-catch (C# Reference)" https://msdn.microsoft.com/en-us/library/0yd65esw.aspx?f=255&MSPPError=-2147217396
            try
            {
                string stringFromFile = System.IO.File.ReadAllText(inputFilePath);

                return Result.Ok(stringFromFile);
            }
            catch (Exception e)
            {
                return Result.Fail<string>("An exception has occurred " + e.Message);
            }
        }
    }
}
