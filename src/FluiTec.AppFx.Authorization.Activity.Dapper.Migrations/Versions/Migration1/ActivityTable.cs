using FluentMigrator;

namespace FluiTec.AppFx.Authorization.Activity.Dapper.Migrations.Versions.Migration1
{
    /// <summary>An activity table.</summary>
    [Migration(1)]
    public class ActivityTable : Migration
    {
        /// <summary>Name of the constraint.</summary>
        private const string ConstraintName = "UX_Name_ResourceName";

        /// <summary>Ups this object.</summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .Table(Globals.ActivityTable)
                .InSchema(Globals.Schema)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("ResourceName").AsString().NotNullable();

            IfDatabase("sqlserver", "postgres")
                .Create
                .UniqueConstraint(ConstraintName)
                .OnTable(Globals.ActivityTable)
                .WithSchema(Globals.Schema)
                .Columns("Name", "ResourceName");

            IfDatabase("mysql")
                .Create
                .Table($"{Globals.Schema}_{Globals.ActivityTable}")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("ResourceName").AsString().NotNullable();

            IfDatabase("mysql")
                .Create
                .UniqueConstraint(ConstraintName)
                .OnTable($"{Globals.Schema}_{Globals.ActivityTable}")
                .Columns("Name", "ResourceName");
        }

        /// <summary>Downs this object.</summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .UniqueConstraint(ConstraintName)
                .FromTable(Globals.ActivityTable)
                .InSchema(Globals.Schema);

            IfDatabase("sqlserver", "postgres")
                .Delete
                .Table(Globals.ActivityTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .UniqueConstraint(ConstraintName)
                .FromTable($"{Globals.Schema}_{Globals.ActivityTable}");

            IfDatabase("mysql")
                .Delete
                .Table($"{Globals.Schema}_{Globals.ActivityTable}");
        }
    }
}