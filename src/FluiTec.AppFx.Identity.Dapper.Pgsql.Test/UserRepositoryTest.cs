using System;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Pgsql;
using FluiTec.AppFx.Identity.Dapper.Pgsql;
using FluiTec.AppFx.Identity.Entities;
using FluiTec.AppFx.Identity.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Identity.Dapper.Mssql.Test
{
	[TestClass]
	public class UserRepositoryTest
	{
		protected IIdentityDataService DataService { get; set; }
		protected  IIdentityUnitOfWork UnitOfWork { get; set; }
		protected IUserRepository Repository { get; set; }

		public virtual void Initialize()
		{
			var options = new DapperServiceOptions
			{
				ConnectionFactory = new PgsqlConnectionFactory(),
				ConnectionString =
					"User ID=srv-callrouting;Password=test123;Host=localhost;Port=5432;Database=callrouting;Pooling=true;"
			};
			DataService = new PgsqlDapperIdentityDataService(options);
			UnitOfWork = DataService.StartUnitOfWork();
			Repository = UnitOfWork.UserRepository;
		}

		public virtual void Cleanup()
		{
			UnitOfWork.Dispose();
			DataService.Dispose();
		}

		[TestMethod]
		public void CanAddUser()
		{
			Initialize();
			try
			{
				var user = new IdentityUserEntity
				{
					ApplicationId = 0,
					IsAnonymous = false,
					LastActivityDate = DateTime.Now,
					LoweredUserName = "a.schnell@wtschnell.de",
					Name = "a.schnell@wtschnell.de"
				};
				user = Repository.Add(user);
				Assert.AreNotEqual(0, user.Id);
			}
			catch (Exception)
			{
				Cleanup();
				throw;
			}	
		}
	}
}