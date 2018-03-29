using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using FluiTec.AppFx.AspNetCore.Examples.AuthExample.Models.Admin;
using FluiTec.AppFx.Identity;
using FluiTec.AppFx.Identity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

        /// <summary>   Manager for user. </summary>
        private readonly UserManager<IdentityUserEntity> _userManager;

        #endregion

        #region Constructors

        /// <summary>   Constructor. </summary>
        /// <param name="identityDataService">  The identity data service. </param>
        /// <param name="userManager">          Manager for user. </param>
        public AdminController(IIdentityDataService identityDataService, UserManager<IdentityUserEntity> userManager)
        {
            _identityDataService = identityDataService;
            _userManager = userManager;
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
                return View(new UserEditModel { Email = user.Email, Phone = user.Phone, Id = user.Id, Name = user.Name, LockoutTime = user.LockedOutTill?.LocalDateTime });
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

        /// <summary>   Lockout user. </summary>
        /// <param name="userId">   Identifier for the user. </param>
        /// <returns>   An IActionResult. </returns>
        public IActionResult LockoutUser(int userId)
        {
            using (var uow = _identityDataService.StartUnitOfWork())
            {
                var user = uow.UserRepository.Get(userId);
                return View(new UserLockoutModel {Email = user.Email, LockoutTime = DateTime.Now.AddDays(1)});
            }
        }

        /// <summary>   Lockout user. </summary>
        /// <param name="model">    The model. </param>
        /// <returns>   An asynchronous result that yields an IActionResult. </returns>
        [HttpPost]
        public async Task<IActionResult> LockoutUser(UserLockoutModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (model.LockoutTime.HasValue && model.LockoutTime > DateTime.Now) // locks the user out
                {
                    await _userManager.SetLockoutEndDateAsync(user,
                        new DateTimeOffset(model.LockoutTime.Value.ToUniversalTime()));
                    return RedirectToAction(nameof(ManageUser), new {userId = user.Id});
                }

                await _userManager.SetLockoutEndDateAsync(user, null);
                return RedirectToAction(nameof(ManageUser), new { userId = user.Id });
            }

            return View(model);
        }

        /// <summary>   Deletes the user described by userId. </summary>
        /// <param name="userId">   Identifier for the user. </param>
        /// <returns>   An IActionResult. </returns>
        public IActionResult DeleteUser(int userId)
        {
            using (var uow = _identityDataService.StartUnitOfWork())
            {
                var user = uow.UserRepository.Get(userId);
                return View(new UserDeleteModel { Email = user.Email });
            }
        }

        /// <summary>
        ///     Deletes the user described by model.
        /// </summary>
        /// <param name="model">    The model. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpPost]
        public IActionResult DeleteUser(UserDeleteModel model)
        {
            if (ModelState.IsValid)
            {
                using (var uow = _identityDataService.StartUnitOfWork())
                {
                    var user = uow.UserRepository.FindByNormalizedEmail(model.Email.ToLower(CultureInfo.InvariantCulture));
                    var userRoles = uow.UserRoleRepository.FindByUser(user);
                    var userLogins = uow.LoginRepository.FindByUserId(user.Identifier);

                    foreach(var userRole in userRoles)
                        uow.UserRoleRepository.Delete(userRole);
                    
                    foreach(var userLogin in userLogins)
                        uow.LoginRepository.Delete(userLogin);

                    uow.UserRepository.Delete(user);
                    uow.Commit();
                    return RedirectToAction(nameof(ManageUsers));
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
                    return RedirectToAction(nameof(ManageRoles));
                }
            }

            return View(model);
        }

        /// <summary>   Deletes the role described by roleId. </summary>
        /// <param name="roleId">   Identifier for the role. </param>
        /// <returns>   An IActionResult. </returns>
        public IActionResult DeleteRole(int roleId)
        {
            using (var uow = _identityDataService.StartUnitOfWork())
            {
                var role = uow.RoleRepository.Get(roleId);
                return View(new RoleDeleteModel { Id = role.Id, Name = role.Name });
            }
        }

        /// <summary>
        ///     Deletes the role described by model.
        /// </summary>
        /// <param name="model">    The model. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpPost]
        public IActionResult DeleteRole(RoleDeleteModel model)
        {
            if (ModelState.IsValid)
            {
                using (var uow = _identityDataService.StartUnitOfWork())
                {
                    var role = uow.RoleRepository.Get(model.Id);
                    var userRoles = uow.UserRoleRepository.FindByRole(role);

                    foreach (var userRole in userRoles)
                        uow.UserRoleRepository.Delete(userRole);
                    uow.RoleRepository.Delete(role);

                    uow.Commit();
                    return RedirectToAction(nameof(ManageRoles));
                }
            }

            return View();
        }

        #endregion
    }
}
