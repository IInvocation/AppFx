using FluiTec.AppFx.IdentityServer.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Dapper.Pgsql.Test
{
    [TestClass]
    public class PgsqlSigningCredentialTest : SigningCredentialTest
    {
        public PgsqlSigningCredentialTest() : base(Helper.GetDataService())
        {
        }

        [TestMethod]
        public override void CanAddAndGetSigningCredential()
        {
            base.CanAddAndGetSigningCredential();
        }

        [TestMethod]
        public override void CanAddAndGetSigningCredentials()
        {
            base.CanAddAndGetSigningCredentials();
        }

        [TestMethod]
        public override void CanUpdateSigningCredential()
        {
            base.CanUpdateSigningCredential();
        }

        [TestMethod]
        public override void CanDeleteSigningCredential()
        {
            base.CanDeleteSigningCredential();
        }

        [TestMethod]
        public override void CanGetLatest()
        {
            base.CanGetLatest();
        }

        [TestMethod]
        public override void CanGetValidationValid()
        {
            base.CanGetValidationValid();
        }
    }
}