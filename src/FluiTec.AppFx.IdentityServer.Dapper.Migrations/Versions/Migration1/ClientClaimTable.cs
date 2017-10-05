using FluentMigrator;

namespace FluiTec.AppFx.IdentityServer.Dapper.Migrations.Versions.Migration1
{
	/// <summary>	A migration for the clientclaim-table. </summary>
	[Migration(version: 6)]
	public class ClientClaimTable : Migration
	{
		/// <summary>	Updates the database up to this migration. </summary>
		public override void Up()
		{
			IfDatabase("sqlserver", "postgres")
				.Create
				.Table(Globals.CLIENTCLAIM_TABLE)
				.InSchema(Globals.SCHEMA)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("ClientId").AsInt32().NotNullable()
				.WithColumn("ClaimType").AsString(255).NotNullable()
				.WithColumn("ClaimValue").AsString(255).Nullable();
			IfDatabase("sqlserver", "postgres")
				.Create
				.ForeignKey()
				.FromTable(Globals.CLIENTCLAIM_TABLE)
				.InSchema(Globals.SCHEMA)
				.ForeignColumn("ClientId")
				.ToTable(Globals.CLIENT_TABLE)
				.InSchema(Globals.SCHEMA)
				.PrimaryColumn("Id");

			IfDatabase("mysql")
				.Create
				.Table($"{Globals.SCHEMA}_{Globals.CLIENTCLAIM_TABLE}")
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
				.Table(Globals.CLIENTCLAIM_TABLE)
				.InSchema(Globals.SCHEMA);

			IfDatabase("mysql")
				.Delete
				.Table($"{Globals.SCHEMA}_{Globals.CLIENTCLAIM_TABLE}");
		}
	}
}