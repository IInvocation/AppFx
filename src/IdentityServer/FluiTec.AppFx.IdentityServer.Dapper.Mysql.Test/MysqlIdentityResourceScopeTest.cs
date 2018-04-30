using FluiTec.AppFx.IdentityServer.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Dapper.Mysql.Test
{
    [TestClass]
    public class MysqlIdentityResourceScopeTest : IdentityResourceScopeTest
    {
        public MysqlIdentityResourceScopeTest() : base(Helper.GetDataService())
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