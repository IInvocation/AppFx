using FluiTec.AppFx.Authorization.Activity.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Authorization.Activity.Dapper.Pgsql.Test
{
    /// <summary>(Unit Test Class) a mssql activity role test.</summary>
    [TestClass]
    public class PgsqlActivityRoleTest : ActivityRoleTest
    {
        public PgsqlActivityRoleTest() : base(Helper.GetDataService(), Helper.GetIdentityDataService())
        {
        }

        /// <summary>Can add and get activity.</summary>
        [TestMethod]
        public override void CanAddAndGetActivityRole()
        {
            base.CanAddAndGetActivityRole();
        }

        /// <summary>Can add and get activities.</summary>
        [TestMethod]
        public override void CanAddAndGetActivityRoles()
        {
            base.CanAddAndGetActivityRoles();
        }

        /// <summary>Can update activity.</summary>
        [TestMethod]
        public override void CanUpdateActivityRole()
        {
            base.CanUpdateActivityRole();
        }

        /// <summary>Can delete activity.</summary>
        [TestMethod]
        public override void CanDeleteActivityRole()
        {
            base.CanDeleteActivityRole();
        }
    }
}