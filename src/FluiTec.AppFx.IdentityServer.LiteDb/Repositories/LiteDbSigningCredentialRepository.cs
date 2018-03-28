using System;
using System.Collections.Generic;
using System.Linq;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.IdentityServer.Entities;
using FluiTec.AppFx.IdentityServer.Repositories;

namespace FluiTec.AppFx.IdentityServer.LiteDb.Repositories
{
    /// <summary>	A lite database signing credential repository. </summary>
    public class LiteDbSigningCredentialRepository : LiteDbIntegerRepository<SigningCredentialEntity>,
        ISigningCredentialRepository
    {
        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        public LiteDbSigningCredentialRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>	Gets the latest. </summary>
        /// <returns>	The latest. </returns>
        public SigningCredentialEntity GetLatest()
        {
            var all = GetAll();
            var signingCredentialEntities = all as IList<SigningCredentialEntity> ?? all.ToList();
            var max = signingCredentialEntities.Max(e => e.Issued);
            return signingCredentialEntities.Single(e => e.Issued == max);
        }

        /// <summary>	Gets validation valid. </summary>
        /// <param name="validSince">	The valid since Date/Time. </param>
        /// <returns>	The validation valid. </returns>
        public IList<SigningCredentialEntity> GetValidationValid(DateTime validSince)
        {
            return Collection.Find(e => e.Issued > validSince).ToList();
        }
    }
}