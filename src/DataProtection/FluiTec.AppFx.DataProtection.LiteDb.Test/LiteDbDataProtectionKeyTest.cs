using FluiTec.AppFx.DataProtection.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.DataProtection.LiteDb.Test
{
    /// <summary>   (Unit Test Class) a lite database data protection key test. </summary>
    [TestClass]
    public class LiteDbDataProtectionKeyTest : DataProtectionKeyTest
    {
        /// <summary>   Default constructor. </summary>
        public LiteDbDataProtectionKeyTest() : base(Helper.GetDataService())
        {
        }

        /// <summary>   (Unit Test Method) can add and get key. </summary>
        [TestMethod]
        public override void CanAddAndGetKey()
        {
            base.CanAddAndGetKey();
        }

        /// <summary>   (Unit Test Method) can add and get keys. </summary>
        [TestMethod]
        public override void CanAddAndGetKeys()
        {
            base.CanAddAndGetKeys();
        }

        /// <summary>   (Unit Test Method) can update key. </summary>
        [TestMethod]
        public override void CanUpdateKey()
        {
            base.CanUpdateKey();
        }

        /// <summary>   (Unit Test Method) can delete key. </summary>
        [TestMethod]
        public override void CanDeleteKey()
        {
            base.CanDeleteKey();
        }
    }
}
