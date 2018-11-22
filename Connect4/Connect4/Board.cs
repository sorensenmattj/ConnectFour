using System;
using System.Collections.Generic;
using System.Linq;

namespace Connect4
{
    public class Board
    {
        public char[,] State { get; set; }

        public int NumberOfColumns => 7;

        public int NumberOfRows => 6;

        public char EmptyCellValue => ' ';

        public int MinIndex => 0;

        public int MaxIndex => NumberOfColumns - 1;

        public readonly char[] ValidTokens = { 'O', 'X' };

        /// <summary>
        /// Initialises a new instance of the <see cref="Board"/> class.
        /// </summary>
        public Board()
        {
            State = new char[NumberOfRows, NumberOfColumns];

            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    State[i, j] = EmptyCellValue;
                }
            }
        }

        /// <summary>
        /// Adds a token to the lowest empty row in the specified column.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if column is full when trying to add token.
        /// </exception>
        public void AddTokenToColumn(char token, int columnIndex)
        {
            for (int i = NumberOfRows - 1; i >= 0; i--)
            {
                if (State[i, columnIndex].Equals(EmptyCellValue))
                {
                    State[i, columnIndex] = token;
                    return;
                }
            }

            throw new InvalidOperationException(
                "Cannot add token to full column.");
        }

        /// <summary>
        /// Checks if the player has won.
        /// </summary>
        public bool HasPlayerWon(char playerToken)
        {
            if (IsVerticalWin(playerToken))
            {
                return true;
            }
            else if (IsHorizontalWin(playerToken))
            {
                return true;
            }
            else if (IsDiagonalWin(playerToken))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if there is a 4-in-a-row within a column.
        /// </summary>
        private bool IsVerticalWin(char playerToken)
        {
            for (int column = 0; column < NumberOfColumns; column++)
            {
                for (int row = NumberOfRows - 1; row >= 3; row--)
                {
                    var tokenMatches = new List<bool>
                    {
                        State[row, column].Equals(playerToken),
                        State[row - 1, column].Equals(playerToken),
                        State[row - 2, column].Equals(playerToken),
                        State[row - 3, column].Equals(playerToken)
                    };

                    if (tokenMatches.All(x => x))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if there is a 4-in-a-row within a row.
        /// </summary>
        private bool IsHorizontalWin(char playerToken)
        {
            for (int row = NumberOfRows - 1; row >= 0; row--)
            {
                for (int column = 0; column <= NumberOfColumns - 4; column++)
                {
                    var tokenMatches = new List<bool>
                    {
                        State[row, column].Equals(playerToken),
                        State[row, column + 1].Equals(playerToken),
                        State[row, column + 2].Equals(playerToken),
                        State[row, column + 3].Equals(playerToken)
                    };

                    if (tokenMatches.All(x => x))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if there is a win diagonally.
        /// </summary>
        private bool IsDiagonalWin(char playerToken)
        {
            return IsUpDiagonalWin(playerToken) || IsDownDiagonalWin(playerToken);
        }

        /// <summary>
        /// Checks if there is a 4-in-a-row in a bottom-left to top-right diagonal.
        /// </summary>
        private bool IsUpDiagonalWin(char playerToken)
        {
            for (int column = 0; column <= NumberOfColumns - 4; column++)
            {
                for (int row = 3; row < NumberOfRows; row++)
                {
                    for (int offset = 0; offset <= row - 3; offset++)
                    {
                        if (column >= 2 && offset > 3 - column)
                        {
                            break;
                        }

                        var firstRow = row - offset;
                        var firstColumn = column + offset;

                        var tokenMatches = new List<bool>
                        {
                            State[firstRow, firstColumn].Equals(playerToken),
                            State[firstRow - 1, firstColumn + 1].Equals(playerToken),
                            State[firstRow - 2, firstColumn + 2].Equals(playerToken),
                            State[firstRow - 3, firstColumn + 3].Equals(playerToken)
                        };

                        if (tokenMatches.All(x => x))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if there is a 4-in-a-row in a top-left to bottom-right diagonal.
        /// </summary>
        private bool IsDownDiagonalWin(char playerToken)
        {
            for (int column = 0; column <= NumberOfColumns - 4; column++)
            {
                for (int row = 0; row <= NumberOfRows - 4; row++)
                {
                    for (int offset = 0; offset < 3 - row; offset++)
                    {
                        if (column >= 2 && offset > 3 - column)
                        {
                            break;
                        }

                        var firstRow = row + offset;
                        var firstColumn = column + offset;

                        var tokenMatches = new List<bool>
                        {
                            State[firstRow, firstColumn].Equals(playerToken),
                            State[firstRow + 1, firstColumn + 1].Equals(playerToken),
                            State[firstRow + 2, firstColumn + 2].Equals(playerToken),
                            State[firstRow + 3, firstColumn + 3].Equals(playerToken)
                        };

                        if (tokenMatches.All(x => x))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
