using FluentMigrator;

namespace FluiTec.AppFx.Identity.Dapper.Migration.Versions.Migration2
{
    /// <summary>   A user table. </summary>
    [Migration(7)]
    public class UserTable : FluentMigrator.Migration
    {
        /// <summary>   Ups this object. </summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Rename
                .Column("LoweredUserName")
                .OnTable(Globals.UserTable)
                .InSchema(Globals.Schema)
                .To("NormalizedName");

            IfDatabase("mysql")
                .Rename
                .Column("LoweredUserName")
                .OnTable($"{Globals.Schema}_{Globals.UserTable}")
                .To("NormalizedName");
        }

        /// <summary>   Downs this object. </summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Rename
                .Column("NormalizedName")
                .OnTable(Globals.UserTable)
                .InSchema(Globals.Schema)
                .To("LoweredUserName");

            IfDatabase("mysql")
                .Rename
                .Column("LoweredUserName")
                .OnTable($"{Globals.Schema}_{Globals.UserTable}")
                .To("LoweredName");
        }
    }
}