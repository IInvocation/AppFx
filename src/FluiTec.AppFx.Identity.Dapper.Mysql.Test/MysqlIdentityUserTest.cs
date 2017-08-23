using FluiTec.AppFx.Identity.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Identity.Dapper.Mysql.Test
{
	[TestClass]
	public class MysqlIdentityUserTest : IdentitiyUserTest
	{
		public MysqlIdentityUserTest() : base(Helper.GetDataService())
		{
			
		}

		[TestMethod]
		public override void CanAddAndGetUser()
		{
			base.CanAddAndGetUser();
		}

		[TestMethod]
		public override void CanAddAndGetUsers()
		{
			base.CanAddAndGetUsers();
		}

		[TestMethod]
		public override void CanUpdateUser()
		{
			base.CanUpdateUser();
		}

		[TestMethod]
		public override void CanDeleteUser()
		{
			base.CanDeleteUser();
		}
	}
}