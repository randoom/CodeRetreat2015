using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iteration3
{
    [TestClass]
    public class FileProcessorTest
    {
        [TestMethod]
        public void ParserShouldCreateAReverseProcessor()
        {
            var processor = new DnaProcessor(new[] {new ReverseParser()});
            string result = processor.Process(new[] {"reverse", "ACTG"});

            Assert.AreEqual("GTCA", result);
        }
    }

    public class DnaProcessor
    {
        private readonly IEnumerable<IParser> parsers;

        public DnaProcessor(IEnumerable<IParser> parsers)
        {
            this.parsers = parsers;
        }

        public string Process(string[] lines)
        {
            ParseCommands(lines);

            throw new NotImplementedException();
        }

        private void ParseCommands(string[] lines)
        {
        }
    }
}