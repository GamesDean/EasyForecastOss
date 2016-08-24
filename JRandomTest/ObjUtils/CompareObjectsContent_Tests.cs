using Xunit;
using EasyForecast.SymEngine.ObjUtils;


namespace EasyForecast.SymEngine.Tests
{
    // REMEMBER  Test that each pure function does not modify the input parameters

    public class CompareObjectBeforeAndAfterEdit_Tests
    {

        [Fact]
        public void TestContentIsEqualToSavedObject_Test_True_On_Compare_Two_Strings()
        {
            // ARRANGE
            string firstObjectToCompare = "text";
            string secondObjectToCompare = "text";
            // test immutability of input parameters: save phase
            CompareObjectsContent<string> testImmutabilityOf_firstObjectToCompare = new CompareObjectsContent<string>(firstObjectToCompare);
            CompareObjectsContent<string> testImmutabilityOf_secondObjectToCompare = new CompareObjectsContent<string>(secondObjectToCompare);

            // ACT
            CompareObjectsContent<string> compareObjectsContent = new CompareObjectsContent<string>(firstObjectToCompare);
            bool result = compareObjectsContent.TestContentIsEqualToSavedObject(secondObjectToCompare);

            // ASSERT
            Assert.True(result);
            // test immutability of input parameters: test phase
            Assert.True(testImmutabilityOf_firstObjectToCompare.TestContentIsEqualToSavedObject(firstObjectToCompare));
            Assert.True(testImmutabilityOf_secondObjectToCompare.TestContentIsEqualToSavedObject(secondObjectToCompare));

        }

        [Fact]
        public void TestContentIsEqualToSavedObject_Test_False_On_Compare_Two_Strings()
        {
            // ARRANGE
            string firstObjectToCompare = "text text1";
            string secondObjectToCompare = "text text2";
            // test immutability of input parameters: save phase
            CompareObjectsContent<string> testImmutabilityOf_firstObjectToCompare = new CompareObjectsContent<string>(firstObjectToCompare);
            CompareObjectsContent<string> testImmutabilityOf_secondObjectToCompare = new CompareObjectsContent<string>(secondObjectToCompare);

            // ACT
            CompareObjectsContent<string> compareObjectsContent = new CompareObjectsContent<string>(firstObjectToCompare);
            bool result = compareObjectsContent.TestContentIsEqualToSavedObject(secondObjectToCompare);

            // ASSERT
            Assert.False(result);
            // test immutability of input parameters: test phase
            Assert.True(testImmutabilityOf_firstObjectToCompare.TestContentIsEqualToSavedObject(firstObjectToCompare));
            Assert.True(testImmutabilityOf_secondObjectToCompare.TestContentIsEqualToSavedObject(secondObjectToCompare));
        }

        [Fact]
        public void TestContentIsEqualToSavedObject_Test_True_On_Compare_Two_Classes()
        {
            // ARRANGE
            // object1
            ObjectToCompare firstObjectToCompare = new ObjectToCompare();
            firstObjectToCompare.field1 = "text1";
            firstObjectToCompare.field2 = "text2";
            // object2
            ObjectToCompare secondObjectToCompare = new ObjectToCompare();
            secondObjectToCompare.field1 = "text1";
            secondObjectToCompare.field2 = "text2";
            // test immutability of input parameters: save phase
            CompareObjectsContent<ObjectToCompare> testImmutabilityOf_firstObjectToCompare = new CompareObjectsContent<ObjectToCompare>(firstObjectToCompare);
            CompareObjectsContent<ObjectToCompare> testImmutabilityOf_secondObjectToCompare = new CompareObjectsContent<ObjectToCompare>(secondObjectToCompare);

            // ACT
            CompareObjectsContent<ObjectToCompare> compareObjectsContent = new CompareObjectsContent<ObjectToCompare>(firstObjectToCompare);
            bool result = compareObjectsContent.TestContentIsEqualToSavedObject(secondObjectToCompare);

            // ASSERT
            Assert.True(result);
            // test immutability of input parameters: test phase
            Assert.True(testImmutabilityOf_firstObjectToCompare.TestContentIsEqualToSavedObject(firstObjectToCompare));
            Assert.True(testImmutabilityOf_secondObjectToCompare.TestContentIsEqualToSavedObject(secondObjectToCompare));
        }

