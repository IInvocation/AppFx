using FluentMigrator;

namespace FluiTec.AppFx.Identity.Dapper.Migration.Versions.Migration1
{
    /// <summary>	A migration for the userrole-table. </summary>
    [Migration(4)]
    public class UserRoleTable : FluentMigrator.Migration
    {
        /// <summary>	Updates the database up to this migration. </summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .Table(Globals.UserroleTable)
                .InSchema(Globals.Schema)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt32().NotNullable()
                .WithColumn("RoleId").AsInt32().NotNullable();
            IfDatabase("sqlserver", "postgres")
                .Create
                .ForeignKey()
                .FromTable(Globals.UserroleTable)
                .InSchema(Globals.Schema)
                .ForeignColumn("UserId")
                .ToTable(Globals.UserTable)
                .InSchema(Globals.Schema)
                .PrimaryColumn("Id");
            IfDatabase("sqlserver", "postgres")
                .Create
                .ForeignKey()
                .FromTable(Globals.UserroleTable)
                .InSchema(Globals.Schema)
                .ForeignColumn("RoleId")
                .ToTable(Globals.RoleTable)
                .InSchema(Globals.Schema)
                .PrimaryColumn("Id");

            IfDatabase("mysql")
                .Create
                .Table($"{Globals.Schema}_{Globals.UserroleTable}")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt32().NotNullable()
                .WithColumn("RoleId").AsInt32().NotNullable();
            IfDatabase("mysql")
                .Create
                .ForeignKey()
                .FromTable($"{Globals.Schema}_{Globals.UserroleTable}")
                .ForeignColumn("UserId")
                .ToTable($"{Globals.Schema}_{Globals.UserTable}")
                .PrimaryColumn("Id");
        }

        /// <summary>	Updates the database down to this migration. </summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Table(Globals.UserroleTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .Table($"{Globals.Schema}_{Globals.UserroleTable}");
        }
    }
}