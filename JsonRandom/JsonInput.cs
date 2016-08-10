using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyForecast.SymEngine.Json
{

    public class JsonInput
    {



        /// <summary>
        /// Purpose:Get selected values from FECs.NumParameters.NumArrayXYZ'n'.ArrayContent
        /// Name : GetFecFieldValues
        /// Output/Return : a string array
        /// Side Effects : none
        /// Error case : the value passed as parameter must not be null
        /// </summary>
        /// <param name="numArrayName"></param>
        /// <returns>
        /// int[]
        /// </returns>

        public int[] GetFecFieldValues(string numArrayName, JToken input)
        {

            JToken arrayContent = input.SelectToken("$.FECs..NumParameters[?(@.ArrayName==" + numArrayName + ")].ArrayContent");

            List<int> fList = new List<int>();

            foreach (JToken item in arrayContent)
            {
                fList.Add((int)item);
            }

            int[] values = fList.ToArray();
            return values;

        }

        /// <summary>
        /// Purpose:Shuffles the values stored into the array passed as parameter
        /// Name : Shuffle
        /// Output/Return : a string array
        /// Side Effects : none
        /// Error case : the array passed as parameter must not be null/empty
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>

        public int[] Shuffle(int[] values)
        {
            int[] shuffled = values.OrderBy(n => Guid.NewGuid()).ToArray();
            return shuffled;
        }


    }

}