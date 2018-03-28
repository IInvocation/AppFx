using FluiTec.AppFx.IdentityServer.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.LiteDb.Test
{
    [TestClass]
    public class LiteDbClientClaimTest : ClientClaimTest
    {
        public LiteDbClientClaimTest() : base(Helper.GetDataService())
        {
        }

        [TestMethod]
        public override void CanAddAndGetClientClaim()
        {
            base.CanAddAndGetClientClaim();
        }

        [TestMethod]
        public override void CanAddAndGetClientClaims()
        {
            base.CanAddAndGetClientClaims();
        }

        [TestMethod]
        public override void CanUpdateClient()
        {
            base.CanUpdateClient();
        }

        [TestMethod]
        public override void CanDeleteClient()
        {
            base.CanDeleteClient();
        }
    }
}