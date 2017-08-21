using FluiTec.AppFx.Identity.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Identity.Dapper.Pgsql.Test
{
	[TestClass]
	public class PgsqlIdentityUserTest : IdentitiyUserTest
	{
		public PgsqlIdentityUserTest() : base(Helper.GetDataService())
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