using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Cryptography.Test
{
    [TestClass]
    public class IdGeneratorTest
    {
        [TestMethod]
        public void Test_Generate_Default()
        {
            // ciphers + separators
            Assert.AreEqual(64 + 3, IdGenerator.GetIdString().Length);
        }
    }
}