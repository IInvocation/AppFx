using FluentMigrator;

namespace FluiTec.AppFx.IdentityServer.Dapper.Migration.Versions.Migration1
{
    /// <summary>	A migration for the identityresourceclaim-table. </summary>
    [Migration(10)]
    public class IdentityResourceClaimTable : FluentMigrator.Migration
    {
        /// <summary>	Updates the database up to this migration. </summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .Table(Globals.IdentityresourceclaimTable)
                .InSchema(Globals.Schema)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("IdentityResourceId").AsInt32().NotNullable()
                .WithColumn("ClaimType").AsString(255).NotNullable();
            IfDatabase("sqlserver", "postgres")
                .Create
                .ForeignKey()
                .FromTable(Globals.IdentityresourceclaimTable)
                .InSchema(Globals.Schema)
                .ForeignColumn("IdentityResourceId")
                .ToTable(Globals.IdentityresourceTable)
                .InSchema(Globals.Schema)
                .PrimaryColumn("Id");

            IfDatabase("mysql")
                .Create
                .Table($"{Globals.Schema}_{Globals.IdentityresourceclaimTable}")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("IdentityResourceId").AsInt32().NotNullable()
                .WithColumn("ClaimType").AsString(255).NotNullable();
        }

        /// <summary>	Updates the database down to this migration. </summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Table(Globals.IdentityresourceclaimTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .Table($"{Globals.Schema}_{Globals.IdentityresourceclaimTable}");
        }
    }
}