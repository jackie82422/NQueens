using System;
using NQueens.Helpers;
using static NQueens.Helpers.OptionHelpers;
using static NQueens.NQueensLogicLayer;

namespace NQueens
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Some(UserInput(8))
                    .CheckInputValid()
                    .SetBoardMatrix()
                    .Map(NQueenCalculate)
                    .Do(PrintNQueenResult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}