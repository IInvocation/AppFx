using FluiTec.AppFx.IdentityServer.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.LiteDb.Test
{
    [TestClass]
    public class LiteDbIdentityResourceScopeTest : IdentityResourceScopeTest
    {
        public LiteDbIdentityResourceScopeTest() : base(Helper.GetDataService())
        {
        }

        [TestMethod]
        public override void CanAddAndGetIdentityResourceScope()
        {
            base.CanAddAndGetIdentityResourceScope();
        }

        [TestMethod]
        public override void CanAddAndGetIdentityResourceScopes()
        {
            base.CanAddAndGetIdentityResourceScopes();
        }

        [TestMethod]
        public override void CanUpdateIdentityResourceScope()
        {
            base.CanUpdateIdentityResourceScope();
        }

        [TestMethod]
        public override void CanDeleteIdentityResourceScope()
        {
            base.CanDeleteIdentityResourceScope();
        }
    }
}