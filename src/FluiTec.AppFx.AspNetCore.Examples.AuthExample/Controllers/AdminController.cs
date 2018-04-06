using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using FluiTec.AppFx.AspNetCore.Configuration;
using FluiTec.AppFx.AspNetCore.Examples.AuthExample.Models.Admin;
using FluiTec.AppFx.AspNetCore.Examples.AuthExample.Models.Mail;
using FluiTec.AppFx.Authorization.Activity;
using FluiTec.AppFx.Authorization.Activity.Entities;
using FluiTec.AppFx.Identity;
using FluiTec.AppFx.Identity.Entities;
using FluiTec.AppFx.IdentityServer;
using FluiTec.AppFx.IdentityServer.Entities;
using FluiTec.AppFx.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Controllers
{
    /// <summary>   A controller for handling admin operations. </summary>
    [Authorize(PolicyNames.AdministrativeAccess)]
    public class AdminController : Controller
    {
        #region Fields

        /// <summary>   The identity data service. </summary>
        private readonly IIdentityDataService _identityDataService;

        /// <summary>   Manager for user. </summary>
        private readonly UserManager<IdentityUserEntity> _userManager;

        /// <summary>The authorization service.</summary>
        private readonly IAuthorizationService _authorizationService;

        /// <summary>Gets options for controlling the application.</summary>
        private readonly ApplicationOptions _applicationOptions;

        /// <summary>The email sender.</summary>
        private readonly ITemplatingMailService _emailSender;

        /// <summary>The localizer factory.</summary>
        private readonly IStringLocalizerFactory _localizerFactory;

        /// <summary>   The authorization data service. </summary>
        private readonly IAuthorizationDataService _authorizationDataService;

        /// <summary>The identity server data service.</summary>
        private readonly IIdentityServerDataService _identityServerDataService;

        #endregion

        #region Constructors

        /// <summary>Constructor.</summary>
        /// <param name="identityDataService">          The identity data service. </param>
        /// <param name="userManager">                  Manager for user. </param>
        /// <param name="authorizationService">         The authorization service. </param>
        /// <param name="applicationOptions">           Gets options for controlling the application. </param>
        /// <param name="emailSender">                  The email sender. </param>
        /// <param name="localizerFactory">             The localizer factory. </param>
        /// <param name="authorizationDataService">     The authorization data service. </param>
        /// <param name="identityServerDataService">    The identity server data service. </param>
        public AdminController(IIdentityDataService identityDataService, UserManager<IdentityUserEntity> userManager,
            IAuthorizationService authorizationService, ApplicationOptions applicationOptions,
            ITemplatingMailService emailSender, IStringLocalizerFactory localizerFactory,
            IAuthorizationDataService authorizationDataService, IIdentityServerDataService identityServerDataService)
        {
            _identityDataService = identityDataService;
            _userManager = userManager;
            _authorizationService = authorizationService;
            _applicationOptions = applicationOptions;
            _emailSender = emailSender;
            _localizerFactory = localizerFactory;
            _authorizationDataService = authorizationDataService;
            _identityServerDataService = identityServerDataService;
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
        [Authorize(PolicyNames.UsersAccess)]
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
        [Authorize(PolicyNames.UsersAccess)]
        [Authorize(PolicyNames.UsersUpdate)]
        public IActionResult ManageUser(int userId)
        {
            using (var uow = _identityDataService.StartUnitOfWork())
            {
                var user = uow.UserRepository.Get(userId);
                var roles = uow.RoleRepository.GetAll();
                var userRoles = uow.UserRoleRepository.FindByUser(user).Select(ur => roles.Single(r => r.Id == ur)).ToList();

                return View(new UserEditModel
                {
                    Email = user.Email,
                    Phone = user.Phone,
                    Id = user.Id,
                    Name = user.Name,
                    LockoutTime = user.LockedOutTill?.LocalDateTime,
                    UserRoles = userRoles.Select(ur => new UserRoleModel {Name = ur.Name}),
                    Roles = roles.Except(userRoles).Select(r => new UserRoleModel {Name = r.Name})
                });
            }
        }

        /// <summary>   Manage user. </summary>
        /// <param name="model">    The model. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpPost]
        [Authorize(PolicyNames.UsersAccess)]
        [Authorize(PolicyNames.UsersUpdate)]
        public IActionResult ManageUser(UserEditModel model)
        {
            model.Update();
            using (var uow = _identityDataService.StartUnitOfWork())
            {
                var dbUser = uow.UserRepository.Get(model.Id);
                var roles = uow.RoleRepository.GetAll();
                var userRoles = uow.UserRoleRepository.FindByUser(dbUser).Select(ur => roles.Single(r => r.Id == ur)).ToList();

                if (dbUser == null)
                    return View("Error");

                if (ModelState.IsValid)
                {
                    dbUser.Email = model.Email;
                    dbUser.Name = model.Name;
                    dbUser.Phone = model.Phone;
                    uow.UserRepository.Update(dbUser);
                    uow.Commit();
                    model.UpdateSuccess();
                }

                model.UserRoles = userRoles.Select(ur => new UserRoleModel {Name = ur.Name});
                model.Roles = roles.Except(userRoles).Select(r => new UserRoleModel {Name = r.Name});
            }

            return View(model);
        }

        /// <summary>   Lockout user. </summary>
        /// <param name="userId">   Identifier for the user. </param>
        /// <returns>   An IActionResult. </returns>
        [Authorize(PolicyNames.UsersAccess)]
        [Authorize(PolicyNames.UsersUpdate)]
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
        [Authorize(PolicyNames.UsersAccess)]
        [Authorize(PolicyNames.UsersUpdate)]
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
        [Authorize(PolicyNames.UsersAccess)]
        [Authorize(PolicyNames.UsersDelete)]
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
        [Authorize(PolicyNames.UsersAccess)]
        [Authorize(PolicyNames.UsersDelete)]
        public IActionResult DeleteUser(UserDeleteModel model)
        {
            if (ModelState.IsValid)
            {
                using (var uow = _identityDataService.StartUnitOfWork())
                {
                    var user = uow.UserRepository.FindByNormalizedEmail(model.Email.ToLower(CultureInfo.InvariantCulture));
                    var roles = uow.UserRoleRepository.FindByUser(user);
                    var userRoles = roles.Select(r => uow.UserRoleRepository.FindByUserIdAndRoleId(user.Id, r)).ToList();
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

        /// <summary>(An Action that handles HTTP POST requests) (Restricted to PolicyNames.UsersUpdate)
        /// adds a user role.</summary>
        /// <param name="model">    The model. </param>
        /// <returns>The asynchronous result that yields an IActionResult.</returns>
        [HttpPost]
        [Authorize(PolicyNames.UsersAccess)]
        [Authorize(PolicyNames.UsersUpdate)]
        [Authorize(PolicyNames.RolesAccess)]
        public async Task<IActionResult> AddUserRole(UserRoleModel model)
        {
            var authResult = await _authorizationService.AuthorizeAsync(User, typeof(IdentityUserEntity), new[]
            {
                ResourceActivities.AccessRequirement(typeof(IdentityUserEntity)),
                ResourceActivities.UpdateRequirement(typeof(IdentityUserEntity)),
                ResourceActivities.UpdateRequirement(typeof(IdentityRoleEntity))
            });
            if (!authResult.Succeeded)
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");

            if (model.UserId > 0)
            {
                // add user to role membership
                using (var uow = _identityDataService.StartUnitOfWork())
                {
                    var user = uow.UserRepository.Get(model.UserId);
                    var role = uow.RoleRepository.FindByNames(new [] {model.Name}).SingleOrDefault();

                    if (user != null && role != null)
                    {
                        uow.UserRoleRepository.Add(new IdentityUserRoleEntity { RoleId = role.Id, UserId = user.Id});
                        uow.Commit();
                        return RedirectToAction(nameof(ManageUser), new { userId = model.UserId });
                    }
                }
            }

            return View("Error");
        }

        /// <summary>(An Action that handles HTTP POST requests) (Restricted to PolicyNames.RolesUpdate)
        /// removes the user role described by model.</summary>
        /// <param name="model">    The model. </param>
        /// <returns>The asynchronous result that yields an IActionResult.</returns>
        [HttpPost]
        [Authorize(PolicyNames.UsersAccess)]
        [Authorize(PolicyNames.UsersUpdate)]
        [Authorize(PolicyNames.RolesAccess)]
        public async Task<IActionResult> RemoveUserRole(UserRoleModel model)
        {
            var authResult = await _authorizationService.AuthorizeAsync(User, typeof(IdentityUserEntity), new[]
            {
                ResourceActivities.AccessRequirement(typeof(IdentityUserEntity)),
                ResourceActivities.UpdateRequirement(typeof(IdentityUserEntity)),
                ResourceActivities.UpdateRequirement(typeof(IdentityRoleEntity))
            });
            if (!authResult.Succeeded)
                return RedirectToAction(nameof(AccountController.AccessDenied), "Account");

            if (model.UserId > 0)
            {
                // remove user from role membership
                using (var uow = _identityDataService.StartUnitOfWork())
                {
                    var user = uow.UserRepository.Get(model.UserId);
                    var role = uow.RoleRepository.FindByNames(new[] {model.Name}).SingleOrDefault();

                    if (user != null && role != null)
                    {
                        var roleToRemove = uow.UserRoleRepository.FindByUserIdAndRoleId(user.Id, role.Id);
                        if (roleToRemove != null)
                        {
                            uow.UserRoleRepository.Delete(roleToRemove);
                            uow.Commit();
                        }

                        return RedirectToAction(nameof(ManageUser), new {userId = model.UserId});
                    }
                }
            }

            return View("Error");
        }

        [HttpGet]
        [Authorize(PolicyNames.UsersAccess)]
        public async Task<IActionResult> ConfirmUser(int userId)
        {
            using (var uow = _identityDataService.StartUnitOfWork())
            {
                var user = uow.UserRepository.Get(userId);
                if (user == null) return RedirectToAction(nameof(ManageUsers));

                user.EmailConfirmed = true;
                uow.UserRepository.Update(user);
                uow.Commit();

                var mailModel = new AccountConfirmedModel(_localizerFactory, _applicationOptions, Url.Action(nameof(AccountController.Login), "Account"));
                await _emailSender.SendEmailAsync(user.Email, mailModel);
            }
            return RedirectToAction(nameof(ManageUser), new {userId});
        }

        #endregion

        #region Roles

        /// <summary>   Manage roles. </summary>
        /// <returns>   An IActionResult. </returns>
        [Authorize(PolicyNames.RolesAccess)]
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
        [Authorize(PolicyNames.RolesAccess)]
        [Authorize(PolicyNames.RolesUpdate)]
        public IActionResult ManageRole(int roleId)
        {
            using (var uow = _identityDataService.StartUnitOfWork())
            {
                var role = uow.RoleRepository.Get(roleId);
                return View(new RoleEditModel {Id = role.Id, Name = role.Name, Description = role.Description, Rights = GetRightsFor(role.Id)});
            }
        }

        /// <summary>   (An Action that handles HTTP POST requests) manage role. </summary>
        /// <param name="model">    The model. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpPost]
        [Authorize(PolicyNames.RolesAccess)]
        [Authorize(PolicyNames.RolesUpdate)]
        public async Task<IActionResult> ManageRole(RoleEditModel model)
        {
            // save updated rights
            var variables = await HttpContext.Request.ReadFormAsync();
            var rightValues = new Dictionary<int, int>();
            foreach (var variable in variables)
            {
                if (!int.TryParse(variable.Key, NumberStyles.Number, CultureInfo.InvariantCulture, out int x) ||
                    !int.TryParse(variable.Value, NumberStyles.Number, CultureInfo.InvariantCulture, out int y))
                    continue;

                if (!rightValues.ContainsKey(x))
                    rightValues.Add(x, y);
                else
                    rightValues[x] = y;
            }

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

                    SaveUpdatedRightsFor(model.Id, rightValues);

                    model.UpdateSuccess();
                }
            }

            model.Rights = GetRightsFor(model.Id);

            return View(model);
        }

        /// <summary>   Adds role. </summary>
        /// <returns>   An IActionResult. </returns>
        [Authorize(PolicyNames.RolesAccess)]
        [Authorize(PolicyNames.RolesCreate)]
        public IActionResult AddRole()
        {
            return View();
        }

        /// <summary>   Adds a role. </summary>
        /// <param name="model">    The model. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpPost]
        [Authorize(PolicyNames.RolesAccess)]
        [Authorize(PolicyNames.RolesCreate)]
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
        [Authorize(PolicyNames.RolesAccess)]
        [Authorize(PolicyNames.RolesDelete)]
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
        [Authorize(PolicyNames.RolesAccess)]
        [Authorize(PolicyNames.RolesDelete)]
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

        #region Claims

        /// <summary>   (An Action that handles HTTP GET requests) manage user claims. </summary>
        /// <param name="userid">   The userid. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpGet]
        [Authorize(PolicyNames.ClaimsAccess)]
        public IActionResult ManageUserClaims(int userid)
        {
            using (var uow = _identityDataService.StartUnitOfWork())
            {
                var user = uow.UserRepository.Get(userid);
                var claims = uow.ClaimRepository.GetByUser(user);
                return View(new UserClaimsModel
                {
                    UserId = userid,
                    ClaimEntries = claims.Select(c => new UserClaimsModel.ClaimEntry {Type = c.Type, Value = c.Value}).ToList()
                });
            }
        }

        /// <summary>   (An Action that handles HTTP GET requests) adds a user claim. </summary>
        /// <param name="userid">   The userid. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpGet]
        [Authorize(PolicyNames.ClaimsAccess)]
        [Authorize(PolicyNames.ClaimsUpdate)]
        public IActionResult AddUserClaim(int userid)
        {
            return View(new AddClaimModel {UserId = userid});
        }

        /// <summary>   Adds a user claim. </summary>
        /// <param name="model">    The model. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpPost]
        [Authorize(PolicyNames.ClaimsAccess)]
        [Authorize(PolicyNames.ClaimsUpdate)]
        public IActionResult AddUserClaim(AddClaimModel model)
        {
            model.Update();
            if (ModelState.IsValid)
            {
                using (var uow = _identityDataService.StartUnitOfWork())
                {
                    var user = uow.UserRepository.Get(model.UserId);

                    var existing = uow.ClaimRepository.GetByUser(user).SingleOrDefault(c => c.Type == model.Type);
                    if (existing == null)
                    {
                        uow.ClaimRepository.Add(new IdentityClaimEntity
                        {
                            UserId = user.Id,
                            Type = model.Type,
                            Value = model.Value
                        });
                    }
                    else
                    {
                        existing.Value = model.Value;
                        uow.ClaimRepository.Update(existing);
                    }

                    uow.Commit();
                    model.UpdateSuccess();
                    RedirectToAction(nameof(ManageUserClaims), new { userid = model.UserId });
                }
            }

            return View(model);
        }

        /// <summary>   Edit user claim. </summary>
        /// <param name="userid">       The userid. </param>
        /// <param name="claimType">    Type of the claim. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpGet]
        [Authorize(PolicyNames.ClaimsAccess)]
        [Authorize(PolicyNames.ClaimsUpdate)]
        public IActionResult EditUserClaim(int userid, string claimType)
        {
            using (var uow = _identityDataService.StartUnitOfWork())
            {
                var user = uow.UserRepository.Get(userid);
                var claim = uow.ClaimRepository.GetByUser(user).SingleOrDefault(c => c.Type == claimType);
                return View(new EditClaimModel { UserId = userid, Type = claimType, Value = claim?.Value});
            }
        }

        /// <summary>   (An Action that handles HTTP POST requests) edit user claim. </summary>
        /// <param name="model">    The model. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpPost]
        [Authorize(PolicyNames.ClaimsAccess)]
        [Authorize(PolicyNames.ClaimsUpdate)]
        public IActionResult EditUserClaim(EditClaimModel model)
        {
            model.Update();
            if (ModelState.IsValid)
            {
                using (var uow = _identityDataService.StartUnitOfWork())
                {
                    var user = uow.UserRepository.Get(model.UserId);

                    var existing = uow.ClaimRepository.GetByUser(user).SingleOrDefault(c => c.Type == model.Type);
                    if (existing == null)
                        return View("Error");

                    existing.Value = model.Value;
                    uow.ClaimRepository.Update(existing);

                    uow.Commit();
                    model.UpdateSuccess();
                }
            }

            return View(model);
        }

        /// <summary>
        ///     (An Action that handles HTTP GET requests) (Restricted to PolicyNames.ClaimsDelete)
        ///     deletes the user claim.
        /// </summary>
        /// <param name="userId">       Identifier for the user. </param>
        /// <param name="claimType">    Type of the claim. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpGet]
        [Authorize(PolicyNames.ClaimsAccess)]
        [Authorize(PolicyNames.ClaimsDelete)]
        public IActionResult DeleteUserClaim(int userId, string claimType)
        {
            return View(new DeleteClaimModel {UserId = userId, Type = claimType});
        }

        /// <summary>
        ///     (An Action that handles HTTP POST requests) (Restricted to PolicyNames.ClaimsDelete)
        ///     deletes the user claim described by model.
        /// </summary>
        /// <param name="model">    The model. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpPost]
        [Authorize(PolicyNames.ClaimsAccess)]
        [Authorize(PolicyNames.ClaimsDelete)]
        public IActionResult DeleteUserClaim(DeleteClaimModel model)
        {
            if (ModelState.IsValid)
            {
                using (var uow = _identityDataService.StartUnitOfWork())
                {
                    var user = uow.UserRepository.Get(model.UserId);
                    var claim = uow.ClaimRepository.GetByUser(user).SingleOrDefault(c => c.Type == model.Type);
                    uow.ClaimRepository.Delete(claim);
                    uow.Commit();
                }

                return RedirectToAction(nameof(ManageUserClaims), new {userid = model.UserId});
            }

            return View("Error");
        }

        #endregion

        #region Clients

        /// <summary>(Restricted to PolicyNames.ClientsAccess) gets the manage clients.</summary>
        /// <value>The manage clients.</value>
        [Authorize(PolicyNames.ClientsAccess)]
        public IActionResult ManageClients()
        {
            using (var uow = _identityServerDataService.StartUnitOfWork())
            {
                var clients = uow.ClientRepository.GetAll();
                return View(clients);
            }
        }

        /// <summary>(Restricted to PolicyNames.ClientsCreate) adds client.</summary>
        /// <returns>An IActionResult.</returns>
        [Authorize(PolicyNames.ClientsAccess)]
        [Authorize(PolicyNames.ClientsCreate)]
        public IActionResult AddClient()
        {
            return View(new ClientAddModel());
        }

        /// <summary>(An Action that handles HTTP POST requests) (Restricted to PolicyNames.ClientsCreate)
        /// adds a client.</summary>
        /// <param name="model">    The model. </param>
        /// <returns>An IActionResult.</returns>
        [HttpPost]
        [Authorize(PolicyNames.ClientsAccess)]
        [Authorize(PolicyNames.ClientsCreate)]
        public IActionResult AddClient(ClientAddModel model)
        {
            if (ModelState.IsValid)
            {
                using (var uow = _identityServerDataService.StartUnitOfWork())
                {
                    uow.ClientRepository.Add(new ClientEntity
                    {
                        Name = model.Name,
                        ClientId = RandomStringCreator.GenerateRandomString(64),
                        Secret = RandomStringCreator.GenerateRandomString(64),
                        RedirectUri = model.RedirectUri,
                        PostLogoutUri = model.PostLogoutUri,
                        AllowOfflineAccess = model.AllowOfflineAccess,
                        GrantTypes = string.Join(',', model.GrantTypes)
                    });
                    uow.Commit();
                }
                return RedirectToAction(nameof(ManageClients));
            }

            return View(model);
        }

        /// <summary>(Restricted to PolicyNames.ClientsUpdate) manage client.</summary>
        /// <param name="clientId"> Identifier for the client. </param>
        /// <returns>An IActionResult.</returns>
        [Authorize(PolicyNames.ClientsAccess)]
        [Authorize(PolicyNames.ClientsUpdate)]
        public IActionResult ManageClient(int clientId)
        {
            using (var uow = _identityServerDataService.StartUnitOfWork())
            {
                var client = uow.ClientRepository.Get(clientId);
                return View(new ClientEditModel
                {
                    Id = client.Id,
                    ClientId = client.ClientId,
                    ClientSecret = client.Secret,
                    AllowOfflineAccess = client.AllowOfflineAccess,
                    GrantTypes = client.GrantTypes.Split(",").ToList(),
                    Name = client.Name,
                    PostLogoutUri = client.PostLogoutUri,
                    RedirectUri = client.RedirectUri
                });
            }
        }

        /// <summary>(An Action that handles HTTP POST requests) (Restricted to PolicyNames.ClientsUpdate)
        /// manage client.</summary>
        /// <param name="model">    The model. </param>
        /// <returns>An IActionResult.</returns>
        [HttpPost]
        [Authorize(PolicyNames.ClientsAccess)]
        [Authorize(PolicyNames.ClientsUpdate)]
        public IActionResult ManageClient(ClientEditModel model)
        {
            model.Update();

            if (ModelState.IsValid)
            {
                using (var uow = _identityServerDataService.StartUnitOfWork())
                {
                    var existing = uow.ClientRepository.Get(model.Id);
                    existing.AllowOfflineAccess = model.AllowOfflineAccess;
                    existing.GrantTypes = string.Join(',', model.GrantTypes);
                    existing.Name = model.Name;
                    existing.PostLogoutUri = model.PostLogoutUri;
                    existing.RedirectUri = model.RedirectUri;
                    uow.ClientRepository.Update(existing);
                    uow.Commit();
                }

                model.UpdateSuccess();
                return View(model);
            }

            return View(model);
        }

        /// <summary>(Restricted to PolicyNames.ClientsDelete) deletes the client described by
        /// clientId.</summary>
        /// <param name="clientId"> Identifier for the client. </param>
        /// <returns>An IActionResult.</returns>
        [Authorize(PolicyNames.ClientsAccess)]
        [Authorize(PolicyNames.ClientsDelete)]
        public IActionResult DeleteClient(int clientId)
        {
            return View(new ClientDeleteModel { Id = clientId });
        }

        /// <summary>(An Action that handles HTTP POST requests) (Restricted to PolicyNames.ClientsDelete)
        /// deletes the client described by model.</summary>
        /// <param name="model">    The model. </param>
        /// <returns>An IActionResult.</returns>
        [HttpPost]
        [Authorize(PolicyNames.ClientsAccess)]
        [Authorize(PolicyNames.ClientsDelete)]
        public IActionResult DeleteClient(ClientDeleteModel model)
        {
            if (ModelState.IsValid)
            {
                using (var uow = _identityServerDataService.StartUnitOfWork())
                {
                    uow.ClientRepository.Delete(model.Id);
                    uow.Commit();
                }
            }

            return RedirectToAction(nameof(ManageClients));
        }

        #endregion

        #region Helpers

        /// <summary>   Gets rights for. </summary>
        /// <param name="roleId">   Identifier for the role. </param>
        /// <returns>   The rights for. </returns>
        private List<ActivityRightGroup> GetRightsFor(int roleId)
        {
            var rights = new List<ActivityRightGroup>();

            List<ActivityEntity> activities;
            List<ActivityRoleEntity> roleActivities;

            using (var uow = _authorizationDataService.StartUnitOfWork())
            {
                activities = uow.ActivityRepository.GetAll().ToList();
                roleActivities = uow.ActivityRoleRepository.ByRole(roleId).ToList();
            }

            foreach (var activityGroup in activities.GroupBy(a => a.GroupDisplayName))
            {
                var group = new ActivityRightGroup
                {
                    Name = activityGroup.First().GroupName,
                    DisplayName = activityGroup.Key,
                    Rights = new List<ActivityRight>()
                };

                foreach (var activity in activityGroup)
                {
                    var rA = roleActivities.SingleOrDefault(r => r.ActivityId == activity.Id);
                    int rightValue = 0;
                    if (rA?.Allow != null)
                    {
                        rightValue = rA.Allow.Value ? 2 : 1;
                    }

                    var right = new ActivityRight
                    {
                        ActivityId = activity.Id,
                        ActivityType = activity.Name,
                        Value = rightValue
                    };

                    group.Rights.Add(right);
                }
                rights.Add(group);
            }

            return rights;
        }

        /// <summary>   Saves an updated rights for. </summary>
        /// <param name="roleId">   Identifier for the role. </param>
        /// <param name="rights">   The rights. </param>
        private void SaveUpdatedRightsFor(int roleId, Dictionary<int, int> rights)
        {
            using (var uow = _authorizationDataService.StartUnitOfWork())
            {
                var existing = uow.ActivityRoleRepository.ByRole(roleId).ToList();
                foreach (var right in rights)
                {
                    var current = existing.SingleOrDefault(e => e.RoleId == roleId && e.ActivityId == right.Key);
                    if (current != null) // update or delete
                    {
                        if (right.Value != 0)
                        {
                            current.Allow = GetTristateValue(right.Value);
                            uow.ActivityRoleRepository.Update(current);
                        }

                        {
                            uow.ActivityRoleRepository.Delete(current);
                        }
                    }
                    else // create
                    {
                        if (right.Value != 0) // only for values other than "not defined"
                        {
                            var newEntry = new ActivityRoleEntity
                            {
                                ActivityId = right.Key,
                                RoleId = roleId,
                                Allow = GetTristateValue(right.Value)
                            };
                            uow.ActivityRoleRepository.Add(newEntry);
                        }
                    }
                }
                uow.Commit();
            }
        }

        /// <summary>   Gets tristate value. </summary>
        /// <param name="i">    Zero-based index of the. </param>
        /// <returns>   The tristate value. </returns>
        private bool? GetTristateValue(int i)
        {
            switch (i)
            {
                case 1:
                    return false;
                case 2:
                    return true;
                default:
                    return null;
            }
        }

        #endregion
    }
}
