using CSharpFunctionalExtensions;
using EasyForecast.SymEngine.Data.Model.IO;
using System.Collections.Generic;

namespace EasyForecast.SymEngine.Data.Command.IO
{
    public static class JsonOutputCommands
    {
        // TODONOW PIPPO add commands to append element to a Column searched by name
        // TODO add Dictionary commands (after having modified List in Dictionary in Output EasyForecast.SymEngine.Data.Model.IO)

        public static Result<JsonOutputModel> CreateJsonOutputWithEmptyTables()
        {
            JsonOutputModel jsonOutputModel = new JsonOutputModel();

            jsonOutputModel.Tables = new List<Table>();

            return Result.Ok(jsonOutputModel);
        }

        public static Result AddTable(JsonOutputModel jsonOutputModel, string tableName)
        {
            Table table = new Table();
            table.TableName = tableName;
            table.TableId = 1;
            table.OrderedColumnNames = new List<string>();
            table.NumColumns = new List<NumColumn>();
            table.StrColumns = new List<StrColumn>();
            table.DateColumns = new List<DateColumn>();

            return Result.Ok();
        }

        public static Result AddNumColumn(List<NumColumn> numColumns, string ColumnName)
        {
            NumColumn numColumn = new NumColumn();
            numColumn.ColumnName = ColumnName;
            numColumn.ColumnContent = new List<decimal>();

            numColumns.Add(numColumn);

            return Result.Ok();
        }

        public static Result AddStrColumn(List<StrColumn> strColumns, string ColumnName)
        {
            StrColumn strColumn = new StrColumn();
            strColumn.ColumnName = ColumnName;
            strColumn.ColumnContent = new List<string>();

            strColumns.Add(strColumn);

            return Result.Ok();
        }

        public static Result AddDateColumn(List<DateColumn> dateColumns, string ColumnName)
        {
            DateColumn dateColumn = new DateColumn();
            dateColumn.ColumnName = ColumnName;
            dateColumn.ColumnContent = new List<string>();

            dateColumns.Add(dateColumn);

            return Result.Ok();
        }
    }
}
