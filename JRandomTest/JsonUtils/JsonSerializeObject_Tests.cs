using Xunit;
using EasyForecast.SymEngine.JsonUtils;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EasyForecast.SymEngine.ObjUtils;
using CSharpFunctionalExtensions;

namespace EasyForecast.SymEngine.Tests
{
    // REMEMBER  Test that each pure function does not modify the input parameters

    public class JsonSerializeObject_Tests
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void SerializeObject_Test_Success_On_Serialization_With_IndentedFormat()
        {
            // ARRANGE
            string serializedObject = "{\r\n  \"Collection\": [\r\n    \"ABC\",\r\n    \"DEF\"\r\n  ],\r\n  \"List\": [\r\n    \"ABC\",\r\n    \"DEF\"\r\n  ],\r\n  \"ReadOnlyCollection\": [\r\n    \"ABC\",\r\n    \"DEF\"\r\n  ]\r\n}";
            ObjectToSerialize objectToSerialize = new ObjectToSerialize();
            // test immutability of input parameters: save phase
            CompareObjectsContent<ObjectToSerialize> testImmutabilityOf_objectToSerialize = new CompareObjectsContent<ObjectToSerialize>(objectToSerialize);

            // ACT
            Result<string> result = JsonSerializeObject<ObjectToSerialize>.SerializeObject(objectToSerialize, true);

            // ASSERT
            Assert.True(result.IsSuccess);
            Assert.Equal(serializedObject, result.Value);
            // test immutability of input parameters: test phase
            Assert.True(testImmutabilityOf_objectToSerialize.TestContentIsEqualToSavedObject(objectToSerialize));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void SerializeObject_Test_Success_On_Serialization_Without_IndentedFormat()
        {
            // ARRANGE
            string serializedObject = "{\"Collection\":[\"ABC\",\"DEF\"],\"List\":[\"ABC\",\"DEF\"],\"ReadOnlyCollection\":[\"ABC\",\"DEF\"]}";
            ObjectToSerialize objectToSerialize = new ObjectToSerialize();
            // test immutability of input parameters: save phase
            CompareObjectsContent<ObjectToSerialize> testImmutabilityOf_objectToSerialize = new CompareObjectsContent<ObjectToSerialize>(objectToSerialize);

            // ACT
            Result<string> result = JsonSerializeObject<ObjectToSerialize>.SerializeObject(objectToSerialize, false);

            // ASSERT
            Assert.True(result.IsSuccess);
            Assert.Equal(serializedObject, result.Value);
            // test immutability of input parameters: test phase
            Assert.True(testImmutabilityOf_objectToSerialize.TestContentIsEqualToSavedObject(objectToSerialize));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void SerializeObject_Test_Failure_On_Serialization_With_Null_Input()
        {
            // ARRANGE

            // ACT
            Result<string> result = JsonSerializeObject<ObjectToSerialize>.SerializeObject(null, false);

            // ASSERT
            Assert.True(result.IsFailure);
        }

        public class ObjectToSerialize
        {
            public Collection<string> Collection = new Collection<string>(new[] { "ABC", "DEF" });
            public List<string> List = new List<string>(new[] { "ABC", "DEF" });
            public ReadOnlyCollection<string> ReadOnlyCollection = new ReadOnlyCollection<string>(new[] { "ABC", "DEF" });
        }
    }
}

