using FluentMigrator;

namespace FluiTec.AppFx.IdentityServer.Dapper.Migrations.Versions.Migration1
{
	/// <summary>	A migration for the signingcredential-table. </summary>
	[Migration(version: 12)]
	public class SigningCredentialTable : Migration
	{
		/// <summary>	Updates the database up to this migration. </summary>
		public override void Up()
		{
			IfDatabase("sqlserver", "postgres")
				.Create
				.Table(Globals.SIGNINGCREDENTIAL_TABLE)
				.InSchema(Globals.SCHEMA)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("Issued").AsDateTime().NotNullable()
				.WithColumn("Contents").AsString(int.MaxValue);

			IfDatabase("mysql")
				.Create
				.Table($"{Globals.SCHEMA}_{Globals.SIGNINGCREDENTIAL_TABLE}")
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("Issued").AsDateTime().NotNullable()
				.WithColumn("Contents").AsString(int.MaxValue);
		}

		/// <summary>	Updates the database down to this migration. </summary>
		public override void Down()
		{
			IfDatabase("sqlserver", "postgres")
				.Delete
				.Table(Globals.SIGNINGCREDENTIAL_TABLE)
				.InSchema(Globals.SCHEMA);

			IfDatabase("mysql")
				.Delete
				.Table($"{Globals.SCHEMA}_{Globals.SIGNINGCREDENTIAL_TABLE}");
		}
	}
}