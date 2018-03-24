using FluentMigrator;

namespace FluiTec.AppFx.Authorization.Activity.Dapper.Migrations.Versions.Migration1
{
    /// <summary>An activity table.</summary>
    [Migration(1)]
    public class ActivityTable : Migration
    {
        /// <summary>Ups this object.</summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .Table(Globals.ActivityTable)
                .InSchema(Globals.Schema)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable();

            IfDatabase("mysql")
                .Create
                .Table($"{Globals.Schema}_{Globals.ActivityTable}")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable();
        }

        /// <summary>Downs this object.</summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Table(Globals.ActivityTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .Table($"{Globals.Schema}_{Globals.ActivityTable}");
        }
    }
}