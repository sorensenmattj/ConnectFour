using Connect4;
using NUnit.Framework;
using System;

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

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void AddTwoTokensToSameColumn(int columnIndex)
        {
            _board.AddTokenToColumn('X', columnIndex);
            _board.AddTokenToColumn('X', columnIndex);

            Assert.AreEqual(
                'X',
                _board.State[5, columnIndex],
                "First token not placed in expected location.");

            Assert.AreEqual(
                'X',
                _board.State[4, columnIndex],
                "Second token not placed in expected location.");
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void TryAddSevenTokensToSameColumn(int columnIndex)
        {
            for (int i = 0; i < _board.NumberOfRows; i++)
            {
                _board.AddTokenToColumn('X', columnIndex);
            }

            Assert.Throws<InvalidOperationException>(
                () => _board.AddTokenToColumn('X', columnIndex));
        }
    }
}
