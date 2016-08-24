using CSharpFunctionalExtensions;
using EasyForecast.SymEngine.Data.IO.Model;
using System.Collections.Generic;

namespace EasyForecast.SymEngine.Data.IO.Query
{
    public class JsonInputComputeFml
    {

        /// <summary>Compute FML contained in all NumColumn of a JsonInputModel object.
        /// Side effects: none.
        /// ERRORS: Result.Fail() when parameters are null/empty.</summary>
        /// <param name="jsonInput">Input object to read</param>
        /// <returns>Return status with object.</returns>       
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public Result<List<NumColumn>> ComputeNumFml(JsonInputModel jsonInput)
        {
            if (jsonInput == null)
                return Result.Fail<List<NumColumn>>("input paramater is null");

            List<NumColumn> evaluatedParameters = new List<NumColumn>();

            // Evaluate Fml Parameters and append to 'evaluatedParameters'
            for (int FecC = 0; FecC < jsonInput.FECs.Count; FecC+=1)
            {
                for (int ParC = 0; ParC < jsonInput.FECs[FecC].FmlNumParameters.Count; ParC += 1)
                {
                    // in 'parameterEvaluated' we will store the evaluation of an element of Fml*Parameters[], and then we append it in evaluatedParameters[]
                    NumColumn parameterEvaluated = new NumColumn();
                    parameterEvaluated.ColumnName = jsonInput.FECs[FecC].FmlNumParameters[ParC].ArrayName;
                    parameterEvaluated.ColumnContent = new List<decimal>();
                    for (int ArrC = 0; ArrC < jsonInput.FECs[FecC].FmlNumParameters[ParC].ArrayContent.Count; ArrC += 1)
                    {
                        parameterEvaluated.ColumnContent.Add(Fml.ComputeFml.EvaluateNumberFml(jsonInput.FECs[FecC].FmlNumParameters[ParC].ArrayContent[ArrC]));
                    }
                    evaluatedParameters.Add(parameterEvaluated);
                }
            }
            return Result.Ok(evaluatedParameters);
        }

        /// <summary>Compute FML contained in all StrColumn of a JsonInputModel object.
        /// Side effects: none.
        /// ERRORS: Result.Fail() when parameters are null/empty.</summary>
        /// <param name="jsonInput">Input object to read</param>
        /// <returns>Return status with object.</returns>       
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public Result<List<StrColumn>> ComputeStrFml(JsonInputModel jsonInput)
        {
            if (jsonInput == null)
                return Result.Fail<List<StrColumn>>("input paramater is null");

            List<StrColumn> evaluatedParameters = new List<StrColumn>();

            // Evaluate Fml Parameters and append to 'evaluatedParameters'
            for (int FecC = 0; FecC < jsonInput.FECs.Count; FecC += 1)
            {
                for (int ParC = 0; ParC < jsonInput.FECs[FecC].FmlStrParameters.Count; ParC += 1)
                {
                    // in 'parameterEvaluated' we will store the evaluation of an element of Fml*Parameters[], and then we append it in evaluatedParameters[]
                    StrColumn parameterEvaluated = new StrColumn();
                    parameterEvaluated.ColumnName = jsonInput.FECs[FecC].FmlStrParameters[ParC].ArrayName;
                    parameterEvaluated.ColumnContent = new List<string>();
                    for (int ArrC = 0; ArrC < jsonInput.FECs[FecC].FmlStrParameters[ParC].ArrayContent.Count; ArrC += 1)
                    {
                        parameterEvaluated.ColumnContent.Add(Fml.ComputeFml.EvaluateStringFml(jsonInput.FECs[FecC].FmlStrParameters[ParC].ArrayContent[ArrC]));
                    }
                    evaluatedParameters.Add(parameterEvaluated);
                }
            }
            return Result.Ok(evaluatedParameters);
        }

        /// <summary>Compute FML contained in all DateColumn of a JsonInputModel object.
        /// Side effects: none.
        /// ERRORS: Result.Fail() when parameters are null/empty.</summary>
        /// <param name="jsonInput">Input object to read</param>
        /// <returns>Return status with object.</returns>       
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public Result<List<DateColumn>> ComputeDateFml(JsonInputModel jsonInput)
        {
            if (jsonInput == null)
                return Result.Fail<List<DateColumn>>("input paramater is null");

            List<DateColumn> evaluatedParameters = new List<DateColumn>();

            // Evaluate Fml Parameters and append to 'evaluatedParameters'
            for (int FecC = 0; FecC < jsonInput.FECs.Count; FecC += 1)
            {
                for (int ParC = 0; ParC < jsonInput.FECs[FecC].FmlDateParameters.Count; ParC += 1)
                {
                    // in 'parameterEvaluated' we will store the evaluation of an element of Fml*Parameters[], and then we append it in evaluatedParameters[]
                    DateColumn parameterEvaluated = new DateColumn();
                    parameterEvaluated.ColumnName = jsonInput.FECs[FecC].FmlDateParameters[ParC].ArrayName;
                    parameterEvaluated.ColumnContent = new List<string>();
                    for (int ArrC = 0; ArrC < jsonInput.FECs[FecC].FmlDateParameters[ParC].ArrayContent.Count; ArrC += 1)
                    {
                        parameterEvaluated.ColumnContent.Add(Fml.ComputeFml.EvaluateDateFml(jsonInput.FECs[FecC].FmlDateParameters[ParC].ArrayContent[ArrC]));
                    }
                    evaluatedParameters.Add(parameterEvaluated);
                }
            }

            return Result.Ok(evaluatedParameters);
        }
    }
}
