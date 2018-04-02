using System;
using FluentMigrator;

namespace FluiTec.AppFx.Authorization.Activity.Dapper.Migrations.Versions.Migration3
{
    /// <summary>An activity table.</summary>
    [Migration(3)]
    public class ActivityTable : Migration
    {
        /// <summary>Ups this object.</summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Alter
                .Table(Globals.ActivityTable)
                .InSchema(Globals.Schema)
                .AddColumn("ResourceDisplayName").AsString().NotNullable()
                .AddColumn("GroupName").AsString().NotNullable()
                .AddColumn("GroupDisplayName").AsString().NotNullable();

            IfDatabase("mysql")
                .Alter
                .Table($"{Globals.Schema}_{Globals.ActivityTable}")
                .AddColumn("ResourceDisplayName").AsString().NotNullable()
                .AddColumn("GroupName").AsString().NotNullable()
                .AddColumn("GroupDisplayName").AsString().NotNullable();
        }

        /// <summary>Downs this object.</summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Column("ResourceDisplayName")
                .Column("GroupName")
                .Column("GroupDisplayName")
                .FromTable(Globals.ActivityTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .Column("ResourceDisplayName")
                .Column("GroupName")
                .Column("GroupDisplayName")
                .FromTable($"{Globals.Schema}_{Globals.ActivityTable}");
        }
    }
}
