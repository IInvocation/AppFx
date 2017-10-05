using FluentMigrator;

namespace FluiTec.AppFx.Identity.Dapper.Migrations.Migration1
{
	/// <summary>	A migration for the claim-table. </summary>
	[Migration(version: 5)]
	public class ClaimTable : Migration
	{
		/// <summary>	Updates the database up to this migration. </summary>
		public override void Up()
		{
			IfDatabase("sqlserver", "postgres")
				.Create
				.Table(Globals.CLAIM_TABLE)
				.InSchema(Globals.SCHEMA)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("UserId").AsInt32().NotNullable()
				.WithColumn("Type").AsString(256).NotNullable()
				.WithColumn("Value").AsString(256).Nullable();
			IfDatabase("sqlserver", "postgres")
				.Create
				.ForeignKey()
				.FromTable(Globals.CLAIM_TABLE)
				.InSchema(Globals.SCHEMA)
				.ForeignColumn("UserId")
				.ToTable(Globals.USER_TABLE)
				.InSchema(Globals.SCHEMA)
				.PrimaryColumn("Id");
		}

		/// <summary>	Updates the database down to this migration. </summary>
		public override void Down()
		{
			IfDatabase("sqlserver", "postgres")
				.Delete
				.Table(Globals.CLAIM_TABLE)
				.InSchema(Globals.SCHEMA);
		}
	}
}