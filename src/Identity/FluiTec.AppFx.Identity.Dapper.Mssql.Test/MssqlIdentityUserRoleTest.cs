﻿using FluiTec.AppFx.Identity.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Identity.Dapper.Mssql.Test
{
    [TestClass]
    public class MssqlIdentityUserRoleTest : IdentityUserRoleTest
    {
        public MssqlIdentityUserRoleTest() : base(Helper.GetDataService())
        {
        }

        [TestMethod]
        public override void CanAddAndGetUserRole()
        {
            base.CanAddAndGetUserRole();
        }

        [TestMethod]
        public override void CanAddAndGetUserRoles()
        {
            base.CanAddAndGetUserRoles();
        }

        [TestMethod]
        public override void CanDeleteUser()
        {
            base.CanDeleteUser();
        }

        [TestMethod]
        public override void CanUpdateUserRole()
        {
            base.CanUpdateUserRole();
        }

        [TestMethod]
        public override void CanAddAndFindByUserIdAndRoleId()
        {
            base.CanAddAndFindByUserIdAndRoleId();
        }

        [TestMethod]
        public override void CanAddAndFindByUser()
        {
            base.CanAddAndFindByUser();
        }

        [TestMethod]
        public override void CanAddAndFindByRole()
        {
            base.CanAddAndFindByRole();
        }
    }
}