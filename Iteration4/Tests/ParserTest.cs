using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iteration4.Tests
{
    [TestClass]
    public class ParserTest
    {
        private ISequenceFilter sequenceFilter;

        [TestInitialize]
        public void TestInitialize()
        {
            this.sequenceFilter = new SequenceFilter();
        }

        [TestMethod]
        public void ParserShouldCreateAReverseProcessor()
        {
            var parser = new ReverseCommandParser(this.sequenceFilter);
            ICommandProcessor commandProcessor = parser.Create("reverse");

            Assert.IsTrue(commandProcessor is ReverseProcessor);
        }

        [TestMethod]
        public void ReverseProcessorShouldReverse()
        {
            var processsor = new ReverseProcessor();
            Assert.AreEqual("GTCA", processsor.Process("ACTG"));
        }

        [TestMethod]
        public void ParserShouldCreateNullProcessForUnknownCommand()
        {
            var parser = new ReverseCommandParser(this.sequenceFilter);
            ICommandProcessor commandProcessor = parser.Create("dummy");

            Assert.IsTrue(commandProcessor is NullProcessor);
        }
    }
}