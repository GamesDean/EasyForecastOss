using Newtonsoft.Json;

namespace EasyForecast.SymEngine.JsonUtils
{
    public static class JsonCompareModelToString
    {
        public static bool Compare<T>(T jsonModel, string jsonString)
        {
            // serialize 'JsonModel'
            string jsonInputModelString1 = JsonConvert.SerializeObject(jsonModel);

            // stringa Json che viene deserializzata su specifico oggetto
            // e serializzata per massima sicurezza di confronto
            T JsonModel2 = JsonConvert.DeserializeObject<T>(jsonString);
            string jsonInputModelString2 = JsonConvert.SerializeObject(JsonModel2);

            // compare two Json strings for equal
            if (jsonInputModelString1 == jsonInputModelString2)
            { return true; }
            else
            { return false; }
        }
    }
}
