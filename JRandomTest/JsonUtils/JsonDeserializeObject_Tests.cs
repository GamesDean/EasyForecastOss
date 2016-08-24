using Xunit;
using EasyForecast.SymEngine.JsonUtils;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EasyForecast.SymEngine.ObjUtils;
using CSharpFunctionalExtensions;

namespace EasyForecast.SymEngine.Tests
{
    // REMEMBER  Test that each pure function does not modify the input parameters

    public class JsonDeserializeObject_Tests
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void DeserializeObject_Test_Success_On_Deserialization()
        {
            // ARRANGE
            string serializedObject = @"{
            Collection: [ 'Goodbye', 'AOL' ],
            List: [ 'Goodbye', 'AOL' ],
            ReadOnlyCollection: [ 'Goodbye', 'AOL' ]
            }";
            // test immutability of input parameters: save phase
            CompareObjectsContent<string> testImmutabilityOf_serializedObject = new CompareObjectsContent<string>(serializedObject);

            // ACT
            Result<ObjectToSerializeDeserialize> ObjectDeserialized = JsonDeserializeObject<ObjectToSerializeDeserialize>.DeserializeObject(serializedObject);

            // ASSERT
            Assert.True(ObjectDeserialized.IsSuccess);
            Assert.True(ObjectDeserialized.Value.Collection[0] == "Goodbye");
            Assert.True(ObjectDeserialized.Value.Collection[1] == "AOL");
            Assert.True(ObjectDeserialized.Value.List[0] == "Goodbye");
            Assert.True(ObjectDeserialized.Value.List[1] == "AOL");
            Assert.True(ObjectDeserialized.Value.ReadOnlyCollection[0] == "Goodbye");
            Assert.True(ObjectDeserialized.Value.ReadOnlyCollection[1] == "AOL");
            // test immutability of input parameters: test phase
            Assert.True(testImmutabilityOf_serializedObject.TestContentIsEqualToSavedObject(serializedObject));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void DeserializeObject_Test_Failure_On_Deserialization_With_Null_Input()
        {
            // ARRANGE

            // ACT
            Result<ObjectToSerializeDeserialize> result = JsonDeserializeObject<ObjectToSerializeDeserialize>.DeserializeObject(null);

            // ASSERT
            Assert.True(result.IsFailure);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void DeserializeObject_Test_Failure_On_Serialization_With_Empty_Input()
        {
            // ARRANGE

            // ACT
            Result<ObjectToSerializeDeserialize> result = JsonDeserializeObject<ObjectToSerializeDeserialize>.DeserializeObject("   ");

            // ASSERT
            Assert.True(result.IsFailure);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [Fact]
        public void DeserializeObject_Test_Failure_On_Deserialization_With_Invalid_Input()
        {
            // ARRANGE
            string serializedObject = @"{
            Collection: [ 'Goodbye', 'AOL' ],
            List: [ 'Goodbye', 'AOL' ],
            ReadOnlyCollection: [ 'Goodbye', 'AOL' 
            }";

            // ACT
            Result<ObjectToSerializeDeserialize> result = JsonDeserializeObject<ObjectToSerializeDeserialize>.DeserializeObject(serializedObject);

            // ASSERT
            Assert.True(result.IsFailure);
        }

        public class ObjectToSerializeDeserialize
        {
            public Collection<string> Collection = new Collection<string>(new[] { "ABC", "DEF" });
            public List<string> List = new List<string>(new[] { "ABC", "DEF" });
            public ReadOnlyCollection<string> ReadOnlyCollection = new ReadOnlyCollection<string>(new[] { "ABC", "DEF" });
        }
    }
}
