# README #

## AppFx ##

### What is this repository for? ###

* This repository contains many useful libraries encapsulating common needs for an application

### Common libraries ###

* FluiTec.Data - interfaces and base-classes defining a DataAccessLayer immplementing the RepositoryPattern combined with the UnitOfWork-Pattern
* FluiTec.AppFx.Data.Dapper - implementation using dapper
* FluiTec.AppFx.Data.Dapper.Mssql - implemention using dapper for Mssql
* FluiTec.AppFx.Data.LiteDb - implementation for LiteDb
* FluiTec.AppFx.Identity. - implementation for AspNetCoreIdentity using FluiTec.Data
* FluiTec.AppFx.IdentityServer. - implementation for IdentityServer using FluiTec.Data
* FluiTec.AppFx.InversionOfControl - ServiceLocatorWrapper for NetCore and .NET
* Fluitec.AppFx.InversionOfControl.SimpleIoC - ServiceLocatorWrapper using SimpleIoC
* FluiTec.AppFx.Mail - MailService using RazorLight
* FluiTec.AppFx.Upnp - Upnp-Helpers using Open.NAT
* FluiTec.AppFx.Authentication.Amazon - OpenId-Implementation for Amazon

### How do I get set up? ###

* First - install the Nuget-CLI if you don't have it already (see https://docs.microsoft.com/en-us/nuget/guides/install-nuget)
* Add a share called "nuget" that is accessible by "\\localhost\nuget\" (this is necessary, since this project is configured to automatically create nuget-packages)
