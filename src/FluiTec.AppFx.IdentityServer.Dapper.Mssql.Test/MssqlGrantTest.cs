using FluiTec.AppFx.IdentityServer.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Dapper.Mssql.Test
{
	[TestClass]
	public class MssqlGrantTest : GrantTest
	{
		public MssqlGrantTest() : base(Helper.GetDataService())
		{
		}

		[TestMethod]
		public override void CanAddAndGetGrant()
		{
			base.CanAddAndGetGrant();
		}

		[TestMethod]
		public override void CanAddAndGetGrants()
		{
			base.CanAddAndGetGrants();
		}

		[TestMethod]
		public override void CanUpdateGrant()
		{
			base.CanUpdateGrant();
		}

		[TestMethod]
		public override void CanDeleteGrant()
		{
			base.CanDeleteGrant();
		}
	}
}