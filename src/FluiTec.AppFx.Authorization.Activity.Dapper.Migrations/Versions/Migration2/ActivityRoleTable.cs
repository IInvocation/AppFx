using FluentMigrator;

namespace FluiTec.AppFx.Authorization.Activity.Dapper.Migrations.Versions.Migration2
{
    /// <summary>An activity role table.</summary>
    [Migration(2)]
    public class ActivityRoleTable : Migration
    {
        /// <summary>Name of the activity foreign key.</summary>
        private const string ActivityForeignKeyName = "IX_Activity_ActivityRole";

        /// <summary>Name of the role foreign key.</summary>
        private const string RoleForeignKeyName = "IX_Role_ActivityRole";

        /// <summary>Ups this object.</summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .Table(Globals.ActivityRoleTable)
                .InSchema(Globals.Schema)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ActivityId").AsInt32().NotNullable()
                .WithColumn("RoleId").AsInt32().NotNullable()
                .WithColumn("Allow").AsBoolean().Nullable();

            IfDatabase("sqlserver", "postgres")
                .Create
                .ForeignKey(ActivityForeignKeyName)
                .FromTable(Globals.ActivityRoleTable)
                .InSchema(Globals.Schema)
                .ForeignColumn("ActivityId")
                .ToTable(Globals.ActivityTable)
                .InSchema(Globals.Schema)
                .PrimaryColumn("Id");

            IfDatabase("sqlserver", "postgres")
                .Create
                .ForeignKey(RoleForeignKeyName)
                .FromTable(Globals.ActivityRoleTable)
                .InSchema(Globals.Schema)
                .ForeignColumn("RoleId")
                .ToTable("Role")
                .InSchema("AppFxIdentity")
                .PrimaryColumn("Id");


            IfDatabase("mysql")
                .Create
                .Table($"{Globals.Schema}_{Globals.ActivityRoleTable}")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ActivityId").AsInt32().NotNullable()
                .WithColumn("RoleId").AsInt32().NotNullable()
                .WithColumn("Allow").AsBoolean().Nullable();
        }

        /// <summary>Downs this object.</summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .ForeignKey(ActivityForeignKeyName)
                .OnTable(Globals.ActivityRoleTable)
                .InSchema(Globals.Schema);

            IfDatabase("sqlserver", "postgres")
                .Delete
                .ForeignKey(RoleForeignKeyName)
                .OnTable(Globals.ActivityRoleTable)
                .InSchema(Globals.Schema);

            IfDatabase("sqlserver", "postgres")
                .Delete
                .Table(Globals.ActivityRoleTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .Table($"{Globals.Schema}_{Globals.ActivityRoleTable}");
        }
    }
}