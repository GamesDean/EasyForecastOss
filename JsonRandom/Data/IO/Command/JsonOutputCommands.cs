using System;
using CSharpFunctionalExtensions;
using EasyForecast.SymEngine.Data.IO.Model;
using System.Collections.Generic;

namespace EasyForecast.SymEngine.Data.IO.Command
{
    public class JsonOutputCommands
    {
        // TODO add Dictionary commands (after having modified List in Dictionary in Output EasyForecast.SymEngine.Data.IO.Model)

        /// <summary>Create Json Output With Empty Tables.
        /// Side effects: none.
        /// Errors: none.</summary>
        /// <returns>Result with 'JsonOutputModel'.</returns>
        public Result<JsonOutputModel> CreateJsonOutputWithEmptyTables()
        {
            JsonOutputModel jsonOutputModel = new JsonOutputModel();

            jsonOutputModel.Tables = new List<Table>();

            return Result.Ok(jsonOutputModel);
        }

        /// <summary>Return a table to be used inside Json Output.
        /// Side effects: none.
        /// ERRORS: Result.Fail() when 'tableName' is empty.</summary>
        /// <param name="tableName">name of the table to create.</param>
        /// <param name="tableId">id of the table to create.</param>
        /// <returns>Result with Table.</returns>
        public Result<Table> ReturnTable(string tableName, int tableId)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                return Result.Fail<Table>("'tableName' is empty");

            Table table = new Table();
            table.TableName = tableName;
            table.TableId = tableId;
            table.OrderedColumnNames = new List<string>();
            table.NumColumns = new List<NumColumn>();
            table.StrColumns = new List<StrColumn>();
            table.DateColumns = new List<DateColumn>();

            return Result.Ok(table);
        }

        /// <summary>Add a table to the output model.
        /// SIDE EFFECTS: Change input parameter 'jsonOutputModel'.
        /// ERRORS: Result.Fail() when parameters are null/empty.</summary>
        /// <param name="JsonOutputModel">Output model to modify</param>
        /// <param name="table">Table object to add</param>
        /// <returns>Return status.</returns>
        public Result AddTable(JsonOutputModel jsonOutputModel, Table table)
        {
            if (jsonOutputModel == null)
                return Result.Fail("'jsonOutputModel' is null");

            if (table == null)
                return Result.Fail("'table' is null");

            string nameOfTableToAdd= table.TableName;

            // search table name, exit with error if found
            for (int i = 0; i < jsonOutputModel.Tables.Count; i += 1)
            {
                if (jsonOutputModel.Tables[i].TableName == nameOfTableToAdd)
                {
                    return Result.Fail("'table' is already present");
                }
            }

            jsonOutputModel.Tables.Add(table);

            return Result.Ok();
        }

        /// <summary>Add a numeric column or Append values to an already existing column.
        /// SIDE EFFECTS: Change input parameter 'jsonOutputModel'.
        /// ERRORS: Result.Fail() when parameters are null/empty.</summary>
        /// <param name="jsonOutputModel">Output model to modify</param>
        /// <param name="tableName">Name of the table to append to write in.</param>
        /// <param name="column">Column object to add/append.</param>
        /// <returns>Return status.</returns>
        public Result AddNumColumnOrAppendValues(JsonOutputModel jsonOutputModel, string tableName, NumColumn column)
        {
            if (jsonOutputModel == null)
                return Result.Fail("'jsonOutputModel' is null");

            if (string.IsNullOrWhiteSpace(tableName))
                return Result.Fail<NumColumn>("'tableName' is empty");

            if (column == null)
                return Result.Fail("'column' is null");

            string nameOfColumnToAddOrAppend = column.ColumnName;
            int positionOfTableToEditFound = -1;
            int positionOfColumnNameToAddOrAppendFound = -1;

            // search table name
            for (int i = 0; i < jsonOutputModel.Tables.Count; i += 1)
            {
                if (jsonOutputModel.Tables[i].TableName == tableName)
                {
                    positionOfTableToEditFound = i;
                    break;
                }
            }

            if (positionOfTableToEditFound == -1)
            { return Result.Fail("'tableName' not found"); }

            // search column name
            for (int i = 0; i < jsonOutputModel.Tables[positionOfTableToEditFound].NumColumns.Count; i += 1)
            {
                if (jsonOutputModel.Tables[positionOfTableToEditFound].NumColumns[i].ColumnName == nameOfColumnToAddOrAppend)
                {
                    positionOfColumnNameToAddOrAppendFound = i;
                    break;
                }
            }

            // the column was found, append values
            if (positionOfColumnNameToAddOrAppendFound != -1)
            {
                for (int i = 0; i < column.ColumnContent.Count; i += 1)
                {
                    jsonOutputModel.Tables[positionOfTableToEditFound].NumColumns[positionOfColumnNameToAddOrAppendFound].ColumnContent.Add(column.ColumnContent[i]);
                }
            }
            // the column was NOT found, add a column
            else
            {
                jsonOutputModel.Tables[positionOfTableToEditFound].NumColumns.Add(column);
            }

            return Result.Ok();
        }

