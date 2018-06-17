using FluentMigrator;

namespace FluiTec.AppFx.IdentityServer.Dapper.Migration.Versions.Migration1
{
    /// <summary>	A migration for the signingcredential-table. </summary>
    [Migration(12)]
    public class SigningCredentialTable : FluentMigrator.Migration
    {
        /// <summary>	Updates the database up to this migration. </summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .Table(Globals.SigningcredentialTable)
                .InSchema(Globals.Schema)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Issued").AsDateTime().NotNullable()
                .WithColumn("Contents").AsString(int.MaxValue);

            IfDatabase("mysql")
                .Create
                .Table($"{Globals.Schema}_{Globals.SigningcredentialTable}")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Issued").AsDateTime().NotNullable()
                .WithColumn("Contents").AsString(int.MaxValue);
        }

        /// <summary>	Updates the database down to this migration. </summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Table(Globals.SigningcredentialTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .Table($"{Globals.Schema}_{Globals.SigningcredentialTable}");
        }
    }
}