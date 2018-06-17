using FluentMigrator;

namespace FluiTec.AppFx.Localization.Dapper.Migration.Versions.Migration4
{
    /// <summary>A translation table.</summary>
    [Migration(5)]
    public class TranslationTable : FluentMigrator.Migration
    {
        /// <summary>Ups this object.</summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Alter
                .Column("Value")
                .OnTable(Globals.TranslationTable)
                .InSchema(Globals.Schema)
                .AsString(int.MaxValue);

            IfDatabase("mysql")
                .Alter
                .Column("Value")
                .OnTable($"{Globals.Schema}_{Globals.TranslationTable}")
                .AsString(int.MaxValue);
        }

        /// <summary>Downs this object.</summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Alter
                .Column("Value")
                .OnTable(Globals.TranslationTable)
                .InSchema(Globals.Schema)
                .AsString();

            IfDatabase("mysql")
                .Alter
                .Column("Value")
                .OnTable($"{Globals.Schema}_{Globals.TranslationTable}")
                .AsString();
        }
    }
}