using Connect4;
using NUnit.Framework;

namespace Connect4Testing
{
    [TestFixture]
    public class BoardInteraction
    {
        private Board _board;

        [SetUp]
        public void SetUp()
        {
            _board = new Board();
        }

        [TestCase]
        public void CreateNewBoard()
        {
            char[,] boardState = _board.State;

            foreach (char tile in boardState)
            {
                Assert.AreEqual(
                    ' ',
                    tile,
                    "Actual tile does not match expected tile value.");
            }
        }

        [TestCase('X', 0)]
        [TestCase('X', 1)]
        [TestCase('X', 2)]
        [TestCase('X', 3)]
        [TestCase('X', 4)]
        [TestCase('X', 5)]
        [TestCase('X', 6)]
        public void AddTokenToColumn(char token, int columnIndex)
        {
            _board.AddTokenToColumn(token, columnIndex);

            Assert.AreEqual(
                token,
                _board.State[5, columnIndex],
                "Token at bottom of column not expected token.");
        }

        [TestCase]
        public void AddTwoTokensToSameColumn()
        {
            _board.AddTokenToColumn('X', 0);
            _board.AddTokenToColumn('X', 0);

            Assert.AreEqual(
                'X',
                _board.State[5, 0],
                "First token not placed in expected location.");

            Assert.AreEqual(
                'X',
                _board.State[4, 0],
                "Second token not placed in expected location.");
        }
    }
}
