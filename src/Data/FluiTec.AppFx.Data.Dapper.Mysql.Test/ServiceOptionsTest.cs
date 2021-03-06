﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Data.Dapper.Mysql.Test
{
    [TestClass]
    public class ServiceOptionsTest
    {
        [TestMethod]
        public void CanCreate()
        {
            var options = new MysqlDapperServiceOptions();
            Assert.IsNotNull(options);
            Assert.IsNotNull(options.ConnectionFactory);
        }

        [TestMethod]
        public void CanGetAndModifyConnectionString()
        {
            var options = new MysqlDapperServiceOptions();
            Assert.IsNotNull(options);

            options.ConnectionString = "abc";
            Assert.AreEqual("abc", options.ConnectionString);
        }
    }
}