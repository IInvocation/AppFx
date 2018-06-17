using FluentMigrator;

namespace FluiTec.AppFx.IdentityServer.Dapper.Migration.Versions.Migration1
{
    /// <summary>	A migration for the apiresourcescope-table. </summary>
    [Migration(4)]
    public class ApiResourceScopeTable : FluentMigrator.Migration
    {
        /// <summary>	Updates the database up to this migration. </summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .Table(Globals.ApiresourcescopeTable)
                .InSchema(Globals.Schema)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ApiResourceId").AsInt32().NotNullable()
                .WithColumn("ScopeId").AsInt32().NotNullable();
            IfDatabase("sqlserver", "postgres")
                .Create
                .ForeignKey()
                .FromTable(Globals.ApiresourcescopeTable)
                .InSchema(Globals.Schema)
                .ForeignColumn("ApiResourceId")
                .ToTable(Globals.ApiresourceTable)
                .InSchema(Globals.Schema)
                .PrimaryColumn("Id");
            IfDatabase("sqlserver", "postgres")
                .Create
                .ForeignKey()
                .FromTable(Globals.ApiresourcescopeTable)
                .InSchema(Globals.Schema)
                .ForeignColumn("ScopeId")
                .ToTable(Globals.ScopeTable)
                .InSchema(Globals.Schema)
                .PrimaryColumn("Id");

            IfDatabase("mysql")
                .Create
                .Table($"{Globals.Schema}_{Globals.ApiresourcescopeTable}")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ApiResourceId").AsInt32().NotNullable()
                .WithColumn("ScopeId").AsInt32().NotNullable();
        }

        /// <summary>	Updates the database down to this migration. </summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Table(Globals.ApiresourcescopeTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .Table($"{Globals.Schema}_{Globals.ApiresourcescopeTable}");
        }
    }
}