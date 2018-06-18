using System;
using FluiTec.AppFx.Data.Dapper.Mssql;
using FluiTec.AppFx.DataProtection.Mssql;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var cs = "Data Source=DB1;Initial Catalog=AppFx;Integrated Security=False;User ID=appfx;Password=appfx;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var service =
                new MssqlDapperDataProtectionDataService(new MssqlDapperServiceOptions {ConnectionString = cs});
            if (service.CanMigrate())
                service.Migrate();
        }
    }
}
