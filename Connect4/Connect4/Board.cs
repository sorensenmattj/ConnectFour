using System;

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
    }
}
