using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace FluiTec.AppFx.Authorization.Activity.Requirements
{
    /// <summary>A resource type operation requirement.</summary>
    public class ResourceTypeOperationRequirement : IAuthorizationRequirement
    {
        /// <summary>Gets the operation.</summary>
        /// <value>The operation.</value>
        public OperationAuthorizationRequirement Operation { get; }

        /// <summary>Gets the type of the resource.</summary>
        /// <value>The type of the resource.</value>
        public Type ResourceType { get; }

        /// <summary>Constructor.</summary>
        /// <param name="operation">    The operation. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        public ResourceTypeOperationRequirement(OperationAuthorizationRequirement operation, Type resourceType)
        {
            Operation = operation;
            ResourceType = resourceType;
        }
    }
}