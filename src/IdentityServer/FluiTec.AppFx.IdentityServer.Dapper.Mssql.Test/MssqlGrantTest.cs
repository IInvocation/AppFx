﻿using FluiTec.AppFx.IdentityServer.Test;
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

        [TestMethod]
        public override void CanGetByGrantKey()
        {
            base.CanGetByGrantKey();
        }

        [TestMethod]
        public override void CanFindBySubjectId()
        {
            base.CanFindBySubjectId();
        }

        [TestMethod]
        public override void CanRemoveByGrantKey()
        {
            base.CanRemoveByGrantKey();
        }

        [TestMethod]
        public override void CanRemoveBySubjectAndClient()
        {
            base.CanRemoveBySubjectAndClient();
        }

        [TestMethod]
        public override void CanRemoveBySubjectClientType()
        {
            base.CanRemoveBySubjectClientType();
        }
    }
}