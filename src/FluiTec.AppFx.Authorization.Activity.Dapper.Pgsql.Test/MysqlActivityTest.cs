using FluiTec.AppFx.Authorization.Activity.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Authorization.Activity.Dapper.Pgsql.Test
{
    /// <summary>A mssql activity test.</summary>
    [TestClass]
    public class PgsqlActivityTest : ActivityTest
    {
        /// <summary>Default constructor.</summary>
        public PgsqlActivityTest() : base(Helper.GetDataService())
        {
        }

        /// <summary>Can add and get activity.</summary>
        [TestMethod]
        public override void CanAddAndGetActivity()
        {
            base.CanAddAndGetActivity();
        }

        /// <summary>Can add and get activities.</summary>
        [TestMethod]
        public override void CanAddAndGetActivities()
        {
            base.CanAddAndGetActivities();
        }

        /// <summary>Can update activity.</summary>
        [TestMethod]
        public override void CanUpdateActivity()
        {
            base.CanUpdateActivity();
        }

        /// <summary>Can delete activity.</summary>
        [TestMethod]
        public override void CanDeleteActivity()
        {
            base.CanDeleteActivity();
        }
    }
}