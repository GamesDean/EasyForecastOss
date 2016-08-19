using Xunit;
using CSharpFunctionalExtensions;
using EasyForecast.SymEngine.ObjUtils;
using EasyForecast.SymEngine.JsonUtils;
using EasyForecast.SymEngine.Data.IO.Model;
using EasyForecast.SymEngine.Data.IO.Query;
using System.Collections.Generic;

namespace EasyForecast.SymEngine.Tests
{
    // REMEMBER  Test that each pure function does not modify the input parameters

    public class JsonInputComputeFml_Tests
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
        public void ComputeNumFml_Test_Success_On_Json_Conversion()
        {
            // ARRANGE
            string JsonSampleInputData2_Elaborated = @"[
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
]";
            Result<JsonInputModel> jsonInputModel = JsonDeserializeObject<JsonInputModel>.DeserializeObject(JsonSampleInputData2);
            JsonInputComputeFml jsonInputComputeFml = new JsonInputComputeFml();
            // test immutability of input parameters: save phase
            CompareObjectsContent<JsonInputModel> testImmutabilityOf_jsonInputModel = new CompareObjectsContent<JsonInputModel>(jsonInputModel.Value);

            // ACT
            Result<List<NumColumn>> computeResult = jsonInputComputeFml.ComputeNumFml(jsonInputModel.Value);

            // ASSERT
            Assert.True(computeResult.IsSuccess);
            bool comparisonResult = CompareObjectToJsonString.TestContentIsEqual<List<NumColumn>>(computeResult.Value, JsonSampleInputData2_Elaborated);
            Assert.True(comparisonResult);
            // test immutability of input parameters: test phase
            Assert.True(testImmutabilityOf_jsonInputModel.TestContentIsEqualToSavedObject(jsonInputModel.Value));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void ComputeStrFml_Test_Success_On_Json_Conversion()
        {
            // ARRANGE
            string JsonSampleInputData2_Elaborated = @"[
  {
    'ColumnName': 'FmlStrArrayNameXYZ1',
    'ColumnContent': [
      'aXXX',
      'bXXX',
      'cXXX'
    ]
  }
]";
            Result<JsonInputModel> jsonInputModel = JsonDeserializeObject<JsonInputModel>.DeserializeObject(JsonSampleInputData2);
            JsonInputComputeFml jsonInputComputeFml = new JsonInputComputeFml();
            // test immutability of input parameters: save phase
            CompareObjectsContent<JsonInputModel> testImmutabilityOf_jsonInputModel = new CompareObjectsContent<JsonInputModel>(jsonInputModel.Value);

            // ACT
            Result<List<StrColumn>> computeResult = jsonInputComputeFml.ComputeStrFml(jsonInputModel.Value);

            // ASSERT
            Assert.True(computeResult.IsSuccess);
            bool comparisonResult = CompareObjectToJsonString.TestContentIsEqual<List<StrColumn>>(computeResult.Value, JsonSampleInputData2_Elaborated);
            Assert.True(comparisonResult);
            // test immutability of input parameters: test phase
            Assert.True(testImmutabilityOf_jsonInputModel.TestContentIsEqualToSavedObject(jsonInputModel.Value));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void ComputeDateFml_Test_Success_On_Json_Conversion()
        {
            // ARRANGE
            string JsonSampleInputData2_Elaborated = @"[
  {
    'ColumnName': 'FmlDateArrayNameXYZ1',
    'ColumnContent': [
'16/09/1977XXX', '23/2/1952XXX', '18/6/1982XXX', '5/12/1945XXX'
    ]
  }
]";
            Result<JsonInputModel> jsonInputModel = JsonDeserializeObject<JsonInputModel>.DeserializeObject(JsonSampleInputData2);
            JsonInputComputeFml jsonInputComputeFml = new JsonInputComputeFml();
            // test immutability of input parameters: save phase
            CompareObjectsContent<JsonInputModel> testImmutabilityOf_jsonInputModel = new CompareObjectsContent<JsonInputModel>(jsonInputModel.Value);

            // ACT
            Result<List<DateColumn>> computeResult = jsonInputComputeFml.ComputeDateFml(jsonInputModel.Value);

            // ASSERT
            Assert.True(computeResult.IsSuccess);
            bool comparisonResult = CompareObjectToJsonString.TestContentIsEqual<List<DateColumn>>(computeResult.Value, JsonSampleInputData2_Elaborated);
            Assert.True(comparisonResult);
            // test immutability of input parameters: test phase
            Assert.True(testImmutabilityOf_jsonInputModel.TestContentIsEqualToSavedObject(jsonInputModel.Value));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void ComputeNumFml_Test_Error_On_Input_Parameter()
        {
            // ARRANGE
            JsonInputComputeFml jsonInputComputeFml = new JsonInputComputeFml();

            // ACT
            Result result = jsonInputComputeFml.ComputeNumFml(null);

            // ASSERT
            Assert.True(result.IsFailure);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void ComputeStrFml_Test_Error_On_Input_Parameter()
        {
            // ARRANGE
            JsonInputComputeFml jsonInputComputeFml = new JsonInputComputeFml();

            // ACT
            Result result = jsonInputComputeFml.ComputeStrFml(null);

            // ASSERT
            Assert.True(result.IsFailure);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void ComputeDateFml_Test_Error_On_Input_Parameter()
        {
            // ARRANGE
            JsonInputComputeFml jsonInputComputeFml = new JsonInputComputeFml();

            // ACT
            Result result = jsonInputComputeFml.ComputeDateFml(null);

            // ASSERT
            Assert.True(result.IsFailure);
        }
    }
}
