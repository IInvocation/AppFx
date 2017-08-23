using FluiTec.AppFx.Identity.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Identity.Dapper.Mssql.Test
{
	[TestClass]
	public class MssqlIdentityUserLoginTest : IdentityUserLoginTest
	{
		public MssqlIdentityUserLoginTest() : base(Helper.GetDataService())
		{
		}

		[TestMethod]
		public override void CanAddAndGetLogin()
		{
			base.CanAddAndGetLogin();
		}

		[TestMethod]
		public override void CanAddAndGetLogins()
		{
			base.CanAddAndGetLogins();
		}

		[TestMethod]
		public override void CanUpdateLogin()
		{
			base.CanUpdateLogin();
		}

		[TestMethod]
		public override void CanDeleteUser()
		{
			base.CanDeleteUser();
		}
	}
}