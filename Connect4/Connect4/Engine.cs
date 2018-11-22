using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public class Engine
    {
        private Board _board { get; set; }

        /// <summary>
        /// Initialise a new instance of the <see cref="Engine"/> class
        /// with the specified options.
        /// </summary>
        public Engine(Board board)
        {
            _board = board;
        }

        /// <summary>
        /// Gets a column index from the user. Returns -1 if invalid input.
        /// </summary>
        public int GetIndexFromUser(TextWriter writer, TextReader reader)
        {
            writer.Write("Place token at index: ");
            var input = reader.ReadLine();

            if (int.TryParse(input, out int index))
            {
                if (index < _board.MinIndex || index > _board.MaxIndex)
                {
                    return -1;
                }

                return index;
            }
            else
            {
                return -1;
            }
        }
    }
}
