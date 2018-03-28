﻿using FluiTec.AppFx.Identity.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Identity.Dapper.Pgsql.Test
{
    [TestClass]
    public class PgsqlIdentityUserLoginTest : IdentityUserLoginTest
    {
        public PgsqlIdentityUserLoginTest() : base(Helper.GetDataService())
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
        public override void CanFindByNameAndKey()
        {
            base.CanFindByNameAndKey();
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

        [TestMethod]
        public override void CanAddAndFindByUserId()
        {
            base.CanAddAndFindByUserId();
        }

        [TestMethod]
        public override void CanRemoveByNameAndKey()
        {
            base.CanRemoveByNameAndKey();
        }
    }
}