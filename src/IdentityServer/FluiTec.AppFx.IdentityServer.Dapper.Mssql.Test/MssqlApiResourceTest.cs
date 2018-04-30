using FluiTec.AppFx.IdentityServer.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Dapper.Mssql.Test
{
    [TestClass]
    public class MssqlApiResourceTest : ApiResourceTest
    {
        public MssqlApiResourceTest() : base(Helper.GetDataService())
        {
        }

        [TestMethod]
        public override void CanAddAndGetApiResource()
        {
            base.CanAddAndGetApiResource();
        }

        [TestMethod]
        public override void CanAddAndGetApiResources()
        {
            base.CanAddAndGetApiResources();
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
        public override void CanAddAndGetByName()
        {
            base.CanAddAndGetByName();
        }

        [TestMethod]
        public override void CanAddAndGetByIds()
        {
            base.CanAddAndGetByIds();
        }

        [TestMethod]
        public override void CanGetAllCompound()
        {
            base.CanGetAllCompound();
        }

        [TestMethod]
        public override void CanGetGetByScopeNamesCompound()
        {
            base.CanGetGetByScopeNamesCompound();
        }

        [TestMethod]
        public override void CanGetByNameCompountd()
        {
            base.CanGetByNameCompountd();
        }
    }
}