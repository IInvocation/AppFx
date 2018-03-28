using FluiTec.AppFx.IdentityServer.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.LiteDb.Test
{
    [TestClass]
    public class LiteDbScopeTest : ScopeTest
    {
        public LiteDbScopeTest() : base(Helper.GetDataService())
        {
        }

        [TestMethod]
        public override void CanAddAndGetScope()
        {
            base.CanAddAndGetScope();
        }

        [TestMethod]
        public override void CanAddAndGetScopes()
        {
            base.CanAddAndGetScopes();
        }

        [TestMethod]
        public override void CanUpdateScope()
        {
            base.CanUpdateScope();
        }

        [TestMethod]
        public override void CanDeleteScope()
        {
            base.CanDeleteScope();
        }

        [TestMethod]
        public override void CanGetByIds()
        {
            base.CanGetByIds();
        }

        [TestMethod]
        public override void CanGetByNames()
        {
            base.CanGetByNames();
        }
    }
}