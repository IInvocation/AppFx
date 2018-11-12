using FluentMigrator;

namespace FluiTec.AppFx.Identity.Dapper.Migration.Versions.Migration7
{
    /// <summary>   A user table. </summary>
    [Migration(12)]
    public class UserTable : FluentMigrator.Migration
    {
        /// <summary>Name of the unique name index.</summary>
        private const string UniqueNameIndexName = "UX_UniqueName";

        /// <summary>   Collect the UP migration expressions. </summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Index(UniqueNameIndexName)
                .OnTable(Globals.UserTable)
                .InSchema(Globals.Schema);
        }

        /// <summary>   Collects the DOWN migration expressions. </summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Alter
                .Table(Globals.UserTable)
                .InSchema(Globals.Schema)
                .AlterColumn("Name").AsString(256).NotNullable().Unique(UniqueNameIndexName);
        }
    }
}
