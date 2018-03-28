using Dapper;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.IdentityServer.Dapper.Repositories;
using FluiTec.AppFx.IdentityServer.Entities;

namespace FluiTec.AppFx.IdentityServer.Dapper.Pgsql.Repositories
{
    /// <summary>	A mssql grant repository. </summary>
    public class PgsqlGrantRepository : GrantRepository
    {
        #region Constructors

        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        public PgsqlGrantRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region GrantRepository

        /// <summary>	Removes the by grant key described by grantKey. </summary>
        /// <param name="grantKey">	The grant key. </param>
        public override void RemoveByGrantKey(string grantKey)
        {
            UnitOfWork.Connection.Execute(
                $"DELETE FROM {TableName} WHERE \"{nameof(GrantEntity.GrantKey)}\" = @GrantKey",
                new {GrantKey = grantKey}, UnitOfWork.Transaction);
        }

        /// <summary>	Removes the by subject and client. </summary>
        /// <param name="subject">	The subject. </param>
        /// <param name="client"> 	The client. </param>
        public override void RemoveBySubjectAndClient(string subject, string client)
        {
            UnitOfWork.Connection.Execute($"DELETE FROM {TableName} WHERE " +
                                          $"\"{nameof(GrantEntity.SubjectId)}\" = @SubjectId AND " +
                                          $"\"{nameof(GrantEntity.ClientId)}\" = @ClientId",
                new {SubjectId = subject, ClientId = client}, UnitOfWork.Transaction);
        }

        /// <summary>	Removes the by subject client type. </summary>
        /// <param name="subject">	The subject. </param>
        /// <param name="client"> 	The client. </param>
        /// <param name="type">   	The type. </param>
        public override void RemoveBySubjectClientType(string subject, string client, string type)
        {
            UnitOfWork.Connection.Execute($"DELETE FROM {TableName} WHERE " +
                                          $"\"{nameof(GrantEntity.SubjectId)}\" = @SubjectId AND " +
                                          $"\"{nameof(GrantEntity.ClientId)}\" = @ClientId AND " +
                                          $"\"{nameof(GrantEntity.Type)}\" = @Type",
                new {SubjectId = subject, ClientId = client, Type = type}, UnitOfWork.Transaction);
        }

        #endregion
    }
}