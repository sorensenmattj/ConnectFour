using System;
using NUnit.Framework;
using Connect4;
using System.IO;
using System.Text;

namespace Connect4Testing
{
    [TestFixture]
    public class EngineUnits
    {
        private Engine _engine;

        [SetUp]
        public void SetUp()
        {
            _engine = new Engine(new Board());
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void GetColumnIndexFromUser(int columnIndex)
        {
            var writer = new StringWriter();
            string readerBuilder = $"{columnIndex}";
            var reader = new StringReader(readerBuilder);

            int actualIndex = _engine.GetIndexFromUser(writer, reader);

            Assert.AreEqual(
                columnIndex,
                actualIndex,
                "Index from user does not match expected index.");
        }

        [TestCase("a")]
        [TestCase("-1")]
        [TestCase("-2")]
        [TestCase("7")]
        [TestCase("aa")]
        [TestCase("1a")]
        [TestCase("a1")]
        public void GiveInvalidInputForIndexFromUser(string invalidInput)
        {
            int expectedIndex = -1;
            var reader = new StringReader(invalidInput);
            var writer = new StringWriter();

            int actualIndex = _engine.GetIndexFromUser(writer, reader);

            Assert.AreEqual(
                expectedIndex,
                actualIndex,
                $"Actual index does not equal {expectedIndex}");
        }

        [TestCase]
        public void IndexInputPrompt()
        {
            string expectedPrompt = "Place token at index: ";
            var actualPromptBuilder = new StringBuilder();
            var writer = new StringWriter(actualPromptBuilder);
            var reader = new StringReader("1");

            _engine.GetIndexFromUser(writer, reader);

            Assert.AreEqual(
                expectedPrompt,
                actualPromptBuilder.ToString(),
                "Actual prompt does not match expected prompt.");
        }
    }
}
