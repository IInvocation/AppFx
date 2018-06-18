using FluentMigrator;

namespace FluiTec.AppFx.IdentityServer.Dapper.Migration.Versions.Migration1
{
    /// <summary>	A migration for the identityresource-table. </summary>
    [Migration(9)]
    public class IdentityResourceTable : FluentMigrator.Migration
    {
        /// <summary>	Updates the database up to this migration. </summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .Table(Globals.IdentityresourceTable)
                .InSchema(Globals.Schema)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("DisplayName").AsString(255).NotNullable()
                .WithColumn("Description").AsString(255).Nullable()
                .WithColumn("Enabled").AsBoolean().NotNullable()
                .WithColumn("Required").AsBoolean().NotNullable()
                .WithColumn("Emphasize").AsBoolean().NotNullable()
                .WithColumn("ShowInDiscoveryDocument").AsBoolean().NotNullable();


            IfDatabase("mysql")
                .Create
                .Table($"{Globals.Schema}_{Globals.IdentityresourceTable}")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("DisplayName").AsString(255).NotNullable()
                .WithColumn("Description").AsString(255).Nullable()
                .WithColumn("Enabled").AsBoolean().NotNullable()
                .WithColumn("Required").AsBoolean().NotNullable()
                .WithColumn("Emphasize").AsBoolean().NotNullable()
                .WithColumn("ShowInDiscoveryDocument").AsBoolean().NotNullable();
        }

        /// <summary>	Updates the database down to this migration. </summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Table(Globals.IdentityresourceTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .Table($"{Globals.Schema}_{Globals.IdentityresourceTable}");
        }
    }
}