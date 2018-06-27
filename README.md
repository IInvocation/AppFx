# README #

## AppFx ##

### What is this repository for? ###
This repository contains libraries for frequently necessary application functionality

### Common libraries ###

#### Options ####
* FluiTec.AppFx.Options : simplify the handling of json-configuration-files

#### Reflection ####
* FluiTec.AppFx.Reflection : simplify common reflection-tasks

#### Tooling ####
* FluiTec.AppFx.InversionOfControl: simplify common IoC-tasks

#### Cryptography ####
* FluiTec.AppFx.Cryptography : Password-hashing, Id-Generation

#### Networking ####
* FluiTec.AppFx.Upnp : Automatic Upnp-Setup using Open.NAT
* FluiTec.AppFx.Ssl : Simple helper to create ssl-compatible certificates
* FluiTec.AppFx.Rest : Library that simplifies the creation of rest-based, bearer-secured API-Clients
* FluiTec.AppFx.Mail : Library that simplifies mails using cshtml-templates based on RazorLight

#### Data ####
This namespace contains an sql-generating database-framework providing a consistent api using
Repository-Pattern and UnitOfWork-Pattern.
* FluiTec.AppFx.Data : Defines common interfaces for DataServices, Repositories and UnitsOfWork
* FluiTec.AppFx.Data.Sql : Library that can build and cache sql-commands for Mssql, Mysql, Pgsql and Sqlite
* FluiTec.AppFx.Data.Dapper : Base implementation for sql-based databases using Dapper
* FluiTec.AppFx.Data.Dapper.Mssql : Mssql-Implementation using FluiTec.AppFx.Data.Dapper
* FluiTec.AppFx.Data.Dapper.Mysql : Mysql-Implementation using FluiTec.AppFx.Data.Dapper
* FluiTec.AppFx.Data.Dapper.Pgsql : Pgsql-Implementation using FluiTec.AppFx.Data.Dapper
* FluiTec.AppFx.Data.Dapper.Sqlite : Sqlite-Implementation using FluiTec.AppFx.Data.Dapper
* FluiTec.AppFx.Data.LibteDb : LiteDb-Implementation
* FluiTec.AppFx.Data.LiteDb.Editor : simple, unfinished editor for litedb-database-files
* FluiTec.AppFx.Data.Dynamic : Library that simplifies the process of creating a dynamic data-provider

#### Authentication ####
* FluiTec.AppFx.OpenId : Library that allows a AspNetCore-Client-Application to easily use OpenId-Connect
* FluiTec.AppFx.Authentication.Amazon : Implementation of the Amazon-OpenId-Provider

#### DataProtection ####
* FluiTec.AppFx.DataProtection: Library with implementation of IXmlRepository (used by AspNetCore to secure sessions and keys)
                                using FluiTec.AppFx.Data
** Implementations for Mssql, Mysql, Pgsql and LiteDb

#### Localization ####
* FluiTec.AppFx.Localization : Library that can help localize an AspNetCore-Application using a DataBase instead of resources
                               (uses DbLocalizationProvider)
** Implementations for Mssql, Mysql, Pgsql and LiteDb

#### Identity ####
* FluiTec.AppFx.Identity : Implementation of Microsoft's Identity-API using api of FluiTec.AppFx.Data
** Implementations for Mssql, Mysql, Pgsql and LiteDb

#### IdentityServer ####
* FluiTec.AppFx.IdentityServer : Implementation of IdentityServer4 using api of FluiTec.AppFx.Data
** Implementations for Mssql, Mysql, Pgsql and LiteDb

#### Authorization.Activity ####
* FluiTec.AppFx.Authorization.Activity : Authorization-implementation for AspNetCore based on Activities and roles
** Implementations for Mssql, Mysql, Pgsql and LiteDb

#### AspNetCore ####
* FluiTec.AppFx.AspNetCore : Library that combines helper methods frequently used in AspNetCore using the libraries mentioned before

### Current State ###
This project is currently in development - so it's packages are not published to NuGet
(I don't know if they'll ever be, since this project is like just me personal repository that nobody knows)

Most of it's content is based on the idea, that i want to use my own database-logic, that i don't want to copy anywhere,
as well as the wish to not mix different api's for different application-parts. (i.E: using EntityFramework for Users, but still using
custom database-logic for custom data). Although i like the automatic generation of SqlStatements or automatic object-mapping,
EntityFramework(Core) doesnt really meet my wishes. (Including default Repository and UnitOfWork-Pattern) which made me implement these
libraries.