        /// <summary>Add a string column or Append values to an already existing column.
        /// SIDE EFFECTS: Change input parameter 'jsonOutputModel'.
        /// ERRORS: Result.Fail() when parameters are null/empty.</summary>
        /// <param name="jsonOutputModel">Output model to modify</param>
        /// <param name="tableName">Name of the table to append to write in.</param>
        /// <param name="column">Column object to add/append.</param>
        /// <returns>Return status.</returns>        
        public Result AddStrColumnOrAppendValues(JsonOutputModel jsonOutputModel, string tableName, StrColumn column)
        {
            if (jsonOutputModel == null)
                return Result.Fail("'jsonOutputModel' is null");

            if (string.IsNullOrWhiteSpace(tableName))
                return Result.Fail<NumColumn>("'tableName' is empty");

            if (column == null)
                return Result.Fail("'column' is null");

            string nameOfColumnToAddOrAppend = column.ColumnName;
            int positionOfTableToEditFound = -1;
            int positionOfColumnNameToAddOrAppendFound = -1;

            // search table name
            for (int i = 0; i < jsonOutputModel.Tables.Count; i += 1)
            {
                if (jsonOutputModel.Tables[i].TableName == tableName)
                {
                    positionOfTableToEditFound = i;
                    break;
                }
            }

            if (positionOfTableToEditFound == -1)
            { return Result.Fail("'tableName' not found"); }

            // search column name
            for (int i = 0; i < jsonOutputModel.Tables[positionOfTableToEditFound].StrColumns.Count; i += 1)
            {
                if (jsonOutputModel.Tables[positionOfTableToEditFound].StrColumns[i].ColumnName == nameOfColumnToAddOrAppend)
                {
                    positionOfColumnNameToAddOrAppendFound = i;
                    break;
                }
            }

            // the column was found, append values
            if (positionOfColumnNameToAddOrAppendFound != -1)
            {
                for (int i = 0; i < column.ColumnContent.Count; i += 1)
                {
                    jsonOutputModel.Tables[positionOfTableToEditFound].StrColumns[positionOfColumnNameToAddOrAppendFound].ColumnContent.Add(column.ColumnContent[i]);
                }
            }
            // the column was NOT found, add a column
            else
            {
                jsonOutputModel.Tables[positionOfTableToEditFound].StrColumns.Add(column);
            }

            return Result.Ok();
        }

        /// <summary>Add a date column or Append values to an already existing column.
        /// SIDE EFFECTS: Change input parameter 'jsonOutputModel'.
        /// ERRORS: Result.Fail() when parameters are null/empty.</summary>
        /// <param name="jsonOutputModel">Output model to modify</param>
        /// <param name="tableName">Name of the table to append to write in.</param>
        /// <param name="column">Column object to add/append.</param>
        /// <returns>Return status.</returns>        
        public Result AddDateColumnOrAppendValues(JsonOutputModel jsonOutputModel, string tableName, DateColumn column)
        {
            if (jsonOutputModel == null)
                return Result.Fail("'jsonOutputModel' is null");

            if (string.IsNullOrWhiteSpace(tableName))
                return Result.Fail<NumColumn>("'tableName' is empty");

            if (column == null)
                return Result.Fail("'column' is null");

            string nameOfColumnToAddOrAppend = column.ColumnName;
            int positionOfTableToEditFound = -1;
            int positionOfColumnNameToAddOrAppendFound = -1;

            // search table name
            for (int i = 0; i < jsonOutputModel.Tables.Count; i += 1)
            {
                if (jsonOutputModel.Tables[i].TableName == tableName)
                {
                    positionOfTableToEditFound = i;
                    break;
                }
            }

            if (positionOfTableToEditFound == -1)
            { return Result.Fail("'tableName' not found"); }

            // search column name
            for (int i = 0; i < jsonOutputModel.Tables[positionOfTableToEditFound].DateColumns.Count; i += 1)
            {
                if (jsonOutputModel.Tables[positionOfTableToEditFound].DateColumns[i].ColumnName == nameOfColumnToAddOrAppend)
                {
                    positionOfColumnNameToAddOrAppendFound = i;
                    break;
                }
            }

            // the column was found, append values
            if (positionOfColumnNameToAddOrAppendFound != -1)
            {
                for (int i = 0; i < column.ColumnContent.Count; i += 1)
                {
                    jsonOutputModel.Tables[positionOfTableToEditFound].DateColumns[positionOfColumnNameToAddOrAppendFound].ColumnContent.Add(column.ColumnContent[i]);
                }
            }
            // the column was NOT found, add a column
            else
            {
                jsonOutputModel.Tables[positionOfTableToEditFound].DateColumns.Add(column);
            }

            return Result.Ok();
        }

        /// <summary>Return a column object (NumColumn).
        /// Side effects: none.
        /// ERRORS: Result.Fail() when parameters are null/empty.</summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>Return status with object.</returns>        
        public Result<NumColumn> ReturnNumColumn(string columnName)
        {
            if (string.IsNullOrWhiteSpace(columnName))
                return Result.Fail<NumColumn>("'columnName' is empty");

            NumColumn numColumn = new NumColumn();
            numColumn.ColumnName = columnName;
            numColumn.ColumnContent = new List<decimal>();

            return Result.Ok(numColumn);
        }

        /// <summary>Return a column object (StrColumn).
        /// Side effects: none.
        /// ERRORS: Result.Fail() when parameters are null/empty.</summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>Return status with object.</returns>        
        public Result<StrColumn> ReturnStrColumn(string columnName)
        {
            if (string.IsNullOrWhiteSpace(columnName))
                return Result.Fail<StrColumn>("'columnName' is empty");

            StrColumn strColumn = new StrColumn();
            strColumn.ColumnName = columnName;
            strColumn.ColumnContent = new List<string>();

            return Result.Ok(strColumn);
        }

        /// <summary>Return a column object (DateColumn).
        /// Side effects: none.
        /// ERRORS: Result.Fail() when parameters are null/empty.</summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>Return status with object.</returns>        
        public Result<DateColumn> ReturnDateColumn(string columnName)
        {
            if (string.IsNullOrWhiteSpace(columnName))
                return Result.Fail<DateColumn>("'columnName' is empty");

            DateColumn dateColumn = new DateColumn();
            dateColumn.ColumnName = columnName;
            dateColumn.ColumnContent = new List<string>();

            return Result.Ok(dateColumn);
        }
    }
}
