using FluentMigrator;

namespace FluiTec.AppFx.IdentityServer.Dapper.Migration.Versions.Migration1
{
    /// <summary>	A migration for the grant-table. </summary>
    [Migration(8)]
    public class GrantTable : FluentMigrator.Migration
    {
        /// <summary>	Updates the database up to this migration. </summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .Table(Globals.GrantTable)
                .InSchema(Globals.Schema)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("GrantKey").AsString(255).NotNullable().Unique()
                .WithColumn("Type").AsString(255).NotNullable()
                .WithColumn("SubjectId").AsString(255).NotNullable()
                .WithColumn("ClientId").AsString(255).NotNullable()
                .WithColumn("CreationTime").AsDateTime().NotNullable()
                .WithColumn("Expiration").AsDateTime().Nullable()
                .WithColumn("Data").AsString(int.MaxValue);


            IfDatabase("mysql")
                .Create
                .Table($"{Globals.Schema}_{Globals.GrantTable}")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("GrantKey").AsString(255).NotNullable()
                .WithColumn("Type").AsString(255).NotNullable()
                .WithColumn("SubjectId").AsString(255).NotNullable()
                .WithColumn("ClientId").AsString(255).NotNullable()
                .WithColumn("CreationTime").AsDateTime().NotNullable()
                .WithColumn("Expiration").AsDateTime().Nullable()
                .WithColumn("Data").AsString(int.MaxValue);
        }

        /// <summary>	Updates the database down to this migration. </summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Table(Globals.GrantTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .Table($"{Globals.Schema}_{Globals.GrantTable}");
        }
    }
}