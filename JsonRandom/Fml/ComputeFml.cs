namespace EasyForecast.SymEngine.Fml
{
    public static class ComputeFml
    {
        /// <summary>Compute a number FML.
        /// Side effects: none.
        /// Errors: none.</summary>
        /// <param name="fmlToEvaluate">FML to evaluate</param>
        /// <returns>Return FML evaluated</returns>       
        public static decimal EvaluateNumberFml(string fmlToEvaluate)
        {
            decimal convertedNumber;
            bool parsed = decimal.TryParse(fmlToEvaluate, out convertedNumber);

            if (!parsed)
                convertedNumber = 0;

            return convertedNumber * 10;
        }

        /// <summary>Compute a string FML.
        /// Side effects: none.
        /// Errors: none.</summary>
        /// <param name="fmlToEvaluate">FML to evaluate</param>
        /// <returns>Return FML evaluated</returns>       
        public static string EvaluateStringFml(string fmlToEvaluate)
        {
            if (string.IsNullOrWhiteSpace(fmlToEvaluate))
                return "XXX";

            return fmlToEvaluate + "XXX";
        }

        /// <summary>Compute a date FML.
        /// Side effects: none.
        /// Errors: none.</summary>
        /// <param name="fmlToEvaluate">FML to evaluate</param>
        /// <returns>Return FML evaluated</returns>       
        public static string EvaluateDateFml(string fmlToEvaluate)
        {
            if (string.IsNullOrWhiteSpace(fmlToEvaluate))
                return "XXX";

            return fmlToEvaluate + "XXX";
        }
    }
}
