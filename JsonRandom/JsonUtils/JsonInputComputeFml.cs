using CSharpFunctionalExtensions;
using EasyForecast.SymEngine.JsonModels;

namespace EasyForecast.SymEngine.JsonUtils
{
    public class JsonInputComputeFml
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public Result ComputeFml(JsonInputModel jsonInput)
        {
            if (jsonInput == null)
                return Result.Fail("input paramater is null");

            // 'Evaluate' FmlNumParameters: multiply elements by 10
            for (int FecC = 0; FecC < jsonInput.FECs.Count; FecC+=1)
            {
                for (int ParC = 0; ParC < jsonInput.FECs[FecC].FmlNumParameters.Count; ParC += 1)
                {
                    for (int ArrC = 0; ArrC < jsonInput.FECs[FecC].FmlNumParameters[ParC].ArrayContent.Count; ArrC += 1)
                    {
                        jsonInput.FECs[FecC].FmlNumParameters[ParC].ArrayContent[ArrC] = jsonInput.FECs[FecC].FmlNumParameters[ParC].ArrayContent[ArrC] * 10;
                    }
                }
            }

            // 'Evaluate' FmlStrParameters: add "xxx" to elements
            for (int FecC = 0; FecC < jsonInput.FECs.Count; FecC += 1)
            {
                for (int ParC = 0; ParC < jsonInput.FECs[FecC].FmlStrParameters.Count; ParC += 1)
                {
                    for (int ArrC = 0; ArrC < jsonInput.FECs[FecC].FmlStrParameters[ParC].ArrayContent.Count; ArrC += 1)
                    {
                        jsonInput.FECs[FecC].FmlStrParameters[ParC].ArrayContent[ArrC] = jsonInput.FECs[FecC].FmlStrParameters[ParC].ArrayContent[ArrC] + "XXX";
                    }
                }
            }

            // 'Evaluate' FmlDateParameters: add "xxx" to elements
            for (int FecC = 0; FecC < jsonInput.FECs.Count; FecC += 1)
            {
                for (int ParC = 0; ParC < jsonInput.FECs[FecC].FmlDateParameters.Count; ParC += 1)
                {
                    for (int ArrC = 0; ArrC < jsonInput.FECs[FecC].FmlDateParameters[ParC].ArrayContent.Count; ArrC += 1)
                    {
                        jsonInput.FECs[FecC].FmlDateParameters[ParC].ArrayContent[ArrC] = jsonInput.FECs[FecC].FmlDateParameters[ParC].ArrayContent[ArrC] + "XXX";
                    }
                }
            }

            return Result.Ok();

        }

    }
}
