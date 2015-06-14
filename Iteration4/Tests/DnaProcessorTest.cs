using System.Reflection;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iteration4.Tests
{
    [TestClass]
    public class DnaProcessorTest
    {
        private IContainer container;

        [TestInitialize]
        public void TestInitialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).
                AsImplementedInterfaces();
            builder.RegisterType<DnaFileProcessor>();

            this.container = builder.Build();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.container.Dispose();
        }

        [TestMethod]
        public void ShouldFilterSequences()
        {
            var processor = this.container.Resolve<DnaFileProcessor>();

            var result = processor.Process(new[] {"! é RT ACT k !G"});

            CollectionAssert.AreEqual(new[] {"TACTG"}, result);
        }

        [TestMethod]
        public void SouldReverse()
        {
            var processor = this.container.Resolve<DnaFileProcessor>();

            var result = processor.Process(new[] {"reverse", "ACTG"});

            CollectionAssert.AreEqual(new[] {"GTCA"}, result);
        }

        [TestMethod]
        public void SouldNotReverseWhenDoubleReverse()
        {
            var processor = this.container.Resolve<DnaFileProcessor>();

            var result = processor.Process(new[] {"reverse", "reverse", "ACTG"});

            CollectionAssert.AreEqual(new[] { "ACTG" }, result);
        }

        [TestMethod]
        public void SouldInsertThenReverse()
        {
            var processor = this.container.Resolve<DnaFileProcessor>();

            var result = processor.Process(new[] { "insert GG 2", "reverse", "ACTG" });

            CollectionAssert.AreEqual(new[] { "GTCGGA" }, result);
        }
    }
}