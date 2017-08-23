using FluiTec.AppFx.Identity.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Identity.Dapper.Mssql.Test
{
	[TestClass]
	public class MssqlIdentityRoleTest : IdentityRoleTest
	{
		public MssqlIdentityRoleTest() : base(Helper.GetDataService())
		{
		}

		[TestMethod]
		public override void CanAddAndGetRole()
		{
			base.CanAddAndGetRole();
		}

		[TestMethod]
		public override void CanAddAndGetRoles()
		{
			base.CanAddAndGetRoles();
		}

		[TestMethod]
		public override void CanDeleteRole()
		{
			base.CanDeleteRole();
		}

		[TestMethod]
		public override void CanUpdateRole()
		{
			base.CanUpdateRole();
		}
	}
}