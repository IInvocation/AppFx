using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Reflection.Test
{
    /// <summary>   (Unit Test Class) an assembly scanner test. </summary>
    [TestClass]
    public class AssemblyScannerTest
    {
        [TestMethod]
        public void TestGetAttributedTypes()
        {
            var assembly = typeof(TestClassWithAttribute).Assembly;
            var foundTypes = AssemblyScanner.GetAttributedTypes(assembly, typeof(TestAttribute));
            Assert.IsNotNull(foundTypes);
            var enumerable = foundTypes as Type[] ?? foundTypes.ToArray();
            Assert.AreEqual(2, enumerable.Length);
            Assert.AreEqual(typeof(TestClassWithAttribute), enumerable.First());
        }

        [TestMethod]
        public void TestFindAllAttributedTypes()
        {
            var attributedTypes = AssemblyScanner.FindAllAttributedTypes(typeof(TestAttribute));
            Assert.AreEqual(2, attributedTypes.Count());
        }
    }
}