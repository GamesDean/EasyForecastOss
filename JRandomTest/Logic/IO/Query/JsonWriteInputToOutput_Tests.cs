using Xunit;
using EasyForecast.SymEngine.Logic.IO.Query;
using CSharpFunctionalExtensions;
using EasyForecast.SymEngine.ObjUtils;
using EasyForecast.SymEngine.JsonUtils;
using EasyForecast.SymEngine.Data.IO.Model;
using EasyForecast.SymEngine.Data.IO.Query;
using System.Collections.Generic;

namespace EasyForecast.SymEngine.Tests
{
    // REMEMBER  Test that each pure function does not modify the input parameters

    public class JsonWriteInputToOutput_Tests
    {

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void Write_Test_Success_On_Write()
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
          'ColumnName': 'FmlNumArrayNameXYZ1',
          'ColumnContent': [
            10.0,
            20.0,
            30.0
          ]
        },
        {
          'ColumnName': 'FmlNumArrayNameXYZ2',
          'ColumnContent': [
            10.0,
            20.0,
            30.0
          ]
        }
      ],
      'StrColumns': [
        {
          'ColumnName': 'FmlStrArrayNameXYZ1',
          'ColumnContent': [
            'aXXX',
            'bXXX',
            'cXXX'
          ]
        }
      ],
      'DateColumns': [
        {
          'ColumnName': 'FmlDateArrayNameXYZ1',
          'ColumnContent': [
            '16/09/1977XXX',
            '23/2/1952XXX',
            '18/6/1982XXX',
            '5/12/1945XXX'
          ]
        }
      ]
    }
  ]
}";
            JsonWriteInputToOutput jsonWriteInputToOutput = new JsonWriteInputToOutput();
            Result<JsonInputModel> jsonInputModel = JsonDeserializeObject<JsonInputModel>.DeserializeObject(JsonSampleInputData2);
            // test immutability of input parameters: save phase
            CompareObjectsContent<JsonInputModel> testImmutabilityOf_jsonInputModel = new CompareObjectsContent<JsonInputModel>(jsonInputModel.Value);

            // ACT
            Result<JsonOutputModel> jsonOutputModel = jsonWriteInputToOutput.ComputeFmlAndWriteOutput(jsonInputModel.Value, "Table1", 1);

            // ASSERT
            Assert.True(jsonInputModel.IsSuccess);
            Assert.True(CompareObjectToJsonString.TestContentIsEqual<JsonOutputModel>(jsonOutputModel.Value, sampleObjectSerialized));
            // test immutability of input parameters: test phase
            Assert.True(testImmutabilityOf_jsonInputModel.TestContentIsEqualToSavedObject(jsonInputModel.Value));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void Write_Test_Failure_On_Null_Input()
        {
            // ARRANGE
            JsonWriteInputToOutput jsonWriteInputToOutput = new JsonWriteInputToOutput();
            Result<JsonInputModel> jsonInputModel = JsonDeserializeObject<JsonInputModel>.DeserializeObject(JsonSampleInputData2);

            // ACT
            Result<JsonOutputModel> result1 = jsonWriteInputToOutput.ComputeFmlAndWriteOutput(null, "Table1", 1);
            Result<JsonOutputModel> result2 = jsonWriteInputToOutput.ComputeFmlAndWriteOutput(jsonInputModel.Value, null, 1);
            Result<JsonOutputModel> result3 = jsonWriteInputToOutput.ComputeFmlAndWriteOutput(jsonInputModel.Value, "   ", 1);

            // ASSERT
            Assert.True(jsonInputModel.IsSuccess);
            Assert.True(result1.IsFailure);
            Assert.True(result2.IsFailure);
            Assert.True(result3.IsFailure);
        }
    }
}
