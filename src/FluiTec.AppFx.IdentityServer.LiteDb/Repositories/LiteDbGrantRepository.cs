using System.Collections.Generic;
using System.Linq;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.IdentityServer.Entities;
using FluiTec.AppFx.IdentityServer.Repositories;

namespace FluiTec.AppFx.IdentityServer.LiteDb.Repositories
{
    /// <summary>	A lite database grant repository. </summary>
    public class LiteDbGrantRepository : LiteDbIntegerRepository<GrantEntity>, IGrantRepository
    {
        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        public LiteDbGrantRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>	Gets by grant key. </summary>
        /// <param name="grantKey">	The grant key. </param>
        /// <returns>	The by grant key. </returns>
        public GrantEntity GetByGrantKey(string grantKey)
        {
            return Collection.Find(e => e.GrantKey == grantKey).SingleOrDefault();
        }

        /// <summary>	Finds the subject identifiers in this collection. </summary>
        /// <param name="subjectId">	Identifier for the subject. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the subject identifiers in this
        ///     collection.
        /// </returns>
        public IEnumerable<GrantEntity> FindBySubjectId(string subjectId)
        {
            return Collection.Find(e => e.SubjectId == subjectId);
        }

        /// <summary>	Removes the by grant key described by grantKey. </summary>
        /// <param name="grantKey">	The grant key. </param>
        public void RemoveByGrantKey(string grantKey)
        {
            var entity = GetByGrantKey(grantKey);
            if (entity != null) Collection.Delete(entity.Id);
        }

        /// <summary>	Removes the by subject and client. </summary>
        /// <param name="subject">	The subject. </param>
        /// <param name="client"> 	The client. </param>
        public void RemoveBySubjectAndClient(string subject, string client)
        {
            var entities = Collection.Find(e => e.SubjectId == subject && e.ClientId == client);
            var grantEntities = entities as IList<GrantEntity> ?? entities.ToList();
            if (entities == null || !grantEntities.Any()) return;

            foreach (var entity in grantEntities)
                Collection.Delete(entity.Id);
        }

        /// <summary>	Removes the by subject client type. </summary>
        /// <param name="subject">	The subject. </param>
        /// <param name="client"> 	The client. </param>
        /// <param name="type">   	The type. </param>
        public void RemoveBySubjectClientType(string subject, string client, string type)
        {
            var entities = Collection.Find(e => e.SubjectId == subject && e.ClientId == client && e.Type == type);
            var grantEntities = entities as IList<GrantEntity> ?? entities.ToList();
            if (entities == null || !grantEntities.Any()) return;

            foreach (var entity in grantEntities)
                Collection.Delete(entity.Id);
        }
    }
}