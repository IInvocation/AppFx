using FluentMigrator;

namespace FluiTec.AppFx.Identity.Dapper.Migration.Versions.Migration6
{
    /// <summary>   A user table. </summary>
    [Migration(11)]
    public class UserTable : FluentMigrator.Migration
    {
        /// <summary>   Collect the UP migration expressions. </summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Alter
                .Table(Globals.UserTable)
                .InSchema(Globals.Schema)
                .AddColumn("FullName").AsString(256).Nullable();

            IfDatabase("mysql")
                .Alter
                .Table($"{Globals.Schema}_{Globals.UserTable}")
                .InSchema(Globals.Schema)
                .AddColumn("FullName").AsString(256).Nullable();
        }

        /// <summary>   Collects the DOWN migration expressions. </summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Column("FullName")
                .FromTable(Globals.UserTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .Column("FullName")
                .FromTable($"{Globals.Schema}_{Globals.UserTable}");
        }
    }
}
