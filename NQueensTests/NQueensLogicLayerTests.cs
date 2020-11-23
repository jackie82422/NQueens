using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using static NQueens.NQueensLogicLayer;

namespace NQueensTests
{
    [TestClass]
    public class NQueensLogicLayerTests
    {
        #region UserInput

        [DataTestMethod]
        [DataRow(2, 2)]
        public void ValidInputByAp_UserInputTest_ReturnInputNum(int inputNum, int exceptedNum)
        {
            var actualNum = UserInput(inputNum);
            Assert.AreEqual(exceptedNum, actualNum);
        }

        [DataTestMethod]
        [DataRow("5", 5)]
        public void ValidInputByConsole_UserInputTest_ReturnInputNum(string input, int exceptedNum)
        {
            var inputParam = new StringReader(input);
            Console.SetIn(inputParam);
            var actualNum = UserInput();
            Assert.AreEqual(exceptedNum, actualNum);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void InvalidInputByConsole_UserInputTest_ReturnException()
        {
            var inputParam = new StringReader("NaN");
            Console.SetIn(inputParam);
            var actualNum = UserInput();
        }

        #endregion UserInput
    }
}