        [Fact]
        public void TestContentIsEqualToSavedObject_Test_False_On_Compare_Two_Classes()
        {
            // ARRANGE
            // object1
            ObjectToCompare firstObjectToCompare = new ObjectToCompare();
            firstObjectToCompare.field1 = "text1";
            firstObjectToCompare.field2 = "text2";
            // object2
            ObjectToCompare secondObjectToCompare = new ObjectToCompare();
            secondObjectToCompare.field1 = "text3";
            secondObjectToCompare.field2 = "text4";
            // test immutability of input parameters: save phase
            CompareObjectsContent<ObjectToCompare> testImmutabilityOf_firstObjectToCompare = new CompareObjectsContent<ObjectToCompare>(firstObjectToCompare);
            CompareObjectsContent<ObjectToCompare> testImmutabilityOf_secondObjectToCompare = new CompareObjectsContent<ObjectToCompare>(secondObjectToCompare);

            // ACT
            CompareObjectsContent<ObjectToCompare> compareObjectsContent = new CompareObjectsContent<ObjectToCompare>(firstObjectToCompare);
            bool result = compareObjectsContent.TestContentIsEqualToSavedObject(secondObjectToCompare);

            // ASSERT
            Assert.False(result);
            // test immutability of input parameters: test phase
            Assert.True(testImmutabilityOf_firstObjectToCompare.TestContentIsEqualToSavedObject(firstObjectToCompare));
            Assert.True(testImmutabilityOf_secondObjectToCompare.TestContentIsEqualToSavedObject(secondObjectToCompare));
        }

        [Fact]
        public void TestContentIsEqualToSavedObject_Test_False_On_Compare_Null_First_Par()
        {
            // ARRANGE
            // object2
            ObjectToCompare secondObjectToCompare = new ObjectToCompare();
            secondObjectToCompare.field1 = "text3";
            secondObjectToCompare.field2 = "text4";
            // test immutability of input parameters: save phase
            CompareObjectsContent<ObjectToCompare> testImmutabilityOf_secondObjectToCompare = new CompareObjectsContent<ObjectToCompare>(secondObjectToCompare);

            // ACT
            CompareObjectsContent<ObjectToCompare> compareObjectsContent = new CompareObjectsContent<ObjectToCompare>(null);
            bool result = compareObjectsContent.TestContentIsEqualToSavedObject(secondObjectToCompare);

            // ASSERT
            Assert.False(result);
            // test immutability of input parameters: test phase
            Assert.True(testImmutabilityOf_secondObjectToCompare.TestContentIsEqualToSavedObject(secondObjectToCompare));
        }

        [Fact]
        public void TestContentIsEqualToSavedObject_Test_False_On_Compare_Null_Second_Par()
        {
            // ARRANGE
            // object1
            ObjectToCompare firstObjectToCompare = new ObjectToCompare();
            firstObjectToCompare.field1 = "text1";
            firstObjectToCompare.field2 = "text2";
            // test immutability of input parameters: save phase
            CompareObjectsContent<ObjectToCompare> testImmutabilityOf_firstObjectToCompare = new CompareObjectsContent<ObjectToCompare>(firstObjectToCompare);

            // ACT
            CompareObjectsContent<ObjectToCompare> compareObjectsContent = new CompareObjectsContent<ObjectToCompare>(firstObjectToCompare);
            bool result = compareObjectsContent.TestContentIsEqualToSavedObject(null);

            // ASSERT
            Assert.False(result);
            // test immutability of input parameters: test phase
            Assert.True(testImmutabilityOf_firstObjectToCompare.TestContentIsEqualToSavedObject(firstObjectToCompare));
        }

        [Fact]
        public void TestContentIsEqualToSavedObject_Test_True_On_Compare_Null_Both_Par()
        {
            // ARRANGE

            // ACT
            CompareObjectsContent<ObjectToCompare> compareObjectsContent = new CompareObjectsContent<ObjectToCompare>(null);
            bool result = compareObjectsContent.TestContentIsEqualToSavedObject(null);

            // ASSERT
            Assert.True(result);
        }

        private class ObjectToCompare
        {
            public string field1;
            public string field2;
        }
    }
}
