﻿using FluentMigrator;

namespace FluiTec.AppFx.Identity.Dapper.Migration.Versions.Migration4
{
    /// <summary>   A data migration key table. </summary>
    [Migration(9)]
    public class DataMigrationKeyTable : FluentMigrator.Migration
    {
        /// <summary>   Name of the unique name index. </summary>
        private const string UniqueNameIndexName = "UX_UniqueFriendlyName";

        /// <summary>   Downs this object. </summary>
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Create
                .Table(Globals.DataProtectionKeyTable)
                .InSchema(Globals.Schema)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("FriendlyName").AsString(int.MaxValue).NotNullable()
                .WithColumn("XmlData").AsString(int.MaxValue).Nullable();

            IfDatabase("mysql")
                .Create
                .Table($"{Globals.Schema}_{Globals.DataProtectionKeyTable}")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("FriendlyName").AsString(int.MaxValue).NotNullable()
                .WithColumn("XmlData").AsString(int.MaxValue).Nullable();
        }

        /// <summary>   Ups this object. </summary>
        public override void Down()
        {
            IfDatabase("sqlserver", "postgres")
                .Delete
                .Table(Globals.DataProtectionKeyTable)
                .InSchema(Globals.Schema);

            IfDatabase("mysql")
                .Delete
                .Table($"{Globals.Schema}_{Globals.DataProtectionKeyTable}");
        }
    }
}
