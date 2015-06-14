using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iteration3
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void ParserShouldCreateAReverseProcessor()
        {
            var parser = new ReverseParser();
            IProcess process = parser.Create("reverse");

            Assert.IsTrue(process is ReverseProcessor);
        }

        [TestMethod]
        public void ParserShouldCreateNullProcessForUnknownCommand()
        {
            var parser = new ReverseParser();
            IProcess process = parser.Create("dummy");

            Assert.IsTrue(process is NullProcessor);
        }
    }
}