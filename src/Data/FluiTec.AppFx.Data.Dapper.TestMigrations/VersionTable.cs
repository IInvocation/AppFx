﻿using FluentMigrator.VersionTableInfo;

namespace FluiTec.AppFx.Data.Dapper.TestMigrations
{
    /// <summary>	A version table. </summary>
    [VersionTableMetaData]
    public class VersionTable : IVersionTableMetaData
    {
        /// <summary>	Name of the column. </summary>
        public string ColumnName => "Version";

        /// <summary>	True to owns schema. </summary>
        public bool OwnsSchema => false;

        /// <summary>	Name of the schema. </summary>
        public string SchemaName => "";

        /// <summary>	Name of the table. </summary>
        public string TableName => "Dummy_Version";

        /// <summary>	Name of the unique index. </summary>
        public string UniqueIndexName => "UC_Version";

        /// <summary>	Name of the applied on column. </summary>
        public virtual string AppliedOnColumnName => "AppliedOn";

        /// <summary>	Name of the description column. </summary>
        public virtual string DescriptionColumnName => "Description";

        /// <summary>	Gets or sets a context for the application. </summary>
        /// <value>	The application context. </value>
        public object ApplicationContext { get; set; }
    }
}