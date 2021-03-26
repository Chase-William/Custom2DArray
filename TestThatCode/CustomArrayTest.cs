using Microsoft.VisualStudio.TestTools.UnitTesting;

using CustomArray;

namespace TestThatCode
{
    [TestClass]
    public class CustomArrayTest
    {
        /// <summary>
        /// Constants used for test.
        /// </summary>
        const byte ROW_COUNT = 10, COLUMN_COUNT = 5;
        [TestMethod("Smoke - Length Test")]        
        public void LengthTest()
        {   
            // Standard C# 2d array
            int[,] standard = new int[ROW_COUNT, COLUMN_COUNT];
            // Custom 2d array type
            var custom = new Custom2DArray<int>(ROW_COUNT, COLUMN_COUNT);
            // Comparing the lengths to make sure initializes works as expected.
            Assert.AreEqual(standard.Length, custom.Length, "Error a standard lib 2d array length didn't match the custom's length with the same given values.");
        }

        [TestMethod("Smoke - Get/Set Test")]
        [Description("Test the getter of the custom function and compares it to the standard lib implementation's result.")]
        public void GetIndexTest()
        {
            const byte TARGET_ROW = 2, TARGET_COLUMN = 4; // Where we will be inserting in the test
            const byte VALUE = 66; // The value to be inserted for the test

            // Standard C# 2d array
            int[,] standard = new int[ROW_COUNT, COLUMN_COUNT];
            // Custom 2d array type
            var custom = new Custom2DArray<int>(ROW_COUNT, COLUMN_COUNT);

            // Assigning value at specified index
            standard[TARGET_ROW, TARGET_COLUMN] = VALUE;
            custom.SetAt(TARGET_ROW, TARGET_COLUMN, VALUE);

            // Comparing the result of our SetAt and GetAt methods
            Assert.AreEqual(standard[TARGET_ROW, TARGET_COLUMN], custom.GetAt(TARGET_ROW, TARGET_COLUMN));
        }

        [TestMethod("Smoke - Get/Set Test All Indices")]
        public void TestAllIndices()
        {
            const byte TARGET_ROW = 2, TARGET_COLUMN = 4; // Where we will be inserting in the test
            const byte VALUE = 66; // The value to be inserted for the test

            // Standard C# 2d array
            int[,] standard = new int[ROW_COUNT, COLUMN_COUNT];
            // Custom 2d array type
            var custom = new Custom2DArray<int>(ROW_COUNT, COLUMN_COUNT);

            int counter = 0;

            // Assign incrementing values at each row, column
            for (int row = 0; row < ROW_COUNT; row++)
            {
                for (int column = 0; column < COLUMN_COUNT; column++)
                {
                    standard[row, column] = counter;
                    custom.SetAt(row, column, counter);
                    counter++;
                }
            }

            // Assert each value at each row, column
            for (int row = 0; row < ROW_COUNT; row++)
            {
                for (int column = 0; column < COLUMN_COUNT; column++)
                {
                    Assert.AreEqual(standard[row, column], custom.GetAt(row, column));
                }
            }
        }
    }
}
