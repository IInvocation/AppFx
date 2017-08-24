using FluiTec.AppFx.Identity.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Identity.Dapper.Mysql.Test
{
	[TestClass]
	public class MysqlIdentityRoleTest : IdentityRoleTest
	{
		public MysqlIdentityRoleTest() : base(Helper.GetDataService())
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

		[TestMethod]
		public override void CanAddAndGetRoleByIdentifier()
		{
			base.CanAddAndGetRoleByIdentifier();
		}

		[TestMethod]
		public override void CanAddAndFindByLoweredName()
		{
			base.CanAddAndFindByLoweredName();
		}

		[TestMethod]
		public override void CanAddAndFindByIds()
		{
			base.CanAddAndFindByIds();
		}
	}
}