using System;
using FluiTec.AppFx.Authorization.Activity.Requirements;

namespace FluiTec.AppFx.Authorization.Activity
{
    /// <summary>A resource activities.</summary>
    public static class ResourceActivities
    {
        /// <summary>Access requirement.</summary>
        /// <param name="resourceType"> Type of the resource. </param>
        /// <returns>A ResourceTypeOperationRequirement.</returns>
        public static ResourceTypeOperationRequirement AccessRequirement(Type resourceType)
        {
            return new ResourceTypeOperationRequirement(Activities.Access, resourceType);
        }

        /// <summary>Creates a requirement.</summary>
        /// <param name="resourceType"> Type of the resource. </param>
        /// <returns>The new requirement.</returns>
        public static ResourceTypeOperationRequirement CreateRequirement(Type resourceType)
        {
            return new ResourceTypeOperationRequirement(Activities.Create, resourceType);
        }

        /// <summary>Reads a requirement.</summary>
        /// <param name="resourceType"> Type of the resource. </param>
        /// <returns>The requirement.</returns>
        public static ResourceTypeOperationRequirement ReadRequirement(Type resourceType)
        {
            return new ResourceTypeOperationRequirement(Activities.Read, resourceType);
        }

        /// <summary>Updates the requirement described by resourceType.</summary>
        /// <param name="resourceType"> Type of the resource. </param>
        /// <returns>A ResourceTypeOperationRequirement.</returns>
        public static ResourceTypeOperationRequirement UpdateRequirement(Type resourceType)
        {
            return new ResourceTypeOperationRequirement(Activities.Update, resourceType);
        }

        /// <summary>Deletes the requirement described by resourceType.</summary>
        /// <param name="resourceType"> Type of the resource. </param>
        /// <returns>A ResourceTypeOperationRequirement.</returns>
        public static ResourceTypeOperationRequirement DeleteRequirement(Type resourceType)
        {
            return new ResourceTypeOperationRequirement(Activities.Delete, resourceType);
        }
    }
}