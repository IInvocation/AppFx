using FluiTec.AppFx.IdentityServer.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Dapper.Mssql.Test
{
    [TestClass]
    public class MssqlApiResourceScopeTest : ApiResourceScopeTest
    {
        public MssqlApiResourceScopeTest() : base(Helper.GetDataService())
        {
        }

        [TestMethod]
        public override void CanAddAndGetApiResourceScope()
        {
            base.CanAddAndGetApiResourceScope();
        }

        [TestMethod]
        public override void CanAddAndGetApiResourceScopes()
        {
            base.CanAddAndGetApiResourceScopes();
        }

        [TestMethod]
        public override void CanUpdateApiResourceScope()
        {
            base.CanUpdateApiResourceScope();
        }

        [TestMethod]
        public override void CanDeleteApiResourceScope()
        {
            base.CanDeleteApiResourceScope();
        }

        [TestMethod]
        public override void CanGetByScopeIds()
        {
            base.CanGetByScopeIds();
        }

        [TestMethod]
        public override void CanGetByApiIds()
        {
            base.CanGetByApiIds();
        }
    }
}