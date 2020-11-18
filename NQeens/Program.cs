using System;
using static NQueens.Helpers.OptionHelpers;
using static NQueens.NQueensLogicLayer;

namespace NQueens
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var userInput = Some(UserInput());
            Console.WriteLine(userInput.Value);
        }
    }
}