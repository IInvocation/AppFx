﻿using FluentMigrator;

namespace FluiTec.AppFx.Identity.Dapper.Migrations.Migration1
{
	/// <summary>	A migration for the user-table. </summary>
	[Migration(version: 1)]
	public class UserTable : Migration
	{
		/// <summary>	Updates the database up to this migration. </summary>
		public override void Up()
		{
			IfDatabase("sqlserver", "postgres")
				.Create
				.Table(Globals.USER_TABLE)
				.InSchema(Globals.SCHEMA)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("ApplicationId").AsInt32().NotNullable()
				.WithColumn("Identifier").AsGuid().NotNullable().Unique()
				.WithColumn("Name").AsString(256).NotNullable()
				.WithColumn("LoweredUserName").AsString(256).NotNullable().Indexed()
				.WithColumn("MobileAlias").AsString(16).Nullable()
				.WithColumn("IsAnonymous").AsBoolean().NotNullable()
				.WithColumn("LastActivityDate").AsDateTime().NotNullable()
				.WithColumn("PasswordHash").AsString(256).Nullable()
				.WithColumn("SecurityStamp").AsString(256).Nullable()
				.WithColumn("Email").AsString(256).NotNullable()
				.WithColumn("NormalizedEmail").AsString(256).Nullable()
				.WithColumn("EmailConfirmed").AsBoolean().NotNullable()
				.WithColumn("Phone").AsString(256).Nullable()
				.WithColumn("PhoneConfirmed").AsBoolean().NotNullable()
				.WithColumn("TwoFactorEnabled").AsBoolean().NotNullable()
				.WithColumn("LockoutEnabled").AsBoolean().NotNullable()
				.WithColumn("AccessFailedCount").AsInt32().NotNullable()
				.WithColumn("LockedOutTill").AsDateTimeOffset().Nullable();

			IfDatabase("mysql")
				.Create
				.Table($"{Globals.SCHEMA}_{Globals.USER_TABLE}")
				.InSchema(Globals.SCHEMA)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("ApplicationId").AsInt32().NotNullable()
				.WithColumn("Identifier").AsGuid().NotNullable().Unique()
				.WithColumn("Name").AsString(256).NotNullable()
				.WithColumn("LoweredUserName").AsString(256).NotNullable().Indexed()
				.WithColumn("MobileAlias").AsString(16).Nullable()
				.WithColumn("IsAnonymous").AsBoolean().NotNullable()
				.WithColumn("LastActivityDate").AsDateTime().NotNullable()
				.WithColumn("PasswordHash").AsString(256).Nullable()
				.WithColumn("SecurityStamp").AsString(256).Nullable()
				.WithColumn("Email").AsString(256).NotNullable()
				.WithColumn("NormalizedEmail").AsString(256).Nullable()
				.WithColumn("EmailConfirmed").AsBoolean().NotNullable()
				.WithColumn("Phone").AsString(256).Nullable()
				.WithColumn("PhoneConfirmed").AsBoolean().NotNullable()
				.WithColumn("TwoFactorEnabled").AsBoolean().NotNullable()
				.WithColumn("LockoutEnabled").AsBoolean().NotNullable()
				.WithColumn("AccessFailedCount").AsInt32().NotNullable()
				.WithColumn("LockedOutTill").AsDateTime().Nullable();
		}

		/// <summary>	Updates the database down to this migration. </summary>
		public override void Down()
		{
			IfDatabase("sqlserver", "postgres")
				.Delete
				.Table(Globals.USER_TABLE)
				.InSchema(Globals.SCHEMA);

			IfDatabase("mysql")
				.Delete
				.Table($"{Globals.SCHEMA}_{Globals.USER_TABLE}");
		}
	}
}
