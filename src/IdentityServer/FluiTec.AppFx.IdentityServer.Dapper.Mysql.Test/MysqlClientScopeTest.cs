using FluiTec.AppFx.IdentityServer.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Dapper.Mysql.Test
{
    [TestClass]
    public class MysqlClientScopeTest : ClientScopeTest
    {
        public MysqlClientScopeTest() : base(Helper.GetDataService())
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