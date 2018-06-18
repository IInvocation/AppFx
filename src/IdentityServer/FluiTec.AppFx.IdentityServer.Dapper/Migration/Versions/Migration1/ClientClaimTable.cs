using FluentMigrator;

namespace FluiTec.AppFx.IdentityServer.Dapper.Migration.Versions.Migration1
{
    /// <summary>	A migration for the clientclaim-table. </summary>
    [Migration(6)]
    public class ClientClaimTable : FluentMigrator.Migration
    {
        /// <summary>	Updates the database up to this migration. </summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .Table(Globals.ClientclaimTable)
                .InSchema(Globals.Schema)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ClientId").AsInt32().NotNullable()
                .WithColumn("ClaimType").AsString(255).NotNullable()
                .WithColumn("ClaimValue").AsString(255).Nullable();
            IfDatabase("sqlserver", "postgres")
                .Create
                .ForeignKey()
                .FromTable(Globals.ClientclaimTable)
                .InSchema(Globals.Schema)
                .ForeignColumn("ClientId")
                .ToTable(Globals.ClientTable)
                .InSchema(Globals.Schema)
                .PrimaryColumn("Id");

            IfDatabase("mysql")
                .Create
                .Table($"{Globals.Schema}_{Globals.ClientclaimTable}")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ClientId").AsInt32().NotNullable()
                .WithColumn("ClaimType").AsString(255).NotNullable()
                .WithColumn("ClaimValue").AsString(255).Nullable();
        }

        /// <summary>	Updates the database down to this migration. </summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Table(Globals.ClientclaimTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .Table($"{Globals.Schema}_{Globals.ClientclaimTable}");
        }
    }
}