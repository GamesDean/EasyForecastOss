using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyForecast.SymEngine.Json
{
    class JsonOutput
    {

        /// <summary>
        /// Those variable contains the NumColumns.ColumnName field name,of the json output file
        /// </summary>

        private static string numColumnNameXYZ1 = "'NumColumnNameXYZ1'";
        public string NumColumnNameXYZ1
        {
            get { return numColumnNameXYZ1; }
            set { numColumnNameXYZ1 = value; }
        }

        private static string numColumnNameXYZ2 = "'NumColumnNameXYZ2'";
        public string NumColumnNameXYZ2
        {
            get { return numColumnNameXYZ2; }
            set { numColumnNameXYZ2 = value; }
        }

        private static string numColumnNameXYZ3 = "'NumColumnNameXYZ3'";
        public string NumColumnNameXYZ3
        {
            get { return numColumnNameXYZ3; }
            set { numColumnNameXYZ3 = value; }
        }

        /// <summary>
        /// Those variable contains the NumParameters.ArrayName field name,of the json input file
        /// </summary>

        private static string numArrayNameXYZ1 = "'NumArrayNameXYZ1'";
        public string NumArrayNameXYZ1
        {
            get { return numArrayNameXYZ1; }
            set { numArrayNameXYZ1 = value; }
        }

        private static string numArrayNameXYZ2 = "'NumArrayNameXYZ2'";
        public string NumArrayNameXYZ2
        {
            get { return numArrayNameXYZ2; }
            set { numArrayNameXYZ2 = value; }
        }

        private static string numArrayNameXYZ3 = "'NumArrayNameXYZ3'";
        public string NumArrayNameXYZ3
        {
            get { return numArrayNameXYZ3; }
            set { numArrayNameXYZ3 = value; }
        }

        private JsonInput jInput = new JsonInput();

        /// <summary>
        /// Purpose:Writes the shuffled values into the output json file
        /// Name : Jreplace
        /// Output/Return : a string 
        /// Side Effects : none
        /// Error case : the values passed as parameter must not be null  
        /// </summary>
        /// <param name="numArrayName"></param>
        /// <param name="numColumnName"></param>

        public string Jreplace(JToken input, string numArrayName, string numColumnName, JToken output)
        {

            int[] fieldValue = jInput.GetFecFieldValues(numArrayName, input);
            double[] shuffledValues = jInput.PowCalculator(fieldValue);

            for (int i = 0; i < shuffledValues.Length; i++)
            {
                double valueShuffled = shuffledValues[i];
                int n = 0;
                if (numColumnName.Equals(numColumnNameXYZ1)) { n = 0; }
                if (numColumnName.Equals(numColumnNameXYZ2)) { n = 1; }
                if (numColumnName.Equals(numColumnNameXYZ3)) { n = 2; }

                output["Tables"][0]["NumColumns"][n]["ColumnContent"][i] = valueShuffled;
            }
            string outputFec = JsonConvert.SerializeObject(output, Formatting.Indented);
            return outputFec;

        }


    }

}






