using FluiTec.AppFx.IdentityServer.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.LiteDb.Test
{
    [TestClass]
    public class LiteDbIdentityResourceTest : IdentityResourceTest
    {
        public LiteDbIdentityResourceTest() : base(Helper.GetDataService())
        {
        }

        [TestMethod]
        public override void CanAddAndGetIdentityResource()
        {
            base.CanAddAndGetIdentityResource();
        }

        [TestMethod]
        public override void CanAddAndGetIdentityResources()
        {
            base.CanAddAndGetIdentityResources();
        }

        [TestMethod]
        public override void CanUpdateResource()
        {
            base.CanUpdateResource();
        }

        [TestMethod]
        public override void CanDeleteResource()
        {
            base.CanDeleteResource();
        }

        [TestMethod]
        public override void CanGetAllCompound()
        {
            base.CanGetAllCompound();
        }

        [TestMethod]
        public override void CanGetByScopeNamesCompound()
        {
            base.CanGetByScopeNamesCompound();
        }
    }
}