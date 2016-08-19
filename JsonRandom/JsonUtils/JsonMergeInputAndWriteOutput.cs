using CSharpFunctionalExtensions;
using EasyForecast.SymEngine.JsonModels;

namespace EasyForecast.SymEngine.JsonUtils
{
    public class JsonMergeInputAndWriteOutput
    {

        // TODONOW write MergeAndWrite
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public Result<JsonOutputModel> MergeAndWrite(JsonInputModel jsonInput)
        {
            JsonOutputModel jsonOutput = new JsonOutputModel();

            // prendi cicli di copia da 'JsonInputComputeFml'

            return Result.Ok(jsonOutput);
        }
    }
}
