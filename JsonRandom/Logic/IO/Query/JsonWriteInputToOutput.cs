using CSharpFunctionalExtensions;
using EasyForecast.SymEngine.Data.IO.Model;
using System.Collections.Generic;
using EasyForecast.SymEngine.Data.IO.Query;
using EasyForecast.SymEngine.Data.IO.Command;

namespace EasyForecast.SymEngine.Logic.IO.Query
{
    public class JsonWriteInputToOutput
    {

        /// <summary>Compute a FML and return an Output object.
        /// Side effects: none.
        /// ERRORS: Returns Result.Fail() when parameters are empty or null.</summary>
        /// <param name="jsonInput">Input object, source of FML</param>
        /// <param name="outputTableName">Table in which write the computed FML</param>
        /// <param name="outputTableId">ID of the table</param>
        /// <returns>Return object with status.</returns>
        public Result<JsonOutputModel> ComputeFmlAndWriteOutput(JsonInputModel jsonInput, string outputTableName, int outputTableId)
        {
            if (jsonInput == null)
                return Result.Fail<JsonOutputModel>("'jsonInput' is null");
            if (string.IsNullOrWhiteSpace(outputTableName))
                return Result.Fail<JsonOutputModel>("'outputTableName' is empty");

            // compute Fml in Input
            JsonInputComputeFml jsonInputComputeFml = new JsonInputComputeFml();
            Result<List<NumColumn>> computedNumFml = jsonInputComputeFml.ComputeNumFml(jsonInput);
            if (computedNumFml.IsFailure)
                return Result.Fail<JsonOutputModel>("error with 'ComputeNumFml'");
            Result<List<StrColumn>> computedStrFml = jsonInputComputeFml.ComputeStrFml(jsonInput);
            if (computedNumFml.IsFailure)
                return Result.Fail<JsonOutputModel>("error with 'ComputeStrFml'");
            Result<List<DateColumn>> computedDateFml = jsonInputComputeFml.ComputeDateFml(jsonInput);
            if (computedNumFml.IsFailure)
                return Result.Fail<JsonOutputModel>("error with 'ComputeDateFml'");

            JsonOutputCommands jsonOutputCommands = new JsonOutputCommands();

            // initialize Outuput
            Result<JsonOutputModel> jsonOutput = jsonOutputCommands.CreateJsonOutputWithEmptyTables();
            if (jsonOutput.IsFailure)
                return Result.Fail<JsonOutputModel>("error with 'CreateJsonOutputWithEmptyTables'");
            Result<Table> table = jsonOutputCommands.ReturnTable(outputTableName, outputTableId);
            if (table.IsFailure)
                return Result.Fail<JsonOutputModel>("error with 'ReturnTable'");
            Result resultAddTable = jsonOutputCommands.AddTable(jsonOutput.Value, table.Value);
            if (resultAddTable.IsFailure)
                return Result.Fail<JsonOutputModel>("error with 'AddTable'");

            // complete jsonOutput with value from computed*Fml
            foreach (NumColumn element in computedNumFml.Value)
            {
                Result resultAddNumColumn = jsonOutputCommands.AddNumColumnOrAppendValues(jsonOutput.Value, outputTableName, element);
            }
            foreach (StrColumn element in computedStrFml.Value)
            {
                Result resultAddStrColumn = jsonOutputCommands.AddStrColumnOrAppendValues(jsonOutput.Value, outputTableName, element);
            }
            foreach (DateColumn element in computedDateFml.Value)
            {
                Result resultAdddateColumn = jsonOutputCommands.AddDateColumnOrAppendValues(jsonOutput.Value, outputTableName, element);
            }

            return Result.Ok(jsonOutput.Value);
        }
    }
}
