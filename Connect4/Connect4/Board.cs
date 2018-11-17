using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public class Board
    {
        public char[,] State { get; set; }

        public Board()
        {
            var numberOfColumns = 7;
            var numberOfRows = 6;

            State = new char[numberOfRows, numberOfColumns];

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    State[i, j] = ' ';
                }
            }
        }

        public void AddTokenToColumn(char token, int columnIndex)
        {
            for (int i = State.GetUpperBound(0); i >= 0; i--)
            {
                if (State[i, columnIndex] == ' ')
                {
                    State[i, columnIndex] = token;
                    break;
                }
            }
        }
    }
}
