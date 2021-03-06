﻿using Connect4;
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

        [TestCase]
        public void ValidTokens()
        {
            char[] expectedValidTokens = { 'O', 'X' };

            var actualValidTokens = _board.ValidTokens;

            Assert.AreEqual(
                expectedValidTokens.Length,
                actualValidTokens.Length,
                "Number of actual valid tokens does not match expected.");

            for(int i = 0; i < expectedValidTokens.Length; i++)
            {
                Assert.AreEqual(
                    expectedValidTokens[i],
                    actualValidTokens[i],
                    "Actual valid token does not match expected token.");
            }
        }

        [TestCase]
        public void CheckPlayerHasWonVertically()
        {
            _board.AddTokenToColumn('X', 0);
            _board.AddTokenToColumn('X', 0);
            _board.AddTokenToColumn('X', 0);
            _board.AddTokenToColumn('X', 0);

            Assert.IsTrue(
                _board.HasPlayerWon('X'),
                "Player was expected to win but has not.");
        }

        [TestCase]
        public void CheckPlayerHasWonHorizontally()
        {
            _board.AddTokenToColumn('X', 0);
            _board.AddTokenToColumn('X', 1);
            _board.AddTokenToColumn('X', 2);
            _board.AddTokenToColumn('X', 3);

            Assert.IsTrue(
                _board.HasPlayerWon('X'),
                "Player was expected to win but has not.");
        }

        [TestCase]
        public void CheckPlayerHasWonDiagonallyUp()
        {
            _board.AddTokenToColumn('X', 0);
            _board.AddTokenToColumn('O', 1);
            _board.AddTokenToColumn('X', 1);
            _board.AddTokenToColumn('O', 2);
            _board.AddTokenToColumn('O', 2);
            _board.AddTokenToColumn('X', 2);
            _board.AddTokenToColumn('O', 3);
            _board.AddTokenToColumn('O', 3);
            _board.AddTokenToColumn('O', 3);
            _board.AddTokenToColumn('X', 3);

            Assert.IsTrue(
                _board.HasPlayerWon('X'),
                "Player was expected to have won but has not.");
        }

        [TestCase]
        public void CheckPlayerHasWonDiagonallyDown()
        {
            _board.AddTokenToColumn('X', 6);
            _board.AddTokenToColumn('O', 5);
            _board.AddTokenToColumn('X', 5);
            _board.AddTokenToColumn('O', 4);
            _board.AddTokenToColumn('O', 4);
            _board.AddTokenToColumn('X', 4);
            _board.AddTokenToColumn('O', 3);
            _board.AddTokenToColumn('O', 3);
            _board.AddTokenToColumn('O', 3);
            _board.AddTokenToColumn('X', 3);

            Assert.IsTrue(
                _board.HasPlayerWon('X'),
                "Player was expected to have won but has not.");
        }

        [TestCase]
        public void CheckPlayerHasNotWon()
        {
            _board.AddTokenToColumn('X', 0);
            _board.AddTokenToColumn('X', 0);
            _board.AddTokenToColumn('X', 0);

            Assert.IsFalse(
                _board.HasPlayerWon('X'),
                "Player was expected to have not yet won by they have.");
        }
    }
}
