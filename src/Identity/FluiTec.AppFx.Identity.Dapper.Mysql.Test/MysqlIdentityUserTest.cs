﻿using FluiTec.AppFx.Identity.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Identity.Dapper.Mysql.Test
{
    [TestClass]
    public class MysqlIdentityUserTest : IdentityUserTest
    {
        public MysqlIdentityUserTest() : base(Helper.GetDataService())
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
    }
}