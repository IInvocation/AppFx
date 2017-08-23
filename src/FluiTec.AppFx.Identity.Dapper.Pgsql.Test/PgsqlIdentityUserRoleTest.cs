using FluiTec.AppFx.Identity.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Identity.Dapper.Pgsql.Test
{
	[TestClass]
	public class PgsqlIdentityUserRoleTest : IdentityUserRoleTest
	{
		public PgsqlIdentityUserRoleTest() : base(Helper.GetDataService())
		{
		}

		[TestMethod]
		public override void CanAddAndGetUserRole()
		{
			base.CanAddAndGetUserRole();
		}

		[TestMethod]
		public override void CanAddAndGetUserRoles()
		{
			base.CanAddAndGetUserRoles();
		}

		[TestMethod]
		public override void CanDeleteUser()
		{
			base.CanDeleteUser();
		}

		[TestMethod]
		public override void CanUpdateUserRole()
		{
			base.CanUpdateUserRole();
		}
	}
}