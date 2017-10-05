using FluentMigrator;

namespace FluiTec.AppFx.Identity.Dapper.Migrations.Migration1
{
	/// <summary>	A migration for the user-table. </summary>
	[Migration(version: 2)]
	public class UserLoginTable : Migration
	{
		/// <summary>	Updates the database up to this migration. </summary>
		public override void Up()
		{
			IfDatabase("sqlserver", "postgres")
				.Create
				.Table(Globals.USERLOGIN_TABLE)
				.InSchema(Globals.SCHEMA)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("ProviderName").AsString(255).NotNullable()
				.WithColumn("ProviderKey").AsString(45).NotNullable()
				.WithColumn("ProviderDisplayName").AsString(255).Nullable()
				.WithColumn("UserId").AsGuid().NotNullable();
			IfDatabase("sqlserver", "postgres")
				.Create
				.Index()
				.OnTable(Globals.USERLOGIN_TABLE)
				.InSchema(Globals.SCHEMA)
				.OnColumn("ProviderName").Ascending()
				.OnColumn("ProviderKey").Ascending()
				.WithOptions().Unique();
			IfDatabase("sqlserver", "postgres")
				.Create
				.ForeignKey()
				.FromTable(Globals.USERLOGIN_TABLE)
				.InSchema(Globals.SCHEMA)
				.ForeignColumn("UserId")
				.ToTable(Globals.USER_TABLE)
				.InSchema(Globals.SCHEMA)
				.PrimaryColumn("Identifier");
		}

		/// <summary>	Updates the database down to this migration. </summary>
		public override void Down()
		{
			IfDatabase("sqlserver", "postgres")
				.Delete
				.Table(Globals.USERLOGIN_TABLE)
				.InSchema(Globals.SCHEMA);
		}
	}
}