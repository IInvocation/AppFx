using FluiTec.AppFx.Authorization.Activity.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Authorization.Activity.Dapper.Mysql.Test
{
    /// <summary>A mssql activity test.</summary>
    [TestClass]
    public class MysqlActivityTest : ActivityTest
    {
        /// <summary>Default constructor.</summary>
        public MysqlActivityTest() : base(Helper.GetDataService())
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