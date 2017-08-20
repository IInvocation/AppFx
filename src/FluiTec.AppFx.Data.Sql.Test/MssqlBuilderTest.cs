using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Data.Sql.Test
{
	[TestClass]
	public class MssqlBuilderTest
	{
		/// <summary>	The connection. </summary>
		private readonly IDbConnection _connection;

		/// <summary>	Default constructor. </summary>
		public MssqlBuilderTest()
		{
			_connection = new SqlConnection();
		}

		[TestMethod]
		public void TestGetBuilder()
		{
			// just test this doesnt throw
			_connection.GetBuilder();
		}

		[TestMethod]
		public void TestSelectAll()
		{
			var sql = _connection.GetBuilder().SelectAll(typeof(Dummy));
			Assert.AreEqual($"SELECT * FROM {nameof(Dummy)}", sql);
		}

		[TestMethod]
		public void TestSelectByKey()
		{
			var sql = _connection.GetBuilder().SelectByKey(typeof(Dummy));
			Assert.AreEqual($"SELECT * FROM {nameof(Dummy)} WHERE Id = @Id", sql);
		}

		[TestMethod]
		public void TestInsertAutoKey()
		{
			var sql = _connection.GetBuilder().InsertAutoKey(typeof(Dummy));
			Assert.AreEqual($"INSERT INTO {nameof(Dummy)} (Name) VALUES (@Name);SELECT SCOPE_IDENTITY() {nameof(Dummy.Id)}", sql);	
		}

		[TestMethod]
		public void TestInsertMultiple()
		{
			var sql = _connection.GetBuilder().InsertAutoMultiple(typeof(Dummy));
			Assert.AreEqual($"INSERT INTO {nameof(Dummy)} (Name) VALUES (@Name)", sql);
		}

		[TestMethod]
		public void TestUpdate()
		{
			var sql = _connection.GetBuilder().Update(typeof(Dummy));
			Assert.AreEqual($"UPDATE {nameof(Dummy)} SET Name = @Name WHERE Id = @Id", sql);
		}

		[TestMethod]
		public void TestDelete()
		{
			var sql = _connection.GetBuilder().Delete(typeof(Dummy));
			Assert.AreEqual($"DELETE FROM {nameof(Dummy)} WHERE Id = @Id", sql);
		}
	}
}