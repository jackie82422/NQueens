using System;

namespace NQueens
{
    public static class NQueensLogicLayer
    {
        public static int UserInput(int? num = null)
        {
            if (num != null) return (int)num;
            Console.WriteLine("Please input Queens count.");
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
    }
}