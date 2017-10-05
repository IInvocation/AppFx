using FluentMigrator;

namespace FluiTec.AppFx.IdentityServer.Dapper.Migrations.Versions.Migration1
{
	/// <summary>	A migration for the apiresource-table. </summary>
	[Migration(version: 2)]
	public class ApiResourceTable : Migration
	{
		/// <summary>	Updates the database up to this migration. </summary>
		public override void Up()
		{
			IfDatabase("sqlserver", "postgres")
				.Create
				.Table(Globals.APIRESOURCE_TABLE)
				.InSchema(Globals.SCHEMA)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("Name").AsString(255).NotNullable()
				.WithColumn("DisplayName").AsString(255).NotNullable()
				.WithColumn("Description").AsString(int.MaxValue).NotNullable()
				.WithColumn("Enabled").AsBoolean().NotNullable();

			IfDatabase("mysql")
				.Create
				.Table($"{Globals.SCHEMA}_{Globals.APIRESOURCE_TABLE}")
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
				.Table(Globals.APIRESOURCE_TABLE)
				.InSchema(Globals.SCHEMA);

			IfDatabase("mysql")
				.Delete
				.Table($"{Globals.SCHEMA}_{Globals.APIRESOURCE_TABLE}");
		}
	}
}