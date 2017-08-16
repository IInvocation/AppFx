using System;

namespace FluiTec.AppFx.Data.Dapper.Pgsql
{
    public class QuotedEntityNameAttributeNameService : EntityNameAttributeNameService
	{
		public override string NameByType(Type entityType)
		{
			return $"\"{base.NameByType(entityType)}\"";
		}
	}
}
