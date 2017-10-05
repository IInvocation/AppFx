using FluentMigrator;

namespace FluiTec.AppFx.Identity.Dapper.Migrations.Migration1
{
	/// <summary>	A migration for the userrole-table. </summary>
	[Migration(version: 4)]
	public class UserRoleTable : Migration
	{
		/// <summary>	Updates the database up to this migration. </summary>
		public override void Up()
		{
			IfDatabase("sqlserver", "postgres")
				.Create
				.Table(Globals.USERROLE_TABLE)
				.InSchema(Globals.SCHEMA)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("UserId").AsInt32().NotNullable()
				.WithColumn("RoleId").AsInt32().NotNullable();
			IfDatabase("sqlserver", "postgres")
				.Create
				.ForeignKey()
				.FromTable(Globals.USERROLE_TABLE)
				.InSchema(Globals.SCHEMA)
				.ForeignColumn("UserId")
				.ToTable(Globals.USER_TABLE)
				.InSchema(Globals.SCHEMA)
				.PrimaryColumn("Id");
			IfDatabase("sqlserver", "postgres")
				.Create
				.ForeignKey()
				.FromTable(Globals.USERROLE_TABLE)
				.InSchema(Globals.SCHEMA)
				.ForeignColumn("RoleId")
				.ToTable(Globals.ROLE_TABLE)
				.InSchema(Globals.SCHEMA)
				.PrimaryColumn("Id");

			IfDatabase("mysql")
				.Create
				.Table($"{Globals.SCHEMA}_{Globals.USERROLE_TABLE}")
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("UserId").AsInt32().NotNullable()
				.WithColumn("RoleId").AsInt32().NotNullable();
			IfDatabase("mysql")
				.Create
				.ForeignKey()
				.FromTable($"{Globals.SCHEMA}_{Globals.USERROLE_TABLE}")
				.ForeignColumn("UserId")
				.ToTable($"{Globals.SCHEMA}_{Globals.USER_TABLE}")
				.PrimaryColumn("Id");
		}

		/// <summary>	Updates the database down to this migration. </summary>
		public override void Down()
		{
			IfDatabase("sqlserver", "postgres")
				.Delete
				.Table(Globals.USERROLE_TABLE)
				.InSchema(Globals.SCHEMA);

			IfDatabase("mysql")
				.Delete
				.Table($"{Globals.SCHEMA}_{Globals.USERROLE_TABLE}");
		}
	}
}