REM MsSQL-Server
..\packages\FluentMigrator.Tools.1.6.2\tools\AnyCPU\40\Migrate.exe --provider SqlServer2014 --assembly ".\Migration\FluiTec.AppFx.Data.Dapper.TestMigrations.dll" --conn "Data Source=<YourHost>;Initial Catalog=AppFx;Integrated Security=False;User ID=<YourUserName>;Password=<YourPassword>;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"

REM MySQL-Server
..\packages\FluentMigrator.Tools.1.6.2\tools\AnyCPU\40\Migrate.exe --provider MySql --assembly ".\Migration\FluiTec.AppFx.Data.Dapper.TestMigrations.dll"  --conn "server=<YourHost>;user=<YourUserName>;database=AppFx;port=3306;password=<YourPassword>;SslMode=none;ConnectionReset=true"

REM PgSQL-Server
..\packages\FluentMigrator.Tools.1.6.2\tools\AnyCPU\40\Migrate.exe --provider Postgres --assembly ".\Migration\FluiTec.AppFx.Data.Dapper.TestMigrations.dll"  --conn "User ID=<YourUserName>;Password=<YourPassword>;Host=<YourHost>;Port=5432;Database=AppFx;Pooling=true;"