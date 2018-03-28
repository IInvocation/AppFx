using FluiTec.AppFx.Identity.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Identity.Dapper.Mssql.Test
{
	[TestClass]
	public class MssqlIdentityUserTest : IdentityUserTest
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

		[TestMethod]
		public override void CanAddAndGetUserByIdentifier()
		{
			base.CanAddAndGetUserByIdentifier();
		}

		[TestMethod]
		public override void CanAddAndFindByLoweredName()
		{
			base.CanAddAndFindByLoweredName();
		}

		[TestMethod]
		public override void CanAddAndFindByNormalizedEmail()
		{
			base.CanAddAndFindByNormalizedEmail();
		}

        [TestMethod]
	    public override void CanCount()
	    {
	        base.CanCount();
	    }
	}
}