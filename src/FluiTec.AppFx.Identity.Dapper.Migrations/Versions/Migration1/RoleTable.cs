using FluentMigrator;

namespace FluiTec.AppFx.Identity.Dapper.Migrations.Migration1
{
	/// <summary>	A migration for the role-table. </summary>
	[Migration(version: 3)]
	public class RoleTable : Migration
	{
		/// <summary>	Updates the database up to this migration. </summary>
		public override void Up()
		{
			IfDatabase("sqlserver", "postgres")
				.Create
				.Table(Globals.ROLE_TABLE)
				.InSchema(Globals.SCHEMA)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("Identifier").AsGuid().NotNullable()
				.WithColumn("ApplicationId").AsInt32().NotNullable()
				.WithColumn("Name").AsString(256).NotNullable()
				.WithColumn("LoweredName").AsString(256).NotNullable()
				.WithColumn("Description").AsString(256).Nullable();

			IfDatabase("mysql")
				.Create
				.Table($"{Globals.SCHEMA}_{Globals.ROLE_TABLE}")
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("Identifier").AsCustom("CHAR(36)").NotNullable()
				.WithColumn("ApplicationId").AsInt32().NotNullable()
				.WithColumn("Name").AsString(256).NotNullable()
				.WithColumn("LoweredName").AsString(256).NotNullable()
				.WithColumn("Description").AsString(256).Nullable();
		}

		/// <summary>	Updates the database down to this migration. </summary>
		public override void Down()
		{
			IfDatabase("sqlserver", "postgres")
				.Delete
				.Table(Globals.ROLE_TABLE)
				.InSchema(Globals.SCHEMA);

			IfDatabase("mysql")
				.Delete
				.Table($"{Globals.SCHEMA}_{Globals.ROLE_TABLE}");
		}
	}
}