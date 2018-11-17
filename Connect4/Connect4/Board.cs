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

        public int NumberOfColumns => 7;

        public int NumberOfRows => 6;

        public Board()
        {
            State = new char[NumberOfRows, NumberOfColumns];

            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    State[i, j] = ' ';
                }
            }
        }

        public void AddTokenToColumn(char token, int columnIndex)
        {
            for (int i = NumberOfRows; i >= 0; i--)
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
