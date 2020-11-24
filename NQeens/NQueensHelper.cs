using NQueens.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NQueens
{
    public static class NQueensHelper
    {
        public static int UserInput(int? num = null)
        {
            if (num != null) return (int)num;
            Console.WriteLine("Please input Queens count or input -1 to exit application");
            var userInput = Console.ReadLine();
            if (int.TryParse(userInput, out var userInputNum))
            {
                return userInputNum;
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        public static Option<int> CheckInputValid(this Option<int> num)
        {
            if (num == -1)
                Environment.Exit(0);

            if (num.Value >= 1)
                return num;
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public static IEnumerable<IEnumerable<int>> NQueenCalculate(int queensCount)
        {
            var nQueens = new NQueensCalculator(queensCount);
            return nQueens.Solution;
        }

        public static void PrintNQueenResult(IEnumerable<IEnumerable<int>> originResults)
        {
            var i = 1;
            foreach (var eachResult in originResults)
            {
                var strBuilder = new StringBuilder();
                var queensCount = eachResult.Count();
                var title = $"Solution {i++}";
                strBuilder.Append(title);
                strBuilder.Append(System.Environment.NewLine);
                foreach (var eachUnit in eachResult)
                {
                    var info = string.Empty.PadLeft(queensCount - 1, '.').Insert(eachUnit, "Q");
                    strBuilder.Append(info);
                    strBuilder.Append(System.Environment.NewLine);
                }

                Console.WriteLine(strBuilder.ToString());
            }
        }
    }
}