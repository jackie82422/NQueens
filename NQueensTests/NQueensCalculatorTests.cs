using Microsoft.VisualStudio.TestTools.UnitTesting;
using NQueens;


namespace NQueensTests
{
    [TestClass]
    public class NQueensCalculatorTests
    {
        private NQueensCalculator Calculator = null; 

        [TestInitialize]
        public void StartUp()
        {
            Calculator =new NQueensCalculator(8);
        }


        [DataTestMethod]
        [DataRow(2,3,1)]
        public void DiagonalUpRightSetValueTest(int row,int column,int value)
        {
            Calculator.DiagonalUpRightSetValue(row,column,value);
            var actual =  (Calculator.ChessBoard[0, 5] == 1 ) && (Calculator.ChessBoard[1,4] == 1);
            Assert.AreEqual(true,actual);
        }
        [DataTestMethod]
        [DataRow(2, 3, 1)]
        public void DiagonalDownRightSetValueTest(int row, int column, int value)
        {
            Calculator.DiagonalDownRightSetValue(row, column, value);
            var actual = (Calculator.ChessBoard[3, 4] == 1) && (Calculator.ChessBoard[6, 7] == 1);
            Assert.AreEqual(true, actual);

        }

        [DataTestMethod]
        [DataRow(2, 3, 1)]
        public void DiagonalUpLeftSetValueTest(int row, int column, int value)
        {
            Calculator.DiagonalUpLeftSetValue(row, column, value);
            var actual = (Calculator.ChessBoard[1, 2] == 1) && (Calculator.ChessBoard[0, 1] == 1);
            Assert.AreEqual(true, actual);

        }
    }
}