using FluentMigrator;

namespace FluiTec.AppFx.IdentityServer.Dapper.Migrations.Versions.Migration1
{
	/// <summary>	A migration for the client-table. </summary>
	[Migration(version: 5)]
	public class ClientTable : Migration
	{
		/// <summary>	Updates the database up to this migration. </summary>
		public override void Up()
		{
			IfDatabase("sqlserver", "postgres")
				.Create
				.Table(Globals.CLIENT_TABLE)
				.InSchema(Globals.SCHEMA)
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
				.Table($"{Globals.SCHEMA}_{Globals.CLIENT_TABLE}")
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
				.Table(Globals.CLIENT_TABLE)
				.InSchema(Globals.SCHEMA);

			IfDatabase("mysql")
				.Delete
				.Table($"{Globals.SCHEMA}_{Globals.CLIENT_TABLE}");
		}
	}
}