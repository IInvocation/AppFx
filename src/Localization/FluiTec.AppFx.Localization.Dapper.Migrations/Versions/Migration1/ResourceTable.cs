using FluentMigrator;

namespace FluiTec.AppFx.Localization.Dapper.Migrations.Versions.Migration1
{
    /// <summary>A migration for the resource table.</summary>
    [Migration(1)]
    public class ResourceTable : Migration
    {
        /// <summary>Ups this object.</summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .Table(Globals.ResourceTable)
                .InSchema(Globals.Schema)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ResourceKey").AsString().NotNullable().Unique()
                .WithColumn("Author").AsString().NotNullable()
                .WithColumn("FromCode").AsBoolean().NotNullable()
                .WithColumn("IsModified").AsBoolean().Nullable()
                .WithColumn("ModificationDate").AsDateTime().Nullable()
                .WithColumn("IsHidden").AsBoolean().NotNullable();

            IfDatabase("mysql")
                .Create
                .Table($"{Globals.Schema}_{Globals.ResourceTable}")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ResourceKey").AsString().NotNullable().Unique()
                .WithColumn("Author").AsString().NotNullable()
                .WithColumn("FromCode").AsBoolean().NotNullable()
                .WithColumn("IsModified").AsBoolean().Nullable()
                .WithColumn("ModificationDate").AsDateTime().Nullable()
                .WithColumn("IsHidden").AsBoolean().NotNullable();
        }

        /// <summary>Downs this object.</summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Table(Globals.ResourceTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .Table($"{Globals.Schema}_{Globals.ResourceTable}");
        }
    }
}