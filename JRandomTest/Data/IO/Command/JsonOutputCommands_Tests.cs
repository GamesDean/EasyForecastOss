using Xunit;
using EasyForecast.SymEngine.Data.IO.Command;
using EasyForecast.SymEngine.Data.IO.Model;
using CSharpFunctionalExtensions;
using EasyForecast.SymEngine.ObjUtils;

namespace EasyForecast.SymEngine.Tests
{
    // REMEMBER  Test that each pure function does not modify the input parameters

    public class JsonOutputCommands_Tests
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void CreateJsonOutputWithEmptyTables_Test_Success()
        {
            // ARRANGE
            string sampleObjectSerialized = @"
        {
            'Tables': []
        }
            ";
            JsonOutputCommands jsonOutputCommands = new JsonOutputCommands();

            // ACT
            Result<JsonOutputModel> jsonOutputModel = jsonOutputCommands.CreateJsonOutputWithEmptyTables();

            // ASSERT
            Assert.True(jsonOutputModel.IsSuccess);
            Assert.True(CompareObjectToJsonString.TestContentIsEqual<JsonOutputModel>(jsonOutputModel.Value, sampleObjectSerialized));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void AddNumColumnOrAppendValues_Test_AddColumn_Success()
        {
            // ARRANGE
            string sampleObjectSerialized = @"{
  'Tables': [
    {
      'TableName': 'Table1',
      'TableId': 1,
      'OrderedColumnNames': [],
      'NumColumns': [
        {
          'ColumnName': 'Column 1',
          'ColumnContent': [
            10.0,
            20.0,
            30.0,
            40.0,
            50.0,
            60.0
          ]
        },
        {
          'ColumnName': 'Column 4',
          'ColumnContent': [
            40.0,
            50.0,
            60.0
          ]
        }
      ],
      'StrColumns': [
        {
          'ColumnName': 'Column 2',
          'ColumnContent': [
            'a',
            'b',
            'c',
            'd',
            'e',
            'f'
          ]
        },
        {
          'ColumnName': 'Column 5',
          'ColumnContent': [
            'd',
            'e',
            'f'
          ]
        }
      ],
      'DateColumns': [
        {
          'ColumnName': 'Column 3',
          'ColumnContent': [
            '1/1/2015',
            '10/10/2015',
            '31/12/2015',
            '1/1/2016',
            '10/10/2016',
            '31/12/2016'
          ]
        },
        {
          'ColumnName': 'Column 6',
          'ColumnContent': [
            '1/1/2016',
            '10/10/2016',
            '31/12/2016'
          ]
        }
      ]
    }
  ]
}";

            JsonOutputCommands jsonOutputCommands = new JsonOutputCommands();
            
            // ACT
            Result<JsonOutputModel> jsonOutputModel = jsonOutputCommands.CreateJsonOutputWithEmptyTables();
            string tableName = "Table1";
            int tableId = 1;
            Result<Table> table = jsonOutputCommands.ReturnTable(tableName, tableId);
            Result resultAddTable = jsonOutputCommands.AddTable(jsonOutputModel.Value, table.Value);
            string columnName = "Column 1";
            Result<NumColumn> numColumn = jsonOutputCommands.ReturnNumColumn(columnName);
            numColumn.Value.ColumnContent.Add(10);
            numColumn.Value.ColumnContent.Add(20);
            numColumn.Value.ColumnContent.Add(30);
            Result resultAddNumColumn = jsonOutputCommands.AddNumColumnOrAppendValues(jsonOutputModel.Value, tableName, numColumn.Value);
            columnName = "Column 1";
            Result<NumColumn> numColumn2 = jsonOutputCommands.ReturnNumColumn(columnName);
            numColumn2.Value.ColumnContent.Add(40);
            numColumn2.Value.ColumnContent.Add(50);
            numColumn2.Value.ColumnContent.Add(60);
            Result resultAddNumColumn2 = jsonOutputCommands.AddNumColumnOrAppendValues(jsonOutputModel.Value, tableName, numColumn2.Value);
            columnName = "Column 4";
            Result<NumColumn> numColumn3 = jsonOutputCommands.ReturnNumColumn(columnName);
            numColumn3.Value.ColumnContent.Add(40);
            numColumn3.Value.ColumnContent.Add(50);
            numColumn3.Value.ColumnContent.Add(60);
            Result resultAddNumColumn3 = jsonOutputCommands.AddNumColumnOrAppendValues(jsonOutputModel.Value, tableName, numColumn3.Value);
            columnName = "Column 2";
            Result<StrColumn> strColumn = jsonOutputCommands.ReturnStrColumn(columnName);
            strColumn.Value.ColumnContent.Add("a");
            strColumn.Value.ColumnContent.Add("b");
            strColumn.Value.ColumnContent.Add("c");
            Result resultAddStrColumn = jsonOutputCommands.AddStrColumnOrAppendValues(jsonOutputModel.Value, tableName, strColumn.Value);
            columnName = "Column 2";
            Result<StrColumn> strColumn2 = jsonOutputCommands.ReturnStrColumn(columnName);
            strColumn2.Value.ColumnContent.Add("d");
            strColumn2.Value.ColumnContent.Add("e");
            strColumn2.Value.ColumnContent.Add("f");
            Result resultAddStrColumn2 = jsonOutputCommands.AddStrColumnOrAppendValues(jsonOutputModel.Value, tableName, strColumn2.Value);
            columnName = "Column 5";
            Result<StrColumn> strColumn3 = jsonOutputCommands.ReturnStrColumn(columnName);
            strColumn3.Value.ColumnContent.Add("d");
            strColumn3.Value.ColumnContent.Add("e");
            strColumn3.Value.ColumnContent.Add("f");
            Result resultAddStrColumn3 = jsonOutputCommands.AddStrColumnOrAppendValues(jsonOutputModel.Value, tableName, strColumn3.Value);
            columnName = "Column 3";
            Result<DateColumn> dateColumn = jsonOutputCommands.ReturnDateColumn(columnName);
            dateColumn.Value.ColumnContent.Add("1/1/2015");
            dateColumn.Value.ColumnContent.Add("10/10/2015");
            dateColumn.Value.ColumnContent.Add("31/12/2015");
            Result resultAddDateColumn = jsonOutputCommands.AddDateColumnOrAppendValues(jsonOutputModel.Value, tableName, dateColumn.Value);
            columnName = "Column 3";
            Result<DateColumn> dateColumn2 = jsonOutputCommands.ReturnDateColumn(columnName);
            dateColumn2.Value.ColumnContent.Add("1/1/2016");
            dateColumn2.Value.ColumnContent.Add("10/10/2016");
            dateColumn2.Value.ColumnContent.Add("31/12/2016");
            Result resultAddDateColumn2 = jsonOutputCommands.AddDateColumnOrAppendValues(jsonOutputModel.Value, tableName, dateColumn2.Value);
            columnName = "Column 6";
            Result<DateColumn> dateColumn3 = jsonOutputCommands.ReturnDateColumn(columnName);
            dateColumn3.Value.ColumnContent.Add("1/1/2016");
            dateColumn3.Value.ColumnContent.Add("10/10/2016");
            dateColumn3.Value.ColumnContent.Add("31/12/2016");
            Result resultAddDateColumn3 = jsonOutputCommands.AddDateColumnOrAppendValues(jsonOutputModel.Value, tableName, dateColumn3.Value);

            // ASSERT
            Assert.True(table.IsSuccess);
            Assert.True(resultAddTable.IsSuccess);
            Assert.True(numColumn.IsSuccess);
            Assert.True(resultAddNumColumn.IsSuccess);
            Assert.True(numColumn2.IsSuccess);
            Assert.True(resultAddNumColumn2.IsSuccess);
            Assert.True(numColumn3.IsSuccess);
            Assert.True(resultAddNumColumn3.IsSuccess);
            Assert.True(strColumn.IsSuccess);
            Assert.True(resultAddStrColumn.IsSuccess);
            Assert.True(strColumn2.IsSuccess);
            Assert.True(resultAddStrColumn2.IsSuccess);
            Assert.True(strColumn3.IsSuccess);
            Assert.True(resultAddStrColumn3.IsSuccess);
            Assert.True(dateColumn.IsSuccess);
            Assert.True(resultAddDateColumn.IsSuccess);
            Assert.True(dateColumn2.IsSuccess);
            Assert.True(resultAddDateColumn2.IsSuccess);
            Assert.True(dateColumn3.IsSuccess);
            Assert.True(resultAddDateColumn3.IsSuccess);
            Assert.True(CompareObjectToJsonString.TestContentIsEqual<JsonOutputModel>(jsonOutputModel.Value, sampleObjectSerialized));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void ReturnTable_Test_Failure()
        {
            // ARRANGE
            JsonOutputCommands jsonOutputCommands = new JsonOutputCommands();

            // ACT
            Result<Table> table1 = jsonOutputCommands.ReturnTable(" ", 1);
            Result<Table> table2 = jsonOutputCommands.ReturnTable("", 1);
            Result<Table> table3 = jsonOutputCommands.ReturnTable(null, 1);

            // ASSERT
            Assert.True(table1.IsFailure);
            Assert.True(table2.IsFailure);
            Assert.True(table3.IsFailure);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void AddTable_Test_Failure_Table_AlreadyPresent_And_Null()
        {
            // ARRANGE
            JsonOutputCommands jsonOutputCommands = new JsonOutputCommands();

            // ACT
            Result<JsonOutputModel> jsonOutputModel = jsonOutputCommands.CreateJsonOutputWithEmptyTables();
            // Table1
            string tableName = "Table1";
            int tableId = 1;
            Result<Table> table = jsonOutputCommands.ReturnTable(tableName, tableId);
            Result resultAddTable = jsonOutputCommands.AddTable(jsonOutputModel.Value, table.Value);
            // Table1 again
            tableName = "Table1";
            tableId = 1;
            Result<Table> tableAgain = jsonOutputCommands.ReturnTable(tableName, tableId);
            Result resultAddTableAgain = jsonOutputCommands.AddTable(jsonOutputModel.Value, table.Value);
            // Parameters error
            Result resultAddTable1 = jsonOutputCommands.AddTable(null, table.Value);
            Result resultAddTable2 = jsonOutputCommands.AddTable(jsonOutputModel.Value, null);


            // ASSERT
            Assert.True(resultAddTableAgain.IsFailure);
            Assert.True(resultAddTable1.IsFailure);
            Assert.True(resultAddTable2.IsFailure);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void AddNumColumnOrAppendValues_Test_Failures()
        {
            // ARRANGE
            JsonOutputCommands jsonOutputCommands = new JsonOutputCommands();

            // ACT
            Result<JsonOutputModel> jsonOutputModel = jsonOutputCommands.CreateJsonOutputWithEmptyTables();
            string tableName = "Table1";
            int tableId = 1;
            Result<Table> table = jsonOutputCommands.ReturnTable(tableName, tableId);
            Result resultAddTable = jsonOutputCommands.AddTable(jsonOutputModel.Value, table.Value);
            string columnName = "Column 1";
            Result<NumColumn> numColumn = jsonOutputCommands.ReturnNumColumn(columnName);
            numColumn.Value.ColumnContent.Add(10);
            numColumn.Value.ColumnContent.Add(20);
            numColumn.Value.ColumnContent.Add(30);
            // Result resultAddNumColumn = jsonOutputCommands.AddNumColumnOrAppendValues(jsonOutputModel.Value, tableName, numColumn.Value);
            Result resultAddNumColumn1 = jsonOutputCommands.AddNumColumnOrAppendValues(null, tableName, numColumn.Value);
            Result resultAddNumColumn2 = jsonOutputCommands.AddNumColumnOrAppendValues(jsonOutputModel.Value, null, numColumn.Value);
            Result resultAddNumColumn3 = jsonOutputCommands.AddNumColumnOrAppendValues(jsonOutputModel.Value, "", numColumn.Value);
            Result resultAddNumColumn4 = jsonOutputCommands.AddNumColumnOrAppendValues(jsonOutputModel.Value, "    ", numColumn.Value);
            Result resultAddNumColumn5 = jsonOutputCommands.AddNumColumnOrAppendValues(jsonOutputModel.Value, tableName, null);
            Result resultAddNumColumn6 = jsonOutputCommands.AddNumColumnOrAppendValues(jsonOutputModel.Value, "TableNonExistent", numColumn.Value);

            // ASSERT
            Assert.True(resultAddNumColumn1.IsFailure);
            Assert.True(resultAddNumColumn2.IsFailure);
            Assert.True(resultAddNumColumn3.IsFailure);
            Assert.True(resultAddNumColumn4.IsFailure);
            Assert.True(resultAddNumColumn5.IsFailure);
            Assert.True(resultAddNumColumn6.IsFailure);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void AddStrColumnOrAppendValues_Test_Failures()
        {
            // ARRANGE
            JsonOutputCommands jsonOutputCommands = new JsonOutputCommands();

            // ACT
            Result<JsonOutputModel> jsonOutputModel = jsonOutputCommands.CreateJsonOutputWithEmptyTables();
            string tableName = "Table1";
            int tableId = 1;
            Result<Table> table = jsonOutputCommands.ReturnTable(tableName, tableId);
            Result resultAddTable = jsonOutputCommands.AddTable(jsonOutputModel.Value, table.Value);
            string columnName = "Column 2";
            Result<StrColumn> strColumn = jsonOutputCommands.ReturnStrColumn(columnName);
            strColumn.Value.ColumnContent.Add("a");
            strColumn.Value.ColumnContent.Add("b");
            strColumn.Value.ColumnContent.Add("c");
            //Result resultAddStrColumn = jsonOutputCommands.AddStrColumnOrAppendValues(jsonOutputModel.Value, tableName, strColumn.Value);
            Result resultAddStrColumn1 = jsonOutputCommands.AddStrColumnOrAppendValues(null, tableName, strColumn.Value);
            Result resultAddStrColumn2 = jsonOutputCommands.AddStrColumnOrAppendValues(jsonOutputModel.Value, null, strColumn.Value);
            Result resultAddStrColumn3 = jsonOutputCommands.AddStrColumnOrAppendValues(jsonOutputModel.Value, "", strColumn.Value);
            Result resultAddStrColumn4 = jsonOutputCommands.AddStrColumnOrAppendValues(jsonOutputModel.Value, "    ", strColumn.Value);
            Result resultAddStrColumn5 = jsonOutputCommands.AddStrColumnOrAppendValues(jsonOutputModel.Value, tableName, null);
            Result resultAddStrColumn6 = jsonOutputCommands.AddStrColumnOrAppendValues(jsonOutputModel.Value, "TableNonExistent", strColumn.Value);

            // ASSERT
            Assert.True(resultAddStrColumn1.IsFailure);
            Assert.True(resultAddStrColumn2.IsFailure);
            Assert.True(resultAddStrColumn3.IsFailure);
            Assert.True(resultAddStrColumn4.IsFailure);
            Assert.True(resultAddStrColumn5.IsFailure);
            Assert.True(resultAddStrColumn6.IsFailure);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void AddDateColumnOrAppendValues_Test_Failures()
        {
            // ARRANGE
            JsonOutputCommands jsonOutputCommands = new JsonOutputCommands();

            // ACT
            Result<JsonOutputModel> jsonOutputModel = jsonOutputCommands.CreateJsonOutputWithEmptyTables();
            string tableName = "Table1";
            int tableId = 1;
            Result<Table> table = jsonOutputCommands.ReturnTable(tableName, tableId);
            Result resultAddTable = jsonOutputCommands.AddTable(jsonOutputModel.Value, table.Value);
            string columnName = "Column 3";
            Result<DateColumn> dateColumn = jsonOutputCommands.ReturnDateColumn(columnName);
            dateColumn.Value.ColumnContent.Add("1/1/2015");
            dateColumn.Value.ColumnContent.Add("10/10/2015");
            dateColumn.Value.ColumnContent.Add("31/12/2015");
            //Result resultAddDateColumn = jsonOutputCommands.AddDateColumnOrAppendValues(jsonOutputModel.Value, tableName, dateColumn.Value);
            Result resultAddDateColumn1 = jsonOutputCommands.AddDateColumnOrAppendValues(null, tableName, dateColumn.Value);
            Result resultAddDateColumn2 = jsonOutputCommands.AddDateColumnOrAppendValues(jsonOutputModel.Value, null, dateColumn.Value);
            Result resultAddDateColumn3 = jsonOutputCommands.AddDateColumnOrAppendValues(jsonOutputModel.Value, "", dateColumn.Value);
            Result resultAddDateColumn4 = jsonOutputCommands.AddDateColumnOrAppendValues(jsonOutputModel.Value, "    ", dateColumn.Value);
            Result resultAddDateColumn5 = jsonOutputCommands.AddDateColumnOrAppendValues(jsonOutputModel.Value, tableName, null);
            Result resultAddDateColumn6 = jsonOutputCommands.AddDateColumnOrAppendValues(jsonOutputModel.Value, "TableNonExistent", dateColumn.Value);

            // ASSERT
            Assert.True(resultAddDateColumn1.IsFailure);
            Assert.True(resultAddDateColumn2.IsFailure);
            Assert.True(resultAddDateColumn3.IsFailure);
            Assert.True(resultAddDateColumn4.IsFailure);
            Assert.True(resultAddDateColumn5.IsFailure);
            Assert.True(resultAddDateColumn6.IsFailure);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void ReturnNumColumn_Test_Failure()
        {
            // ARRANGE
            JsonOutputCommands jsonOutputCommands = new JsonOutputCommands();

            // ACT
            Result<NumColumn> test1 = jsonOutputCommands.ReturnNumColumn(" ");
            Result<NumColumn> test2 = jsonOutputCommands.ReturnNumColumn("");
            Result<NumColumn> test3 = jsonOutputCommands.ReturnNumColumn(null);

            // ASSERT
            Assert.True(test1.IsFailure);
            Assert.True(test2.IsFailure);
            Assert.True(test3.IsFailure);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void ReturnStrColumn_Test_Failure()
        {
            // ARRANGE
            JsonOutputCommands jsonOutputCommands = new JsonOutputCommands();

            // ACT
            Result<StrColumn> test1 = jsonOutputCommands.ReturnStrColumn(" ");
            Result<StrColumn> test2 = jsonOutputCommands.ReturnStrColumn("");
            Result<StrColumn> test3 = jsonOutputCommands.ReturnStrColumn(null);

            // ASSERT
            Assert.True(test1.IsFailure);
            Assert.True(test2.IsFailure);
            Assert.True(test3.IsFailure);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void ReturnDateColumn_Test_Failure()
        {
            // ARRANGE
            JsonOutputCommands jsonOutputCommands = new JsonOutputCommands();

            // ACT
            Result<DateColumn> test1 = jsonOutputCommands.ReturnDateColumn(" ");
            Result<DateColumn> test2 = jsonOutputCommands.ReturnDateColumn("");
            Result<DateColumn> test3 = jsonOutputCommands.ReturnDateColumn(null);

            // ASSERT
            Assert.True(test1.IsFailure);
            Assert.True(test2.IsFailure);
            Assert.True(test3.IsFailure);
        }
    }
}
