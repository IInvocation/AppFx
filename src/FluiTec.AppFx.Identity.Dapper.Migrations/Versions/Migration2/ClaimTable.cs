using FluentMigrator;

namespace FluiTec.AppFx.Identity.Dapper.Migrations.Migration2
{
    /// <summary>	A migration for the claim-table. </summary>
    [Migration(version: 6)]
    public class ClaimTable : Migration
    {
        /// <summary>	Updates the database up to this migration. </summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Alter
                .Table(Globals.CLAIM_TABLE)
                .InSchema(Globals.SCHEMA)
                .AlterColumn("UserId").AsInt32().Nullable()
                .AddColumn("RoleId").AsInt32().Nullable();

            IfDatabase("mysql")
                .Alter
                .Table($"{Globals.SCHEMA}_{Globals.CLAIM_TABLE}")
                .AlterColumn("UserId").AsInt32().Nullable()
                .AddColumn("RoleId").AsInt32().Nullable();
        }

        /// <summary>	Updates the database down to this migration. </summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Alter
                .Table(Globals.CLAIM_TABLE)
                .InSchema(Globals.SCHEMA)
                .AlterColumn("UserId").AsInt32().NotNullable();
            IfDatabase("sqlserver", "postgres").Delete.Column("UserId").FromTable(Globals.CLAIM_TABLE).InSchema(Globals.SCHEMA);

            IfDatabase("mysql")
                .Alter
                .Table($"{Globals.SCHEMA}_{Globals.CLAIM_TABLE}")
                .AlterColumn("UserId").AsInt32().NotNullable();
            IfDatabase("mysql").Delete.Column("RoleId").FromTable($"{Globals.SCHEMA}_{Globals.CLAIM_TABLE}");
        }
    }
}
