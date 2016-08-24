using System;
using Xunit;
using EasyForecast.SymEngine.Data.IO.Command;
using EasyForecast.SymEngine.Data.IO.Model;
using EasyForecast.SymEngine.Logic.IO.Query;
using EasyForecast.SymEngine.Data.IO.Query;
using CSharpFunctionalExtensions;
using EasyForecast.SymEngine.JsonUtils;
using EasyForecast.SymEngine.FileIO;
using EasyForecast.SymEngine.Tests.Constants;
using System.Collections.Generic;


namespace EasyForecast.SymEngine.Tests
{
    // Test used to generate Json from objects (to be used in a string)

    public class aaaGenerateJsonFromObject
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void Generate()
        {
            /*
                        // DEFINE OBJECT
                        JsonOutputCommands jsonOutputCommands = new JsonOutputCommands();
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

                        // SERIALIZE OBJECT
                        Result<string> serializedObject = JsonSerializeObject<JsonOutputModel>.SerializeObject(jsonOutputModel.Value, true);
                        Assert.True(serializedObject.IsSuccess);

                        // REPLACE " WITH '
                        string serializedObjectString = serializedObject.Value.Replace("\"", "'");

                        // WRITE SERIALIZED OBJECT TO FILE
                        Result fileWrite = WriteFile.WriteStringToFile(serializedObjectString, Environment.CurrentDirectory + FileConstants.TestDataPath + FileConstants.JsonSampleSerializedObjectFromTestsFileName);
                        Assert.True(fileWrite.IsSuccess);

            */


            string JsonSampleInputData2 = @"
        {
            'FECs': [{
                'FecName': 'FecNameXYZ',
                'FecId': 1,
                'OrderedParameterNames': ['NumArrayNameXYZ1', 'StrArrayNameXYZ1', 'NumArrayNameXYZ2', '...and other parameter names...'],
                'NumParameters': [{
                    'ArrayName': 'NumArrayNameXYZ1',
                    'ArrayContent': [1, 2, 3, 4, 5, 6, 7, 8, 9]
                }],
                'StrParameters': [{
                    'ArrayName': 'StrArrayNameXYZ1',
                    'ArrayContent': ['a', 'b', 'c']
                }],
                'DateParameters': [{
                    'ArrayName': 'DateArrayNameXYZ1',
                    'ArrayContent': ['16/09/1977', '23/2/1952', '18/6/1982', '5/12/1945']
                }],
                'FmlNumParameters': [{
                    'ArrayName': 'FmlNumArrayNameXYZ1',
                    'ArrayContent': ['1', '2', '3']
                }, {
                    'ArrayName': 'FmlNumArrayNameXYZ2',
                    'ArrayContent': ['1', '2', '3']
                }],
                'FmlStrParameters': [{
                    'ArrayName': 'FmlStrArrayNameXYZ1',
                    'ArrayContent': ['a', 'b', 'c']
                }],
                'FmlDateParameters': [{
                    'ArrayName': 'FmlDateArrayNameXYZ1',
                    'ArrayContent': ['16/09/1977', '23/2/1952', '18/6/1982', '5/12/1945']
                }]
            }]
        }
            ";


            // DEFINE OBJECT
            JsonWriteInputToOutput jsonWriteInputToOutput = new JsonWriteInputToOutput();
            Result<JsonInputModel> jsonInputModel = JsonDeserializeObject<JsonInputModel>.DeserializeObject(JsonSampleInputData2);
            Result<JsonOutputModel> jsonOutputModel = jsonWriteInputToOutput.ComputeFmlAndWriteOutput(jsonInputModel.Value, "Table1", 1);

            // SERIALIZE OBJECT
            Result<string> serializedObject = JsonSerializeObject<JsonOutputModel>.SerializeObject(jsonOutputModel.Value, true);
            Assert.True(serializedObject.IsSuccess);

            // REPLACE " WITH '
            string serializedObjectString = serializedObject.Value.Replace("\"", "'");

            // WRITE SERIALIZED OBJECT TO FILE
            Result fileWrite = WriteFile.WriteStringToFile(serializedObjectString, Environment.CurrentDirectory + FileConstants.TestDataPath + FileConstants.JsonSampleSerializedObjectFromTestsFileName);
            Assert.True(fileWrite.IsSuccess);
        }


    }
}
