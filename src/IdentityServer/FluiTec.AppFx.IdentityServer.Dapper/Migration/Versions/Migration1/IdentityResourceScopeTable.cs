using FluentMigrator;

namespace FluiTec.AppFx.IdentityServer.Dapper.Migration.Versions.Migration1
{
    /// <summary>	A migration for the identityresourcescope-table. </summary>
    [Migration(11)]
    public class IdentityResourceScopeTable : FluentMigrator.Migration
    {
        /// <summary>	Updates the database up to this migration. </summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .Table(Globals.IdentityresourcescopeTable)
                .InSchema(Globals.Schema)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("IdentityResourceId").AsInt32().NotNullable()
                .WithColumn("ScopeId").AsInt32().NotNullable();
            IfDatabase("sqlserver", "postgres")
                .Create
                .ForeignKey()
                .FromTable(Globals.IdentityresourcescopeTable)
                .InSchema(Globals.Schema)
                .ForeignColumn("IdentityResourceId")
                .ToTable(Globals.IdentityresourceTable)
                .InSchema(Globals.Schema)
                .PrimaryColumn("Id");
            IfDatabase("sqlserver", "postgres")
                .Create
                .ForeignKey()
                .FromTable(Globals.IdentityresourcescopeTable)
                .InSchema(Globals.Schema)
                .ForeignColumn("ScopeId")
                .ToTable(Globals.ScopeTable)
                .InSchema(Globals.Schema)
                .PrimaryColumn("Id");

            IfDatabase("mysql")
                .Create
                .Table($"{Globals.Schema}_{Globals.IdentityresourcescopeTable}")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("IdentityResourceId").AsInt32().NotNullable()
                .WithColumn("ScopeId").AsInt32().NotNullable();
        }

        /// <summary>	Updates the database down to this migration. </summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Table(Globals.IdentityresourcescopeTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .Table($"{Globals.Schema}_{Globals.IdentityresourcescopeTable}");
        }
    }
}