﻿using FluiTec.AppFx.UnitTesting.Helper;

namespace FluiTec.AppFx.Data.Dapper.Mssql.Test.Fixtures
{
    /// <summary>	A dummy mssql data service. </summary>
    public class DummyMssqlDataService : DapperDataService
    {
	    /// <summary>	Default constructor. </summary>
	    public DummyMssqlDataService() : base("Data Source=.\\SQLEXPRESS;Initial Catalog=AppFx2;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", new MssqlConnectionFactory())
	    {
			var helper = new ConnectionStringHelper();
	    }

	    /// <summary>	The name. </summary>
	    public override string Name => "DummyMssqlDataService";
    }
}
