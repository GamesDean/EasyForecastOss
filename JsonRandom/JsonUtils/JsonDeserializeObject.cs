using System;
using CSharpFunctionalExtensions;
using Newtonsoft.Json;

namespace EasyForecast.SymEngine.JsonUtils
{
    public static class JsonDeserializeObject<T>
    {
        /// <summary>Deserialize every object from a Json string.
        /// Side effects: none.
        /// ERRORS: Returns Result.Fail() when parameters are empty or null.</summary>
        /// <param name="jsonString">String to serialize</param>
        /// <param name="serializationMethod">Serialization Method, from enum SerializationMethods</param>
        /// <returns>Return object with status.</returns>
        public static Result<T> DeserializeObject(string jsonString, SerializationMethods serializationMethod = SerializationMethods.Replace)
        {
            if (string.IsNullOrWhiteSpace(jsonString))
                return Result.Fail<T>("'jsonString' is empty");

            // see "How to: Use the Try/Catch Block to Catch Exceptions" https://msdn.microsoft.com/en-us/library/xtd0s8kd%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396
            // "try-catch (C# Reference)" https://msdn.microsoft.com/en-us/library/0yd65esw.aspx?f=255&MSPPError=-2147217396
            try
            {
                if (serializationMethod == SerializationMethods.Replace)
                {
                    // initialize inner objects individually
                    // for example in default constructor some list property initialized with some values,
                    // but in 'source' these items are cleaned -
                    // without ObjectCreationHandling.Replace default constructor values will be added to result
                    //
                    // inspired to "Deep cloning objects"   http://stackoverflow.com/a/78612/5288052
                    // explanation of 'ObjectCreationHandling'  http://stackoverflow.com/questions/27848547/explanation-for-objectcreationhandling-using-newtonsoft-json
                    JsonSerializerSettings deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };

                    return Result.Ok(JsonConvert.DeserializeObject<T>(jsonString, deserializeSettings));
                }
                else
                {
                    return Result.Ok(JsonConvert.DeserializeObject<T>(jsonString));
                }
            }
            catch (Exception e)
            {
                return Result.Fail<T>("An exception has occurred " + e.Message);
            }
        }
    }

    /// <summary>List of Serialization Methods used in this class.</summary>
    public enum SerializationMethods
    {
        Replace = 0,
        Other = 1,
    }

}
