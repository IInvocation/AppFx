using FluentMigrator;

namespace FluiTec.AppFx.IdentityServer.Dapper.Migrations.Versions.Migration1
{
	/// <summary>	A migration for the apiresourceclaim-table. </summary>
	[Migration(version: 3)]
	public class ApiResourceClaimTable : Migration
	{
		/// <summary>	Updates the database up to this migration. </summary>
		public override void Up()
		{
			IfDatabase("sqlserver", "postgres")
				.Create
				.Table(Globals.APIRESOURCECLAIM_TABLE)
				.InSchema(Globals.SCHEMA)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("ApiResourceId").AsInt32().NotNullable()
				.WithColumn("ClaimType").AsString(255).NotNullable();
			IfDatabase("sqlserver", "postgres")
				.Create
				.ForeignKey()
				.FromTable(Globals.APIRESOURCECLAIM_TABLE)
				.InSchema(Globals.SCHEMA)
				.ForeignColumn("ApiResourceId")
				.ToTable(Globals.APIRESOURCE_TABLE)
				.InSchema(Globals.SCHEMA)
				.PrimaryColumn("Id");

			IfDatabase("mysql")
				.Create
				.Table($"{Globals.SCHEMA}_{Globals.APIRESOURCECLAIM_TABLE}")
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("ApiResourceId").AsInt32().NotNullable()
				.WithColumn("ClaimType").AsString(255).NotNullable();
		}

		/// <summary>	Updates the database down to this migration. </summary>
		public override void Down()
		{
			IfDatabase("sqlserver", "postgres")
				.Delete
				.Table(Globals.APIRESOURCECLAIM_TABLE)
				.InSchema(Globals.SCHEMA);

			IfDatabase("mysql")
				.Delete
				.Table($"{Globals.SCHEMA}_{Globals.APIRESOURCECLAIM_TABLE}");
		}
	}
}