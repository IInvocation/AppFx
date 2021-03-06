﻿using FluiTec.AppFx.Data;
using FluiTec.AppFx.Identity.Repositories;

namespace FluiTec.AppFx.Identity
{
    /// <summary>	Interface for identity unit of work. </summary>
    public interface IIdentityUnitOfWork : IUnitOfWork
    {
        /// <summary>	Gets the user repository. </summary>
        /// <value>	The user repository. </value>
        IUserRepository UserRepository { get; }

        /// <summary>	Gets the role repository. </summary>
        /// <value>	The role repository. </value>
        IRoleRepository RoleRepository { get; }

        /// <summary>	Gets or sets the user role repository. </summary>
        /// <value>	The user role repository. </value>
        IUserRoleRepository UserRoleRepository { get; }

        /// <summary>	Gets the claim repository. </summary>
        /// <value>	The claim repository. </value>
        IClaimRepository ClaimRepository { get; }

        /// <summary>	Gets the login repository. </summary>
        /// <value>	The login repository. </value>
        IUserLoginRepository LoginRepository { get; }
    }
}