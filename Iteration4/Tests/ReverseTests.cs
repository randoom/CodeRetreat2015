using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iteration4.Tests
{
    [TestClass]
    public class ReverseTests
    {
        private ISequenceCleaner sequenceCleaner;

        [TestInitialize]
        public void TestInitialize()
        {
            this.sequenceCleaner = new SequenceCleaner();
        }

        [TestMethod]
        public void ParserShouldCreateAReverseProcessor()
        {
            var parser = new ReverseCommandParser(this.sequenceCleaner);
            ICommandProcessor commandProcessor = parser.TryCreate("reverse");

            Assert.IsTrue(commandProcessor is ReverseProcessor);
        }

        [TestMethod]
        public void ReverseProcessorShouldReverse()
        {
            var processsor = new ReverseProcessor();
            Assert.AreEqual("GTCA", processsor.Process("ACTG"));
        }

        [TestMethod]
        public void ParserShouldCreateNullProcessorForUnknownCommand()
        {
            var parser = new ReverseCommandParser(this.sequenceCleaner);
            ICommandProcessor commandProcessor = parser.TryCreate("dummy");

            Assert.IsTrue(commandProcessor is NullProcessor);
        }
    }
}