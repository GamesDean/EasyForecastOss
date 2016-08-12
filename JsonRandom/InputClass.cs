using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyForecast.SymEngine.Json
{
    public class InputClass
    {
        // TODO: if useful implement suggestion of rule "CA2227: Collection properties should be read only" https://msdn.microsoft.com/library/ms182327.aspx?cs-save-lang=1&cs-lang=csharp )
        public class NumParameter
        {
            public string ArrayName { get; set; }
            public IList<int> ArrayContent { get; set; }
        }

        public class StrParameter
        {
            public string ArrayName { get; set; }
            public IList<string> ArrayContent { get; set; }
        }

        public class DateParameter
        {
            public string ArrayName { get; set; }
            public IList<string> ArrayContent { get; set; }
        }

        public class FmlNumParameter
        {
            public string ArrayName { get; set; }
            public IList<int> ArrayContent { get; set; }
        }

        public class FmlStrParameter
        {
            public string ArrayName { get; set; }
            public IList<string> ArrayContent { get; set; }
        }

        public class FmlDateParameter
        {
            public string ArrayName { get; set; }
            public IList<string> ArrayContent { get; set; }
        }

        public class FEC
        {
            public string FecName { get; set; }
            public int FecId { get; set; }
            public IList<string> OrderedParameterNames { get; set; }
            public IList<NumParameter> NumParameters { get; set; }
            public IList<StrParameter> StrParameters { get; set; }
            public IList<DateParameter> DateParameters { get; set; }
            public IList<FmlNumParameter> FmlNumParameters { get; set; }
            public IList<FmlStrParameter> FmlStrParameters { get; set; }
            public IList<FmlDateParameter> FmlDateParameters { get; set; }
        }

        public class JsonInputClass
        {
            public IList<FEC> FECs { get; set; }
        }
    }
}
