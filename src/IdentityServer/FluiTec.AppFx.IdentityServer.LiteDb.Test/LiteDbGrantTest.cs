using FluiTec.AppFx.IdentityServer.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.LiteDb.Test
{
    [TestClass]
    public class LiteDbGrantTest : GrantTest
    {
        public LiteDbGrantTest() : base(Helper.GetDataService())
        {
        }

        [TestMethod]
        public override void CanAddAndGetGrant()
        {
            base.CanAddAndGetGrant();
        }

        [TestMethod]
        public override void CanAddAndGetGrants()
        {
            base.CanAddAndGetGrants();
        }

        [TestMethod]
        public override void CanUpdateGrant()
        {
            base.CanUpdateGrant();
        }

        [TestMethod]
        public override void CanDeleteGrant()
        {
            base.CanDeleteGrant();
        }

        [TestMethod]
        public override void CanGetByGrantKey()
        {
            base.CanGetByGrantKey();
        }

        [TestMethod]
        public override void CanFindBySubjectId()
        {
            base.CanFindBySubjectId();
        }

        [TestMethod]
        public override void CanRemoveByGrantKey()
        {
            base.CanRemoveByGrantKey();
        }

        [TestMethod]
        public override void CanRemoveBySubjectAndClient()
        {
            base.CanRemoveBySubjectAndClient();
        }

        [TestMethod]
        public override void CanRemoveBySubjectClientType()
        {
            base.CanRemoveBySubjectClientType();
        }
    }
}