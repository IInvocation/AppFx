﻿using FluiTec.AppFx.IdentityServer.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Dapper.Pgsql.Test
{
	[TestClass]
	public class PgsqlClientClaimTest : ClientClaimTest
	{
		public PgsqlClientClaimTest() : base(Helper.GetDataService()) { }

		[TestMethod]
		public override void CanAddAndGetClientClaim()
		{
			base.CanAddAndGetClientClaim();
		}

		[TestMethod]
		public override void CanAddAndGetClientClaims()
		{
			base.CanAddAndGetClientClaims();
		}

		[TestMethod]
		public override void CanUpdateClient()
		{
			base.CanUpdateClient();
		}

		[TestMethod]
		public override void CanDeleteClient()
		{
			base.CanDeleteClient();
		}
	}
}