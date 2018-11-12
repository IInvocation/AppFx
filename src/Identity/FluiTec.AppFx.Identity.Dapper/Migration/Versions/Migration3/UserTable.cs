using FluentMigrator;

namespace FluiTec.AppFx.Identity.Dapper.Migration.Versions.Migration3
{
    /// <summary>A user table.</summary>
    [Migration(8)]
    public class UserTable : FluentMigrator.Migration
    {
        /// <summary>Name of the unique mail index.</summary>
        private const string UniqueMailIndexName = "UX_NormalizedEmail";

        /// <summary>Name of the unique name index.</summary>
        private const string UniqueNameIndexName = "UX_UniqueName";

        /// <summary>Ups this object.</summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Alter
                .Table(Globals.UserTable)
                .InSchema(Globals.Schema)
                .AlterColumn("NormalizedEmail").AsString(256).NotNullable().Unique(UniqueMailIndexName);

            IfDatabase("sqlserver", "postgres")
                .Alter
                .Table(Globals.UserTable)
                .InSchema(Globals.Schema)
                .AlterColumn("Name").AsString(256).NotNullable().Unique(UniqueNameIndexName);
        }

        /// <summary>Downs this object.</summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Index(UniqueMailIndexName)
                .OnTable(Globals.UserTable)
                .InSchema(Globals.Schema);

            IfDatabase("sqlserver", "postgres")
                .Delete
                .Index(UniqueNameIndexName)
                .OnTable(Globals.UserTable)
                .InSchema(Globals.Schema);
        }
    }
}