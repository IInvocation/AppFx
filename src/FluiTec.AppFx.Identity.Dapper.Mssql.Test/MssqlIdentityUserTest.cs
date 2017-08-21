using FluiTec.AppFx.Identity.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Identity.Dapper.Mssql.Test
{
	[TestClass]
	public class MssqlIdentityUserTest : IdentitiyUserTest
	{
		public MssqlIdentityUserTest() : base(Helper.GetDataService())
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