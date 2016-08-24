using EasyForecast.SymEngine.JsonUtils;
using CSharpFunctionalExtensions;

namespace EasyForecast.SymEngine.ObjUtils
{
    public class CompareObjectsContent<T>
    {
        private bool _firstObjectToCompareIsNull = false;
        private string _firstObjectSerialized;

        /// <summary>Initialize the class used to compare 2 objects serializing them with Json.
        /// SIDE EFFECTS: save in the class the value of the first object to compare.
        /// ERRORS: Returns Result.Fail() when parameters are empty or null.</summary>
        /// <param name="firstObjectToCompare">First object to compare.</param>
        /// <returns>none</returns>
        public CompareObjectsContent(T firstObjectToCompare)
        {
            if (firstObjectToCompare == null)
            {
                _firstObjectToCompareIsNull = true;
                _firstObjectSerialized = "";
            }
            else
            {
                Result<string> ObjectToCompareBeforeEditJsonSerialized = JsonSerializeObject<T>.SerializeObject(firstObjectToCompare);
                if (ObjectToCompareBeforeEditJsonSerialized.IsFailure)
                    _firstObjectSerialized = "";

                _firstObjectSerialized = ObjectToCompareBeforeEditJsonSerialized.Value;
            }
        }

        /// <summary>Set the second object to compare with the first already loaded.
        /// Side effect: None.
        /// ERRORS: Returns Result.Fail() when parameters are empty or null.</summary>
        /// <param name="secondObjectToCompare">Second object to compare.</param>
        /// <returns>True if objects are equal, False if objects are different (the comparison is done serializing them in Json)</returns>
        public bool TestContentIsEqualToSavedObject(T secondObjectToCompare)
        {
            if (_firstObjectToCompareIsNull & secondObjectToCompare == null)
                return true;

            if (_firstObjectToCompareIsNull == false & secondObjectToCompare == null)
                return false;

            Result<string> secondObjectSerialized = JsonSerializeObject<T>.SerializeObject(secondObjectToCompare);
            if (secondObjectSerialized.IsFailure)
                return false;

            // compare two Json serialized objects for equality
            if (_firstObjectSerialized == secondObjectSerialized.Value)
            { return true; }
            else
            { return false; }
        }
    }
}
