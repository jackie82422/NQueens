using System;
using NQueens.Helpers;
using static NQueens.NQueensLogicLayer;
using static NQueens.Helpers.OptionHelpers;

namespace NQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInput =  Some(UserInput());
            Console.WriteLine(userInput.Value);
        }
    }
}
