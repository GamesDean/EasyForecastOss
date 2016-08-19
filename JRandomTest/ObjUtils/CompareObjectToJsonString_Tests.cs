using Xunit;
using EasyForecast.SymEngine.ObjUtils;
using EasyForecast.SymEngine.JsonUtils;
using CSharpFunctionalExtensions;


namespace EasyForecast.SymEngine.Tests
{
    // REMEMBER  Test that each pure function does not modify the input parameters

    public class CompareObjectToJsonString_Tests
    {

        [Fact]
        public void TestContentIsEqual_Test_True_On_Compare_Two_Strings()
        {
            // ARRANGE
            string object1 = "text text";
            Result<string> object2String = JsonSerializeObject<string>.SerializeObject("text text");

            // test immutability of input parameters: save phase
            CompareObjectsContent<string> testImmutabilityOf_object1 = new CompareObjectsContent<string>(object1);
            CompareObjectsContent<string> testImmutabilityOf_object2String = new CompareObjectsContent<string>(object2String.Value);

            // ACT
            bool result = CompareObjectToJsonString.TestContentIsEqual<string>(object1, object2String.Value);

            // ASSERT
            Assert.True(result);
            // test immutability of input parameters: test phase
            Assert.True(testImmutabilityOf_object1.TestContentIsEqualToSavedObject(object1));
            Assert.True(testImmutabilityOf_object2String.TestContentIsEqualToSavedObject(object2String.Value));
        }

        [Fact]
        public void TestContentIsEqual_Test_False_On_Compare_Two_Strings()
        {
            // ARRANGE
            string object1 = "text text1";
            Result<string> object2String = JsonSerializeObject<string>.SerializeObject("text text");

            // ACT
            bool result = CompareObjectToJsonString.TestContentIsEqual<string>(object1, object2String.Value);

            // ASSERT
            Assert.False(result);
        }

        [Fact]
        public void TestContentIsEqual_Test_True_On_Compare_A_Class_And_A_String()
        {
            // ARRANGE
            // object1
            ObjectToCompare object1 = new ObjectToCompare();
            object1.field1 = "text1";
            object1.field2 = "text2";
            // object2
            ObjectToCompare object2 = new ObjectToCompare();
            object2.field1 = "text1";
            object2.field2 = "text2";
            Result<string> object2String = JsonSerializeObject<ObjectToCompare>.SerializeObject(object2);
            // test immutability of input parameters: save phase
            CompareObjectsContent<ObjectToCompare> testImmutabilityOf_object1 = new CompareObjectsContent<ObjectToCompare>(object1);
            CompareObjectsContent<string> testImmutabilityOf_object2String = new CompareObjectsContent<string>(object2String.Value);

            // ACT
            bool result = CompareObjectToJsonString.TestContentIsEqual<ObjectToCompare>(object1, object2String.Value);

            // ASSERT
            Assert.True(result);
            // test immutability of input parameters: test phase
            Assert.True(testImmutabilityOf_object1.TestContentIsEqualToSavedObject(object1));
            Assert.True(testImmutabilityOf_object2String.TestContentIsEqualToSavedObject(object2String.Value));
        }

        [Fact]
        public void TestContentIsEqual_Test_False_On_Compare_A_Class_And_A_String()
        {
            // ARRANGE
            ObjectToCompare object1 = new ObjectToCompare();
            object1.field1 = "text1";
            object1.field2 = "text2";

            ObjectToCompare object2 = new ObjectToCompare();
            object2.field1 = "text2";
            object2.field2 = "text3";
            Result<string> object2String = JsonSerializeObject<ObjectToCompare>.SerializeObject(object2);

            // ACT
            bool result = CompareObjectToJsonString.TestContentIsEqual<ObjectToCompare>(object1, object2String.Value);

            // ASSERT
            Assert.False(result);
        }

        [Fact]
        public void TestContentIsEqual_Test_False_On_Compare_Null_First_Par()
        {
            // ARRANGE
            string object1 = "text";

            // ACT
            bool result = CompareObjectToJsonString.TestContentIsEqual<string>(null, object1);

            // ASSERT
            Assert.False(result);
        }

        [Fact]
        public void TestContentIsEqual_Test_False_On_Compare_Null_Second_Par()
        {
            // ARRANGE
            string object1 = "text";

            // ACT
            bool result = CompareObjectToJsonString.TestContentIsEqual<string>(object1, null);

            // ASSERT
            Assert.False(result);
        }

        [Fact]
        public void TestContentIsEqual_Test_False_On_Compare_Empty_Second_Par()
        {
            // ARRANGE
            string object1 = "text";

            // ACT
            bool result = CompareObjectToJsonString.TestContentIsEqual<string>(object1, "");

            // ASSERT
            Assert.False(result);
        }

        [Fact]
        public void TestContentIsEqual_Test_False_On_Compare_Null_First_Par_And_Empty_Second_Par()
        {
            // ARRANGE

            // ACT
            bool result = CompareObjectToJsonString.TestContentIsEqual<string>(null, "");

            // ASSERT
            Assert.False(result);
        }

        private class ObjectToCompare
        {
            public string field1;
            public string field2;
        }
    }
}