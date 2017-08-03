using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using Dapper;
using Dapper.Contrib.Extensions;

namespace FluiTec.AppFx.Data.Dapper
{
	public static class SqlMapperExtensionsOwn
	{
		/// <summary>	Gets database type delegate. </summary>
		/// <param name="connection">	The connection. </param>
		/// <returns>	A string. </returns>
		public delegate string GetDatabaseTypeDelegate(IDbConnection connection);

		/// <summary>	Dictionary of adapters. </summary>
		private static readonly Dictionary<string, ISqlAdapter> AdapterDictionary
			= new Dictionary<string, ISqlAdapter>
			{
				[key: "sqlconnection"] = new SqlServerAdapter(),
				[key: "sqlceconnection"] = new SqlCeServerAdapter(),
				[key: "npgsqlconnection"] = new PostgresAdapter(),
				[key: "sqliteconnection"] = new SQLiteAdapter(),
				[key: "mysqlconnection"] = new MySqlAdapter()
			};

		/// <summary>	The default adapter. </summary>
		private static readonly ISqlAdapter DefaultAdapter = new SqlServerAdapter();

		/// <summary>
		///     Specifies a custom callback that detects the database type instead of relying on the default strategy (the name of
		///     the connection type object).
		///     Please note that this callback is global and will be used by all the calls that require a database specific
		///     adapter.
		/// </summary>
		public static GetDatabaseTypeDelegate GetDatabaseType;

		/// <summary>	Gets a formatter. </summary>
		/// <param name="connection">	The connection. </param>
		/// <returns>	The formatter. </returns>
		public static ISqlAdapter GetFormatter(IDbConnection connection)
		{
			var name = GetDatabaseType?.Invoke(connection).ToLower()
			           ?? connection.GetType().Name.ToLower();

			return !AdapterDictionary.ContainsKey(name)
				? DefaultAdapter
				: AdapterDictionary[name];
		}

		private static readonly ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>> TypeProperties = new ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>>();

		/// <summary>	Type properties cache. </summary>
		/// <param name="type">	The type. </param>
		/// <returns>	A List&lt;PropertyInfo&gt; </returns>
		public static List<PropertyInfo> TypePropertiesCache(Type type)
		{
			if (TypeProperties.TryGetValue(type.TypeHandle, out IEnumerable<PropertyInfo> pis))
			{
				return pis.ToList();
			}

			var properties = type.GetProperties().Where(IsWriteable).ToArray();
			TypeProperties[type.TypeHandle] = properties;
			return properties.ToList();
		}

		/// <summary>	Query if 'pi' is writeable. </summary>
		/// <param name="pi">	The pi. </param>
		/// <returns>	True if writeable, false if not. </returns>
		private static bool IsWriteable(PropertyInfo pi)
		{
			var attributes = pi.GetCustomAttributes(typeof(WriteAttribute), inherit: false).AsList();
			if (attributes.Count != 1) return true;

			var writeAttribute = (WriteAttribute)attributes[0];
			return writeAttribute.Write;
		}

		private static readonly ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>> KeyProperties = new ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>>();

		/// <summary>	Key properties cache. </summary>
		/// <param name="type">	The type. </param>
		/// <returns>	A List&lt;PropertyInfo&gt; </returns>
		public static List<PropertyInfo> KeyPropertiesCache(Type type)
		{
			if (KeyProperties.TryGetValue(type.TypeHandle, out IEnumerable<PropertyInfo> pi))
			{
				return pi.ToList();
			}

			var allProperties = TypePropertiesCache(type);
			var keyProperties = allProperties.Where(p => p.GetCustomAttributes(inherit: true).Any(a => a is KeyAttribute)).ToList();

			if (keyProperties.Count == 0)
			{
				var idProp = allProperties.FirstOrDefault(p => p.Name.ToLower() == "id");
				if (idProp != null && !idProp.GetCustomAttributes(inherit: true).Any(a => a is ExplicitKeyAttribute))
				{
					keyProperties.Add(idProp);
				}
			}

			KeyProperties[type.TypeHandle] = keyProperties;
			return keyProperties;
		}

		private static readonly ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>> ComputedProperties = new ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>>();

		/// <summary>	Computed properties cache. </summary>
		/// <param name="type">	The type. </param>
		/// <returns>	A List&lt;PropertyInfo&gt; </returns>
		public static List<PropertyInfo> ComputedPropertiesCache(Type type)
		{
			if (ComputedProperties.TryGetValue(type.TypeHandle, out IEnumerable<PropertyInfo> pi))
			{
				return pi.ToList();
			}

			var computedProperties = TypePropertiesCache(type).Where(p => p.GetCustomAttributes(true).Any(a => a is ComputedAttribute)).ToList();

			ComputedProperties[type.TypeHandle] = computedProperties;
			return computedProperties;
		}
	}
}