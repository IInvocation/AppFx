using FluiTec.AppFx.IdentityServer.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.LiteDb.Test
{
    [TestClass]
    public class LiteDbClientTest : ClientTest
    {
        public LiteDbClientTest() : base(Helper.GetDataService())
        {
        }

        [TestMethod]
        public override void CanAddAndGetClient()
        {
            base.CanAddAndGetClient();
        }

        [TestMethod]
        public override void CanAddAndGetClients()
        {
            base.CanAddAndGetClients();
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

        [TestMethod]
        public override void CanGetByClientId()
        {
            base.CanGetByClientId();
        }

        [TestMethod]
        public override void CanGetCompoundByClientId()
        {
            base.CanGetCompoundByClientId();
        }
    }
}