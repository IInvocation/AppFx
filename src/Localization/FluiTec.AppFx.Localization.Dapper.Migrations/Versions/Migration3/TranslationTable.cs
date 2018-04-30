using FluentMigrator;

namespace FluiTec.AppFx.Localization.Dapper.Migrations.Versions.Migration3
{
    /// <summary>A translation table.</summary>
    [Migration(4)]
    public class TranslationTable : Migration
    {
        /// <summary>Name of the contraint.</summary>
        private const string ContraintName = "UX_Language_Resource";

        /// <summary>Ups this object.</summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .UniqueConstraint(ContraintName)
                .OnTable(Globals.TranslationTable)
                .WithSchema(Globals.Schema)
                .Columns("ResourceId", "Language");

            IfDatabase("mysql")
                .Create
                .UniqueConstraint(ContraintName)
                .OnTable($"{Globals.Schema}_{Globals.TranslationTable}")
                .Columns("ResourceId", "Language");
        }

        /// <summary>Downs this object.</summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .UniqueConstraint(ContraintName)
                .FromTable($"{Globals.Schema}_{Globals.TranslationTable}");
        }
    }
}