using FluentMigrator;

namespace FluiTec.AppFx.Data.Dapper.TestMigrations.Migration2
{
	/// <summary>	A migration that manages the DummyTable. </summary>
	[Migration(version: 2)]
	public class DummyTable2 : Migration
	{
		/// <summary>	Updates the database up to this migration. </summary>
		public override void Up()
		{
		    Alter
		        .Table("Dummy")
		        .AlterColumn("Name").AsString(256).Nullable();
		}

		/// <summary>	Updates the database down to this migration. </summary>
		public override void Down()
		{
            Alter
			    .Table("Dummy")
                .AlterColumn("Name").AsString(256).NotNullable();
		}
	}
}
