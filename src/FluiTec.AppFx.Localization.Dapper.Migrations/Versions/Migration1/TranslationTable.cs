using FluentMigrator;

namespace FluiTec.AppFx.Localization.Dapper.Migrations.Versions.Migration1
{
    /// <summary>A translation table.</summary>
    [Migration(2)]
    public class TranslationTable : Migration
    {
        /// <summary>Ups this object.</summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .Table(Globals.TranslationTable)
                .InSchema(Globals.Schema)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ResourceId").AsInt32().NotNullable()
                .WithColumn("Value").AsString().Nullable()
                .WithColumn("Language").AsString().Nullable();
            IfDatabase("sqlserver", "postgres")
                .Create
                .ForeignKey()
                .FromTable(Globals.TranslationTable)
                .InSchema(Globals.Schema)
                .ForeignColumn("ResourceId")
                .ToTable(Globals.ResourceTable)
                .InSchema(Globals.Schema)
                .PrimaryColumn("Id");

            IfDatabase("mysql")
                .Create
                .Table($"{Globals.Schema}_{Globals.TranslationTable}")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ResourceId").AsInt32().NotNullable()
                .WithColumn("Value").AsString().Nullable()
                .WithColumn("Language").AsString().Nullable();
        }

        /// <summary>Downs this object.</summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Table(Globals.TranslationTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .Table($"{Globals.Schema}_{Globals.TranslationTable}");
        }
    }
}