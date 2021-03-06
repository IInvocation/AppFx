﻿using FluiTec.AppFx.Identity.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Identity.Dapper.Mysql.Test
{
    [TestClass]
    public class MysqlIdentityClaimTest : IdentityClaimTest
    {
        public MysqlIdentityClaimTest() : base(Helper.GetDataService())
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

        [TestMethod]
        public override void CanGetClaimsByType()
        {
            base.CanGetClaimsByType();
        }

        [TestMethod]
        public override void CanGetByUserAndType()
        {
            base.CanGetByUserAndType();
        }

        [TestMethod]
        public override void CanGetByUser()
        {
            base.CanGetByUser();
        }
    }
}