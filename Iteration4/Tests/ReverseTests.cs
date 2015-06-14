using Iteration4.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iteration4.Tests
{
    [TestClass]
    public class ReverseTests
    {
        [TestMethod]
        public void ParserShouldCreateAReverseProcessor()
        {
            var parser = new ReverseCommandParser();
            ICommandProcessor commandProcessor = parser.TryCreate("reverse");

            Assert.IsTrue(commandProcessor is ReverseCommandProcessor);
        }

        [TestMethod]
        public void ReverseProcessorShouldReverse()
        {
            var processsor = new ReverseCommandProcessor();
            Assert.AreEqual("GTCA", processsor.Process("ACTG"));
        }

        [TestMethod]
        public void ParserShouldCreateNullProcessorForUnknownCommand()
        {
            var parser = new ReverseCommandParser();
            ICommandProcessor commandProcessor = parser.TryCreate("dummy");

            Assert.IsTrue(commandProcessor is NullProcessor);
        }
    }
}