using FluentMigrator;

namespace FluiTec.AppFx.IdentityServer.Dapper.Migrations.Versions.Migration1
{
	/// <summary>	A migration for the scope-table. </summary>
	[Migration(version: 1)]
	public class ScopeTable : Migration
	{
		/// <summary>	Updates the database up to this migration. </summary>
		public override void Up()
		{
			IfDatabase("sqlserver", "postgres")
				.Create
				.Table(Globals.SCOPE_TABLE)
				.InSchema(Globals.SCHEMA)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("Name").AsString(255).NotNullable()
				.WithColumn("DisplayName").AsString(255).NotNullable()
				.WithColumn("Description").AsString(int.MaxValue).Nullable()
				.WithColumn("Required").AsBoolean().NotNullable()
				.WithColumn("Emphasize").AsBoolean().NotNullable()
				.WithColumn("ShowInDiscoveryDocument").AsBoolean().NotNullable();

			IfDatabase("mysql")
				.Create
				.Table($"{Globals.SCHEMA}_{Globals.SCOPE_TABLE}")
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("Name").AsString(255).NotNullable()
				.WithColumn("DisplayName").AsString(255).NotNullable()
				.WithColumn("Description").AsString(int.MaxValue).Nullable()
				.WithColumn("Required").AsBoolean().NotNullable()
				.WithColumn("Emphasize").AsBoolean().NotNullable()
				.WithColumn("ShowInDiscoveryDocument").AsBoolean().NotNullable();
		}

		/// <summary>	Updates the database down to this migration. </summary>
		public override void Down()
		{
			IfDatabase("sqlserver", "postgres")
				.Delete
				.Table(Globals.SCOPE_TABLE)
				.InSchema(Globals.SCHEMA);

			IfDatabase("mysql")
				.Delete
				.Table($"{Globals.SCHEMA}_{Globals.SCOPE_TABLE}");
		}
	}
}