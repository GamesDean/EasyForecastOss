using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyForecast.SymEngine.Json
{
    class OutputClass
    {
        public class NumColumn
        {
            public string ColumnName { get; set; }
            public IList<int> ColumnContent { get; set; }
        }

        public class StrColumn
        {
            public string ColumnName { get; set; }
            public IList<string> ColumnContent { get; set; }
        }

        public class DateColumn
        {
            public string ColumnName { get; set; }
            public IList<string> ColumnContent { get; set; }
        }

        public class Table
        {
            public string TableName { get; set; }
            public int TableId { get; set; }
            public IList<string> OrderedColumnNames { get; set; }
            public IList<NumColumn> NumColumns { get; set; }
            public IList<StrColumn> StrColumns { get; set; }
            public IList<DateColumn> DateColumns { get; set; }
        }

        public class JsonOutputClass
        {
            public IList<Table> Tables { get; set; }
        }

    }
}
