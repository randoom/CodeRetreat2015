
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iteration2.Tests
{
    [TestClass]
    public class FileProcessorTests
    {
        private FileProcessor processor;

        [TestInitialize]
        public void SetUp()
        {
            this.processor = new FileProcessor();
        }

        [DeploymentItem("TestCases\\Filter\\input.txt")]
        [DeploymentItem("TestCases\\Filter\\expected.txt")]
        [TestMethod]
        public void ShouldFilterInvalidSequences()
        {
            ProcessInputFileThenCompareWithExpected();
        }

        [DeploymentItem("TestCases\\Reverse\\input.txt")]
        [DeploymentItem("TestCases\\Reverse\\expected.txt")]
        [TestMethod]
        public void ShouldReverseWhenReverseCommand()
        {
            ProcessInputFileThenCompareWithExpected();
        }

        [DeploymentItem("TestCases\\Insert\\input.txt")]
        [DeploymentItem("TestCases\\Insert\\expected.txt")]
        [TestMethod]
        public void ShouldInsertWhenInsertCommand()
        {
            ProcessInputFileThenCompareWithExpected();
        }

        [DeploymentItem("TestCases\\InsertThenReverse\\input.txt")]
        [DeploymentItem("TestCases\\InsertThenReverse\\expected.txt")]
        [TestMethod]
        public void ShouldInsertThenReverseWhenInsertReverseCommands()
        {
            ProcessInputFileThenCompareWithExpected();
        }

        private void ProcessInputFileThenCompareWithExpected()
        {
            this.processor.Process("input.txt", "output.txt");
            AssertFilesAreEqual("expected.txt", "output.txt");
        }

        private void AssertFilesAreEqual(string expectedFile, string outputFile)
        {
            Assert.AreEqual(File.ReadAllText(expectedFile), File.ReadAllText(outputFile));
        }
    }

}