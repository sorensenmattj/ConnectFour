using System;

namespace Connect4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var board = new Board();
            var engine = new Engine(board);

            engine.Play();

            Console.Read();
        }
    }
}
