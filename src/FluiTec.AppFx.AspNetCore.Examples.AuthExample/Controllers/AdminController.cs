using System;
using System.Linq;
using FluiTec.AppFx.AspNetCore.Examples.AuthExample.Models.Admin;
using FluiTec.AppFx.Identity;
using FluiTec.AppFx.Identity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Controllers
{
    /// <summary>   A controller for handling admin operations. </summary>
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        #region Fields

        /// <summary>   The identity data service. </summary>
        private readonly IIdentityDataService _identityDataService;

        #endregion

        #region Constructors

        /// <summary>   Constructor. </summary>
        /// <param name="identityDataService">  The identity data service. </param>
        public AdminController(IIdentityDataService identityDataService)
        {
            _identityDataService = identityDataService;
        }

        #endregion

        #region Index

        /// <summary>   Gets the index. </summary>
        /// <returns>   An IActionResult. </returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region Users

        /// <summary>   Manage users. </summary>
        /// <returns>   An IActionResult. </returns>
        public IActionResult ManageUsers()
        {
            using (var uow = _identityDataService.StartUnitOfWork())
            {
                var users = uow.UserRepository.GetAll();
                return View(users);
            }
        }

        /// <summary>   Manage user. </summary>
        /// <param name="userId">   Identifier for the user. </param>
        /// <returns>   An IActionResult. </returns>
        public IActionResult ManageUser(int userId)
        {
            using (var uow = _identityDataService.StartUnitOfWork())
            {
                var user = uow.UserRepository.Get(userId);
                return View(new UserEditModel { Email = user.Email, Phone = user.Phone, Id = user.Id, Name = user.Name });
            }
        }

        /// <summary>   Manage user. </summary>
        /// <param name="model">    The model. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpPost]
        public IActionResult ManageUser(UserEditModel model)
        {
            model.Update();
            if (ModelState.IsValid)
            {
                using (var uow = _identityDataService.StartUnitOfWork())
                {
                    var dbUser = uow.UserRepository.Get(model.Id);
                    if (dbUser == null)
                        return View("Error");

                    dbUser.Email = model.Email;
                    dbUser.Name = model.Name;
                    dbUser.Phone = model.Phone;
                    uow.UserRepository.Update(dbUser);
                    uow.Commit();
                    model.UpdateSuccess();
                }
            }

            return View(model);
        }

        #endregion

        #region Roles

        /// <summary>   Manage roles. </summary>
        /// <returns>   An IActionResult. </returns>
        public IActionResult ManageRoles()
        {
            using (var uow = _identityDataService.StartUnitOfWork())
            {
                var roles = uow.RoleRepository.GetAll()
                    .Where(r => r.Name != "Administrator");
                return View(roles);
            }
        }

        /// <summary>   Manage role. </summary>
        /// <param name="roleId">   Identifier for the role. </param>
        /// <returns>   An IActionResult. </returns>
        public IActionResult ManageRole(int roleId)
        {
            using (var uow = _identityDataService.StartUnitOfWork())
            {
                var role = uow.RoleRepository.Get(roleId);
                return View(new RoleEditModel {Id = role.Id, Name = role.Name, Description = role.Description});
            }
        }

        /// <summary>   (An Action that handles HTTP POST requests) manage role. </summary>
        /// <param name="model">    The model. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpPost]
        public IActionResult ManageRole(RoleEditModel model)
        {
            model.Update();
            if (ModelState.IsValid)
            {
                using (var uow = _identityDataService.StartUnitOfWork())
                {
                    var dbRole = uow.RoleRepository.Get(model.Id);
                    if (dbRole == null)
                        return View("Error");

                    dbRole.Name = model.Name;
                    dbRole.Description = model.Description;
                    uow.RoleRepository.Update(dbRole);
                    uow.Commit();
                    model.UpdateSuccess();
                }
            }

            return View(model);
        }

        /// <summary>   Adds role. </summary>
        /// <returns>   An IActionResult. </returns>
        public IActionResult AddRole()
        {
            return View();
        }

        /// <summary>   Adds a role. </summary>
        /// <param name="model">    The model. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpPost]
        public IActionResult AddRole(RoleAddModel model)
        {
            if (ModelState.IsValid)
            {
                using (var uow = _identityDataService.StartUnitOfWork())
                {
                    var role = new IdentityRoleEntity
                    {
                        ApplicationId = 0,
                        Name = model.Name,
                        Description = model.Description,
                        Identifier = Guid.NewGuid(),
                        NormalizedName = model.Name.ToUpper()
                    };
                    uow.RoleRepository.Add(role);
                    uow.Commit();
                    RedirectToAction(nameof(ManageRoles));
                }
            }

            return View(model);
        }

        #endregion
    }
}
