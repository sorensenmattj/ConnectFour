using System;
using System.IO;
using System.Text;

namespace Connect4
{
    public class Engine
    {
        private Board _board { get; set; }

        public char CurrentToken => 
            _board.ValidTokens[Turn % _board.ValidTokens.Length];

        public int Turn { get; set; }

        /// <summary>
        /// Initialise a new instance of the <see cref="Engine"/> class
        /// with the specified options.
        /// </summary>
        public Engine(Board board)
        {
            _board = board;

            Turn = 1;
        }

        /// <summary>
        /// Gets a column index from the user. Returns -1 if invalid input.
        /// </summary>
        public int GetIndexFromUser(TextWriter writer, TextReader reader)
        {
            writer.Write($"Place {CurrentToken} at index: ");
            var input = reader.ReadLine();

            if (int.TryParse(input, out int index))
            {
                if (index < _board.MinIndex || index > _board.MaxIndex)
                {
                    return -1;
                }

                Console.WriteLine();
                return index;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Adds a token to the board at the given index.
        /// </summary>
        public void AddToken(char token, int index)
        {
            _board.AddTokenToColumn(token, index);
        }

        /// <summary>
        /// Plays the game.
        /// </summary>
        public void Play()
        {
            while (Turn <= _board.NumberOfColumns * _board.NumberOfRows)
            {
                DisplayBoard();

                while (true)
                {
                    int chosenIndex;

                    do
                    {
                        chosenIndex = GetIndexFromUser(Console.Out, Console.In);
                    }
                    while (chosenIndex == -1);

                    try
                    {
                         _board.AddTokenToColumn(CurrentToken, chosenIndex);
                        break;
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (_board.HasPlayerWon(CurrentToken))
                {
                    DisplayBoard();

                    Console.WriteLine($"Player {CurrentToken} has won!");
                    return;
                }

                Turn++;
            }
        }

        /// <summary>
        /// Prints the board state to the console.
        /// </summary>
        private void DisplayBoard()
        {
            for (int row = 0; row < _board.NumberOfRows; row++)
            {
                for (int column = 0; column < _board.NumberOfColumns; column++)
                {
                    Console.Write($"{_board.State[row, column]}|");
                }

                Console.WriteLine();
            }

            Console.WriteLine("0 1 2 3 4 5 6\n");
        }
    }
}
