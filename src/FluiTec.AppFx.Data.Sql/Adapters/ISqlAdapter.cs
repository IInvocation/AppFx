using System;

namespace FluiTec.AppFx.Data.Sql.Adapters
{
	/// <summary>	Interface for SQL adapter. </summary>
	public interface ISqlAdapter
	{
		/// <summary>	Select all statement. </summary>
		/// <param name="type">	The type. </param>
		/// <returns>	A string. </returns>
		string SelectAllStatement(Type type);
	}
}