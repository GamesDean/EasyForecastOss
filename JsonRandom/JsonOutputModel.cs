using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyForecast.SymEngine.Json
{
    // TODO: if useful modify IList<> properties implementing suggestion of rule "CA2227: Collection properties should be read only" https://msdn.microsoft.com/library/ms182327.aspx?cs-save-lang=1&cs-lang=csharp )
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
