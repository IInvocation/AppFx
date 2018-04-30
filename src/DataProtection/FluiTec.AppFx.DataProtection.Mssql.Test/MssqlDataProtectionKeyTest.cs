using FluiTec.AppFx.DataProtection.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.DataProtection.Mssql.Test
{
    [TestClass]
    public class MssqlDataProtectionKeyTest : DataProtectionKeyTest
    {
        public MssqlDataProtectionKeyTest() : base(Helper.GetDataService())
        {
        }

        [TestMethod]
        public override void CanAddAndGetKey()
        {
            base.CanAddAndGetKey();
        }

        [TestMethod]
        public override void CanAddAndGetKeys()
        {
            base.CanAddAndGetKeys();
        }

        [TestMethod]
        public override void CanUpdateKey()
        {
            base.CanUpdateKey();
        }

        [TestMethod]
        public override void CanDeleteKey()
        {
            base.CanDeleteKey();
        }
    }
}
