﻿using FluentMigrator.Runner.VersionTableInfo;
using FluiTec.AppFx.UnitTesting.Helper;

namespace FluiTec.AppFx.Data.Dapper.Mssql.Test.Fixtures
{
    /// <summary>	A dummy mssql data service. </summary>
    public class DummyMssqlDataService : MssqlDapperDataService
    {
        /// <summary>	Default constructor. </summary>
        public DummyMssqlDataService() : base(ConnectionStringHelper.GetConnectionStringFor("MSSQL"))
        {
        }

        /// <summary>	The name. </summary>
        public override string Name => "DummyMssqlDataService";

        public override SqlType SqlType => SqlType.Mssql;

        public override IVersionTableMetaData MetaData => null;
    }
}