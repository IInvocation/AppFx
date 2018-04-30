using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Sql;
using FluiTec.AppFx.IdentityServer.Dapper.Repositories;
using FluiTec.AppFx.IdentityServer.Entities;

namespace FluiTec.AppFx.IdentityServer.Dapper.Mysql.Repositories
{
    /// <summary>	A Mysql signing credential repository. </summary>
    public class MysqlSigningCredentialRepository : SigningCredentialRepository
    {
        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        public MysqlSigningCredentialRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>	Gets the latest. </summary>
        /// <returns>	The latest. </returns>
        public override SigningCredentialEntity GetLatest()
        {
            var command =
                $"SELECT {SqlBuilder.Adapter.RenderPropertyList(SqlCache.TypePropertiesChache(typeof(SigningCredentialEntity)).ToArray())} FROM {TableName} ORDER BY {nameof(SigningCredentialEntity.Issued)} DESC LIMIT 1";
            return UnitOfWork.Connection.QuerySingleOrDefault<SigningCredentialEntity>(command, null,
                UnitOfWork.Transaction);
        }

        /// <summary>	Gets validation valid. </summary>
        /// <param name="validSince">	The valid since Date/Time. </param>
        /// <returns>	The validation valid. </returns>
        public override IList<SigningCredentialEntity> GetValidationValid(DateTime validSince)
        {
            var command =
                $"SELECT {SqlBuilder.Adapter.RenderPropertyList(SqlCache.TypePropertiesChache(typeof(SigningCredentialEntity)).ToArray())} FROM {TableName} WHERE {nameof(SigningCredentialEntity.Issued)} > @validSince";
            return UnitOfWork.Connection.Query<SigningCredentialEntity>(command, new {ValidSince = validSince},
                UnitOfWork.Transaction).ToList();
        }
    }
}