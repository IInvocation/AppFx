using FluiTec.AppFx.IdentityServer.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.LiteDb.Test
{
    [TestClass]
    public class LiteDbApiResourceClaimTest : ApiResourceClaimTest
    {
        public LiteDbApiResourceClaimTest() : base(Helper.GetDataService())
        {
        }

        [TestMethod]
        public override void CanAddAndGetApiResourceClaim()
        {
            base.CanAddAndGetApiResourceClaim();
        }

        [TestMethod]
        public override void CanAddAndGetApiResourceClaims()
        {
            base.CanAddAndGetApiResourceClaims();
        }

        [TestMethod]
        public override void CanUpdateApiResource()
        {
            base.CanUpdateApiResource();
        }

        [TestMethod]
        public override void CanDeleteApiResource()
        {
            base.CanDeleteApiResource();
        }

        [TestMethod]
        public override void CanAddAndGetApiResourceClaimByApiResourceId()
        {
            base.CanAddAndGetApiResourceClaimByApiResourceId();
        }

        [TestMethod]
        public override void CanGetByApiIds()
        {
            base.CanGetByApiIds();
        }
    }
}