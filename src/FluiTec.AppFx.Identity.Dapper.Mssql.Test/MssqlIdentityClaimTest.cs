using FluiTec.AppFx.Identity.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Identity.Dapper.Mssql.Test
{
	[TestClass]
	public class MssqlIdentityClaimTest : IdentityClaimTest
	{
		public MssqlIdentityClaimTest() : base(Helper.GetDataService())
		{
		}

		[TestMethod]
		public override void CanAddAndGetClaim()
		{
			base.CanAddAndGetClaim();
		}

		[TestMethod]
		public override void CanAddAndGetClaims()
		{
			base.CanAddAndGetClaims();
		}

		[TestMethod]
		public override void CanUpdateClaim()
		{
			base.CanUpdateClaim();
		}

		[TestMethod]
		public override void CanDeleteClaim()
		{
			base.CanDeleteClaim();
		}
	}
}