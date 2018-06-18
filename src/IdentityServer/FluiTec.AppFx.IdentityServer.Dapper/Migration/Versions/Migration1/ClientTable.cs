using FluentMigrator;

namespace FluiTec.AppFx.IdentityServer.Dapper.Migration.Versions.Migration1
{
    /// <summary>	A migration for the client-table. </summary>
    [Migration(5)]
    public class ClientTable : FluentMigrator.Migration
    {
        /// <summary>	Updates the database up to this migration. </summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .Table(Globals.ClientTable)
                .InSchema(Globals.Schema)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ClientId").AsString(255).NotNullable()
                .WithColumn("Name").AsString(255).Nullable()
                .WithColumn("Secret").AsString(int.MaxValue).NotNullable()
                .WithColumn("RedirectUri").AsString(int.MaxValue).Nullable()
                .WithColumn("PostLogoutUri").AsString(int.MaxValue).Nullable()
                .WithColumn("AllowOfflineAccess").AsBoolean().NotNullable()
                .WithColumn("GrantTypes").AsString(int.MaxValue).NotNullable();

            IfDatabase("mysql")
                .Create
                .Table($"{Globals.Schema}_{Globals.ClientTable}")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ClientId").AsString(255).NotNullable()
                .WithColumn("Name").AsString(255).Nullable()
                .WithColumn("Secret").AsString(int.MaxValue).NotNullable()
                .WithColumn("RedirectUri").AsString(int.MaxValue).Nullable()
                .WithColumn("PostLogoutUri").AsString(int.MaxValue).Nullable()
                .WithColumn("AllowOfflineAccess").AsBoolean().NotNullable()
                .WithColumn("GrantTypes").AsString(int.MaxValue).NotNullable();
        }

        /// <summary>	Updates the database down to this migration. </summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Table(Globals.ClientTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .Table($"{Globals.Schema}_{Globals.ClientTable}");
        }
    }
}