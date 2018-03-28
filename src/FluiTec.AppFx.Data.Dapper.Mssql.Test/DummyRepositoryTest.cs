using System;
using System.Linq;
using FluiTec.AppFx.Data.Dapper.Mssql.Test.Fixtures;
using FluiTec.AppFx.Data.Sql;
using FluiTec.AppFx.Data.Sql.Adapters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Data.Dapper.Mssql.Test
{
    [TestClass]
    public class DummyRepositoryTest
    {
        public DummyRepositoryTest()
        {
            var builder = new SqlBuilder(new MicrosoftSqlAdapter());
            DefaultSqlBuilder.GetSqlBuilder = connection => builder;
        }

        protected IDataService DataService { get; set; }
        protected IUnitOfWork UnitOfWork { get; set; }
        protected IDummyRepository Repository { get; set; }

        public virtual void Initialize()
        {
            DataService = new DummyMssqlDataService();
            DataService.RegisterRepositoryProvider(
                new Func<IUnitOfWork, IDummyRepository>(work => new DummyRepository(work)));
            UnitOfWork = DataService.BeginUnitOfWork();
            Repository = UnitOfWork.GetRepository<IDummyRepository>();
        }

        public virtual void Cleanup()
        {
            Repository = null;
            UnitOfWork.Dispose();
            DataService.Dispose();
        }

        [TestMethod]
        public void CanAddEntity()
        {
            Initialize();
            try
            {
                const string name = "My TestName";
                var entity = new DummyEntity {Name = name};

                entity = Repository.Add(entity);
                entity = Repository.Get(entity.Id);

                Assert.AreEqual(entity.Name, name);
            }
            finally
            {
                Cleanup();
            }
        }

        [TestMethod]
        public void CanAddEntityRange()
        {
            Initialize();
            try
            {
                var entities = new[] {new DummyEntity(), new DummyEntity()};
                Repository.AddRange(entities);
                var repoCount = Repository.GetAll().Count();

                Assert.AreEqual(entities.Length, repoCount);
            }
            finally
            {
                Cleanup();
            }
        }

        [TestMethod]
        public void CanUpdateEntity()
        {
            Initialize();
            try
            {
                const string updateName = "updated name";

                var entity = new DummyEntity();
                entity = Repository.Add(entity);

                entity.Name = updateName;
                entity = Repository.Update(entity);

                Assert.AreEqual(updateName, entity.Name);
            }
            finally
            {
                Cleanup();
            }
        }

        [TestMethod]
        public void CanDeleteByInstance()
        {
            Initialize();
            try
            {
                var entity = new DummyEntity();
                entity = Repository.Add(entity);

                Repository.Delete(entity);

                Assert.IsNull(Repository.Get(entity.Id));
            }
            finally
            {
                Cleanup();
            }
        }

        [TestMethod]
        public void CanDeleteById()
        {
            Initialize();
            try
            {
                var entity = new DummyEntity();
                entity = Repository.Add(entity);

                Repository.Delete(entity.Id);

                Assert.IsNull(Repository.Get(entity.Id));
            }
            finally
            {
                Cleanup();
            }
        }

        [TestMethod]
        public void TestCommit()
        {
            Initialize();
            try
            {
                Repository.Add(new DummyEntity());
                UnitOfWork.Commit();
            }
            finally
            {
                Cleanup();
            }

            Initialize();
            try
            {
                Assert.AreEqual(Repository.GetAll().Count(), 1);
                Repository.Delete(Repository.GetAll().First());
                UnitOfWork.Commit();
            }
            finally
            {
                Cleanup();
            }
        }
    }
}