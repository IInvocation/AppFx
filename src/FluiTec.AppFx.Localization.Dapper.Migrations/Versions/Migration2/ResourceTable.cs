using FluentMigrator;

namespace FluiTec.AppFx.Localization.Dapper.Migrations.Versions.Migration2
{
    /// <summary>A resource table.</summary>
    [Migration(3)]
    public class ResourceTable : Migration
    {
        /// <summary>Ups this object.</summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Alter
                .Table(Globals.ResourceTable)
                .InSchema(Globals.Schema)
                .AlterColumn("ModificationDate")
                .AsDateTime()
                .NotNullable();

            IfDatabase("mysql")
                .Alter
                .Table($"{Globals.Schema}_{Globals.ResourceTable}")
                .AlterColumn("ModificationDate")
                .AsDateTime()
                .NotNullable();
        }

        /// <summary>Downs this object.</summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Alter
                .Table(Globals.ResourceTable)
                .InSchema(Globals.Schema)
                .AlterColumn("ModificationDate")
                .AsDateTime()
                .Nullable();

            IfDatabase("mysql")
                .Alter
                .Table($"{Globals.Schema}_{Globals.ResourceTable}")
                .AlterColumn("ModificationDate")
                .AsDateTime()
                .Nullable();
        }
    }
}
