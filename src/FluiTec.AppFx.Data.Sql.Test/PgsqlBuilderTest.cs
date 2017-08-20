using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;

namespace FluiTec.AppFx.Data.Sql.Test
{
	[TestClass]
	public class PgsqlBuilderTest
	{
		/// <summary>	The connection. </summary>
		private readonly IDbConnection _connection;

		/// <summary>	Default constructor. </summary>
		public PgsqlBuilderTest()
		{
			_connection = new NpgsqlConnection();
		}

		[TestMethod]
		public void TestGetBuilder()
		{
			// just test this doesnt throw
			DefaultSqlBuilder.GetBuilder(_connection);
		}

		[TestMethod]
		public void TestSelectAll()
		{
			var sql = DefaultSqlBuilder.GetBuilder(_connection).SelectAll(typeof(Dummy));
			Assert.AreEqual($"SELECT * FROM \"{nameof(Dummy)}\"", sql);
		}

		[TestMethod]
		public void TestSelectByKey()
		{
			var sql = DefaultSqlBuilder.GetBuilder(_connection).SelectByKey(typeof(Dummy));
			Assert.AreEqual($"SELECT * FROM \"{nameof(Dummy)}\" WHERE \"Id\" = @Id", sql);
		}

		[TestMethod]
		public void TestInsertAutoKey()
		{
			var sql = DefaultSqlBuilder.GetBuilder(_connection).InsertAutoKey(typeof(Dummy));
			Assert.AreEqual($"INSERT INTO \"{nameof(Dummy)}\" (\"Name\") VALUES (@Name) RETURNING \"{nameof(Dummy.Id)}\"", sql);
		}

		[TestMethod]
		public void TestInsertMultiple()
		{
			var sql = DefaultSqlBuilder.GetBuilder(_connection).InsertAutoMultiple(typeof(Dummy));
			Assert.AreEqual($"INSERT INTO \"{nameof(Dummy)}\" (\"Name\") VALUES (@Name)", sql);
		}

		[TestMethod]
		public void TestUpdate()
		{
			var sql = DefaultSqlBuilder.GetBuilder(_connection).Update(typeof(Dummy));
			Assert.AreEqual($"UPDATE \"{nameof(Dummy)}\" SET \"Name\" = @Name WHERE \"Id\" = @Id", sql);
		}

		[TestMethod]
		public void TestDelete()
		{
			var sql = DefaultSqlBuilder.GetBuilder(_connection).Delete(typeof(Dummy));
			Assert.AreEqual($"DELETE FROM \"{nameof(Dummy)}\" WHERE \"Id\" = @Id", sql);
		}
	}
}