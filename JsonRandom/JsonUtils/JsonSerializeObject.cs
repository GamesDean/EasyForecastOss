using CSharpFunctionalExtensions;
using Newtonsoft.Json;

namespace EasyForecast.SymEngine.JsonUtils
{
    /// <summary>Serialize every object to a Json string.
    /// Side effects: none.
    /// ERRORS: Returns Result.Fail() when parameters are empty or null.</summary>
    /// <param name="IndentedFormat">True to format the string with indentation; false to format without indentation.</param>
    /// <returns>Return object with status.</returns>
    public static class JsonSerializeObject<T>
    {
        public static Result<string> SerializeObject(T objectToSerialize, bool IndentedFormat = false)
        {
            if (objectToSerialize == null)
                return Result.Fail<string>("'objectToSerialize' is null");

            if (IndentedFormat)
            { return Result.Ok(JsonConvert.SerializeObject(objectToSerialize, Formatting.Indented)); }
            else
            { return Result.Ok(JsonConvert.SerializeObject(objectToSerialize)); }
        }
    }
}
