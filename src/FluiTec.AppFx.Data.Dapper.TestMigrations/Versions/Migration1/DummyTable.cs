using FluentMigrator;

namespace FluiTec.AppFx.Data.Dapper.TestMigrations.Migration1
{
	/// <summary>	A migration that manages the DummyTable. </summary>
	[Migration(version: 1)]
	public class DummyTable : Migration
	{
		/// <summary>	Updates the database up to this migration. </summary>
		public override void Up()
		{
			Create.Table("Dummy")
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("Name").AsString(256).NotNullable()
				;
		}

		/// <summary>	Updates the database down to this migration. </summary>
		public override void Down()
		{
			Delete.Table("Dummy");
		}
	}
}
