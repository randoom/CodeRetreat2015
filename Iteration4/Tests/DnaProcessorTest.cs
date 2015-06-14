using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iteration4.Tests
{
    [TestClass]
    public class DnaProcessorTest
    {
        private ISequenceFilter sequenceFilter;

        [TestInitialize]
        public void TestInitialize()
        {
            this.sequenceFilter = new SequenceFilter();
        }

        [TestMethod]
        public void ShouldFilterSequences()
        {
            var processor = new DnaFileProcessor(new[] { new ReverseCommandParser(this.sequenceFilter) }, this.sequenceFilter);
            string[] result = processor.Process(new[] { "! é RT ACT k !G" });

            CollectionAssert.AreEqual(new[] { "TACTG" }, result);
        }

        [TestMethod]
        public void ParserShouldCreateAReverseProcessor()
        {
            var processor = new DnaFileProcessor(new[] {new ReverseCommandParser(this.sequenceFilter)}, this.sequenceFilter);
            string[] result = processor.Process(new[] {"reverse", "ACTG"});

            CollectionAssert.AreEqual(new[] { "GTCA" }, result);
        }
    }
}