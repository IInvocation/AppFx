using FluentMigrator;

namespace FluiTec.AppFx.Identity.Dapper.Migrations.Migration1
{
    /// <summary>	A migration for the user-table. </summary>
    [Migration(2)]
    public class UserLoginTable : Migration
    {
        /// <summary>	Updates the database up to this migration. </summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .Table(Globals.UserloginTable)
                .InSchema(Globals.Schema)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ProviderName").AsString(255).NotNullable()
                .WithColumn("ProviderKey").AsString(45).NotNullable()
                .WithColumn("ProviderDisplayName").AsString(255).Nullable()
                .WithColumn("UserId").AsGuid().NotNullable();
            IfDatabase("sqlserver", "postgres")
                .Create
                .Index()
                .OnTable(Globals.UserloginTable)
                .InSchema(Globals.Schema)
                .OnColumn("ProviderName").Ascending()
                .OnColumn("ProviderKey").Ascending()
                .WithOptions().Unique();
            IfDatabase("sqlserver", "postgres")
                .Create
                .ForeignKey()
                .FromTable(Globals.UserloginTable)
                .InSchema(Globals.Schema)
                .ForeignColumn("UserId")
                .ToTable(Globals.UserTable)
                .InSchema(Globals.Schema)
                .PrimaryColumn("Identifier");

            IfDatabase("mysql")
                .Create
                .Table($"{Globals.Schema}_{Globals.UserloginTable}")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ProviderName").AsString(255).NotNullable()
                .WithColumn("ProviderKey").AsString(45).NotNullable()
                .WithColumn("ProviderDisplayName").AsString(255).Nullable()
                .WithColumn("UserId").AsCustom("CHAR(36)").NotNullable();
            IfDatabase("mysql")
                .Create
                .Index()
                .OnTable($"{Globals.Schema}_{Globals.UserloginTable}")
                .OnColumn("ProviderName").Ascending()
                .OnColumn("ProviderKey").Ascending()
                .WithOptions().Unique();
        }

        /// <summary>	Updates the database down to this migration. </summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Table(Globals.UserloginTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .Table($"{Globals.Schema}_{Globals.UserloginTable}");
        }
    }
}