using FluiTec.AppFx.IdentityServer.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Dapper.Pgsql.Test
{
    [TestClass]
    public class PgsqlIdentityResourceClaimTest : IdentityResourceClaimTest
    {
        public PgsqlIdentityResourceClaimTest() : base(Helper.GetDataService())
        {
        }

        [TestMethod]
        public override void CanAddAndGetIdentityResourceClaim()
        {
            base.CanAddAndGetIdentityResourceClaim();
        }

        [TestMethod]
        public override void CanAddAndGetIdentityResourceClaims()
        {
            base.CanAddAndGetIdentityResourceClaims();
        }

        [TestMethod]
        public override void CanUpdateIdentityResource()
        {
            base.CanUpdateIdentityResource();
        }

        [TestMethod]
        public override void CanDeleteIdentityResource()
        {
            base.CanDeleteIdentityResource();
        }

        [TestMethod]
        public override void CanGetByIdentityId()
        {
            base.CanGetByIdentityId();
        }
    }
}