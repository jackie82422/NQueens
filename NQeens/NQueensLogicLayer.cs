using NQueens.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NQueens
{
    public static class NQueensLogicLayer
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

        public static Option<int[,]> SetBoardMatrix(this Option<int> num)
        {
            return new int[num, num];
        }

        public static IEnumerable<int> NQueenCalculate(int[,] queensCount)
        {
            var boardSize = Math.Pow(queensCount.Length,0.5);
            for (var row = 0; row < boardSize; row++)
            {
                
            }

            return new List<int>();
        }

        public static void PrintNQueenResult(IEnumerable<int> originResult)
        {
        }
    }
}