﻿using System.Linq;
using FluiTec.AppFx.Authorization.Activity.Entities;
using FluiTec.AppFx.Authorization.Activity.Repositories;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;

namespace FluiTec.AppFx.Authorization.Activity.LiteDb.Repositories
{
    /// <summary>An activity repository.</summary>
    public class LiteDbActivityRepository : LiteDbIntegerRepository<ActivityEntity>, IActivityRepository
    {
        /// <summary>Constructor.</summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public LiteDbActivityRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>Gets by resource and activity.</summary>
        /// <param name="resourceName"> Name of the resource. </param>
        /// <param name="activityName"> Name of the activity. </param>
        /// <returns>The by resource and activity.</returns>
        public ActivityEntity GetByResourceAndActivity(string resourceName, string activityName)
        {
            return Collection.Find(e => e.ResourceName == resourceName && e.Name == activityName).SingleOrDefault();
        }
    }
}