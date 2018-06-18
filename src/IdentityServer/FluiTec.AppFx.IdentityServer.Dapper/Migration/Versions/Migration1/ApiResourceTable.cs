using FluentMigrator;

namespace FluiTec.AppFx.IdentityServer.Dapper.Migration.Versions.Migration1
{
    /// <summary>	A migration for the apiresource-table. </summary>
    [Migration(2)]
    public class ApiResourceTable : FluentMigrator.Migration
    {
        /// <summary>	Updates the database up to this migration. </summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .Table(Globals.ApiresourceTable)
                .InSchema(Globals.Schema)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("DisplayName").AsString(255).NotNullable()
                .WithColumn("Description").AsString(int.MaxValue).NotNullable()
                .WithColumn("Enabled").AsBoolean().NotNullable();

            IfDatabase("mysql")
                .Create
                .Table($"{Globals.Schema}_{Globals.ApiresourceTable}")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("DisplayName").AsString(255).NotNullable()
                .WithColumn("Description").AsString(int.MaxValue).NotNullable()
                .WithColumn("Enabled").AsBoolean().NotNullable();
        }

        /// <summary>	Updates the database down to this migration. </summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Table(Globals.ApiresourceTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .Table($"{Globals.Schema}_{Globals.ApiresourceTable}");
        }
    }
}