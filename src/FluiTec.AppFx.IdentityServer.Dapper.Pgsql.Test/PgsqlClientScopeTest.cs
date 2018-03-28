using FluiTec.AppFx.IdentityServer.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Dapper.Pgsql.Test
{
    [TestClass]
    public class PgsqlClientScopeTest : ClientScopeTest
    {
        public PgsqlClientScopeTest() : base(Helper.GetDataService())
        {
        }

        [TestMethod]
        public override void CanAddAndGetClientScope()
        {
            base.CanAddAndGetClientScope();
        }

        [TestMethod]
        public override void CanAddAndGetClientScopes()
        {
            base.CanAddAndGetClientScopes();
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
    }
}