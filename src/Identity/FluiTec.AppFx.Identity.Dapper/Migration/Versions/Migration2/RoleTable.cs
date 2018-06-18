using FluentMigrator;

namespace FluiTec.AppFx.Identity.Dapper.Migration.Versions.Migration2
{
    /// <summary>   A role table. </summary>
    [Migration(6)]
    public class RoleTable : FluentMigrator.Migration
    {
        /// <summary>   Name of the unique name index. </summary>
        private const string UniqueNameIndexName = "UX_RoleName";

        /// <summary>   Name of the unique lowered name index. </summary>
        private const string UniqueLoweredNameIndexName = "UX_LoweredRoleName";

        /// <summary>   Ups this object. </summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Alter
                .Table(Globals.RoleTable)
                .InSchema(Globals.Schema)
                .AlterColumn("Name").AsString(256).NotNullable().Unique(UniqueNameIndexName)
                .AlterColumn("LoweredName").AsString(256).NotNullable().Unique(UniqueLoweredNameIndexName);

            IfDatabase("sqlserver", "postgres")
                .Rename
                .Column("LoweredName")
                .OnTable(Globals.RoleTable)
                .InSchema(Globals.Schema)
                .To("NormalizedName");

            IfDatabase("mysql")
                .Rename
                .Column("LoweredName")
                .OnTable($"{Globals.Schema}_{Globals.RoleTable}")
                .To("NormalizedName");
        }

        /// <summary>   Downs this object. </summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .UniqueConstraint(UniqueNameIndexName)
                .FromTable(Globals.RoleTable)
                .InSchema(Globals.Schema);

            IfDatabase("sqlserver", "postgres")
                .Rename
                .Column("NormalizedName")
                .OnTable(Globals.RoleTable)
                .InSchema(Globals.Schema)
                .To("LoweredName");

            IfDatabase("mysql")
                .Rename
                .Column("NormalizedName")
                .OnTable($"{Globals.Schema}_{Globals.RoleTable}")
                .To("LoweredName");
        }
    }
}