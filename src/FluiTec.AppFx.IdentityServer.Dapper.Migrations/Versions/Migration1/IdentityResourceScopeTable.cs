﻿using FluentMigrator;

namespace FluiTec.AppFx.IdentityServer.Dapper.Migrations.Versions.Migration1
{
	/// <summary>	A migration for the identityresourcescope-table. </summary>
	[Migration(version: 11)]
	public class IdentityResourceScopeTable : Migration
	{
		/// <summary>	Updates the database up to this migration. </summary>
		public override void Up()
		{
			IfDatabase("sqlserver", "postgres")
				.Create
				.Table(Globals.IDENTITYRESOURCESCOPE_TABLE)
				.InSchema(Globals.SCHEMA)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("IdentityResourceId").AsInt32().NotNullable()
				.WithColumn("ScopeId").AsInt32().NotNullable();
			IfDatabase("sqlserver", "postgres")
				.Create
				.ForeignKey()
				.FromTable(Globals.IDENTITYRESOURCESCOPE_TABLE)
				.InSchema(Globals.SCHEMA)
				.ForeignColumn("IdentityResourceId")
				.ToTable(Globals.IDENTITYRESOURCE_TABLE)
				.InSchema(Globals.SCHEMA)
				.PrimaryColumn("Id");
			IfDatabase("sqlserver", "postgres")
				.Create
				.ForeignKey()
				.FromTable(Globals.IDENTITYRESOURCESCOPE_TABLE)
				.InSchema(Globals.SCHEMA)
				.ForeignColumn("ScopeId")
				.ToTable(Globals.SCOPE_TABLE)
				.InSchema(Globals.SCHEMA)
				.PrimaryColumn("Id");

			IfDatabase("mysql")
				.Create
				.Table($"{Globals.SCHEMA}_{Globals.IDENTITYRESOURCESCOPE_TABLE}")
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("IdentityResourceId").AsInt32().NotNullable()
				.WithColumn("ScopeId").AsInt32().NotNullable();
		}

		/// <summary>	Updates the database down to this migration. </summary>
		public override void Down()
		{
			IfDatabase("sqlserver", "postgres")
				.Delete
				.Table(Globals.IDENTITYRESOURCESCOPE_TABLE)
				.InSchema(Globals.SCHEMA);

			IfDatabase("mysql")
				.Delete
				.Table($"{Globals.SCHEMA}_{Globals.IDENTITYRESOURCESCOPE_TABLE}");
		}
	}
}