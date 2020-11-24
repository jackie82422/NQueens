using System.Collections.Generic;

namespace NQueens
{
    public class NQueensCalculator
    {
        public List<List<int>> Solution;
        public readonly int[,] ChessBoard;
        private readonly int _totalQueensCount;

        public NQueensCalculator(int queensCount)
        {
            Solution = new List<List<int>>();
            _totalQueensCount = queensCount;
            ChessBoard = new int[queensCount, queensCount];
            SetQueen();
        }

        public void SetQueen(int queenRowPosition = 0)
        {
            if (_totalQueensCount < queenRowPosition) return;
            for (var column = 0; column < _totalQueensCount; column++)
            {
                if (ChessBoard[queenRowPosition, column] != 0) continue;
                ChessBoard[queenRowPosition, column] = -1;
                SetCheckValueOnBoard(queenRowPosition, column, 1);

                if (queenRowPosition == _totalQueensCount - 1)
                {
                    AddSolution(ChessBoard);
                }
                else
                {
                    SetQueen(queenRowPosition + 1);
                }

                ChessBoard[queenRowPosition, column] = 0;
                SetCheckValueOnBoard(queenRowPosition, column, -1);
            }
        }

        private void AddSolution(int[,] chessBoard)
        {
            var solution = new List<int>();
            for (int i = 0; i < _totalQueensCount; i++)
            {
                for (int j = 0; j < _totalQueensCount; j++)
                {
                    if(chessBoard[i,j]==-1)
                        solution.Add(j);
                }
            }
            Solution.Add(solution);
        }

        public void SetCheckValueOnBoard(int row, int column, int value)
        {
            RowLeftSetValue(row, column, value);
            RowRightSetValue(row, column, value);
            ColumnUpValue(row, column, value);
            ColumnDownValue(row, column, value);
            DiagonalUpRightSetValue(row, column, value);
            DiagonalDownRightSetValue(row, column, value);
            DiagonalUpLeftSetValue(row, column, value);
            DiagonalDownLeftSetValue(row, column, value);
        }

        #region CheckPosition

        public void RowLeftSetValue(int row, int column, int value)
        {
            for (int rowPosition = 0; rowPosition < row; rowPosition++)
            {
                ChessBoard[rowPosition, column] += value;
            }
        }

        public void RowRightSetValue(int row, int column, int value)
        {
            for (int rowPosition = row + 1; rowPosition < _totalQueensCount; rowPosition++)
            {
                ChessBoard[rowPosition, column] += value;
            }
        }

        public void ColumnUpValue(int row, int column, int value)
        {
            for (int columnPosition = 0; columnPosition < column; columnPosition++)
            {
                ChessBoard[row, columnPosition] += value;
            }
        }

        public void ColumnDownValue(int row, int column, int value)
        {
            for (int columnPosition = column + 1; columnPosition < _totalQueensCount; columnPosition++)
            {
                ChessBoard[row, columnPosition] += value;
            }
        }

        public void DiagonalUpRightSetValue(int row, int column, int value)
        {
            for (int rowPosition = row - 1,
                columnPosition = column + 1; rowPosition >= 0 && columnPosition < _totalQueensCount;
                rowPosition--, columnPosition++)

                ChessBoard[rowPosition, columnPosition] += value;
        }

        public void DiagonalDownRightSetValue(int row, int column, int value)
        {
            for (int m = row + 1, n = column + 1; m < _totalQueensCount && n < _totalQueensCount; m++, n++)
                ChessBoard[m, n] += value;
        }

        public void DiagonalUpLeftSetValue(int row, int column, int value)
        {
            for (int m = row - 1, n = column - 1; m >= 0 && n >= 0; m--, n--)
                ChessBoard[m, n] += value;
        }

        public void DiagonalDownLeftSetValue(int row, int column, int value)
        {
            for (int m = row + 1, n = column - 1; m < _totalQueensCount && n >= 0; m++, n--)
                ChessBoard[m, n] += value;
        }

        #endregion CheckPosition
    }
}