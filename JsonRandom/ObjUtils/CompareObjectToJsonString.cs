using EasyForecast.SymEngine.JsonUtils;
using CSharpFunctionalExtensions;

namespace EasyForecast.SymEngine.ObjUtils
{
    public static class CompareObjectToJsonString
    {
        /// <summary>Compare an object to another object serialized in a Json string.
        /// Side effects: none.
        /// ERRORS: Returns False when parameters are empty or null.</summary>
        /// <param name="firstObjectToCompare">First object to compare.</param>
        /// <param name="secondObjectToCompareJsonSerialized">Second object to compare (Json string).</param>
        /// <returns>True if objects are equal, False if objects are different (the comparison is done serializing them in Json)</returns>
        public static bool TestContentIsEqual<T>(T firstObjectToCompare, string secondObjectToCompareJsonSerialized)
        {
            if (firstObjectToCompare == null & secondObjectToCompareJsonSerialized == null)
                return true;

            if (firstObjectToCompare == null & secondObjectToCompareJsonSerialized != null)
                return false;

            if (firstObjectToCompare != null & secondObjectToCompareJsonSerialized == null)
                return false;

            // serialize 'firstObjectToCompare'
            Result<string> firstObjectToCompareJsonSerialized = JsonSerializeObject<T>.SerializeObject(firstObjectToCompare);
            if (firstObjectToCompareJsonSerialized.IsFailure)
                return false;

            // deserialize and serialize 'secondObjectToCompareJsonSerialized'
            Result<T> secondObjectToCompare = JsonDeserializeObject<T>.DeserializeObject(secondObjectToCompareJsonSerialized, SerializationMethods.Replace);
            if (secondObjectToCompare.IsFailure)
                return false;
            Result<string> secondObjectToCompareJsonReserialized = JsonSerializeObject<T>.SerializeObject(secondObjectToCompare.Value);
            if (secondObjectToCompareJsonReserialized.IsFailure)
                return false;

            // compare two Json serialized objects for equality
            if (firstObjectToCompareJsonSerialized.Value == secondObjectToCompareJsonReserialized.Value)
            { return true; }
            else
            { return false; }

        }
    }
}
