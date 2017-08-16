using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluiTec.AppFx.Data.Sql
{
    /// <summary>	A SQL entity cache. </summary>
    public static class SqlCache
    {
		/// <summary>	The type properties. </summary>
		private static readonly ConcurrentDictionary<RuntimeTypeHandle, IList<PropertyInfo>> TypeProperties = new ConcurrentDictionary<RuntimeTypeHandle, IList<PropertyInfo>>();

	    /// <summary>	Type properties chache. </summary>
	    /// <param name="type">	The type. </param>
	    /// <returns>	A list of. </returns>
	    public static IList<PropertyInfo> TypePropertiesChache(Type type)
	    {
		    if (TypeProperties.TryGetValue(type.TypeHandle, out IList<PropertyInfo> propertyInfos))
				return propertyInfos;

		    var properties = type.GetProperties();
		    TypeProperties[type.TypeHandle] = properties.ToList();
		    return properties;
	    }

		/// <summary>	The entity name cache. </summary>
		public static ConcurrentDictionary<RuntimeTypeHandle, string> EntityNameCache = new ConcurrentDictionary<RuntimeTypeHandle, string>();
	}
}
