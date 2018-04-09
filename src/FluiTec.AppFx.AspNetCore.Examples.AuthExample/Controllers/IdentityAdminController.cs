using System.Linq;
using FluiTec.AppFx.AspNetCore.Examples.AuthExample.Models.IdentityAdmin;
using FluiTec.AppFx.IdentityServer;
using FluiTec.AppFx.IdentityServer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Controllers
{
    /// <summary>   A controller for handling identity admins. </summary>
    [Authorize(PolicyNames.AdministrativeAccess)]
    public class IdentityAdminController : Controller
    {
        #region Fields

        /// <summary>   The identity server data service. </summary>
        private readonly IIdentityServerDataService _identityServerDataService;

        #endregion

        #region Constructors

        public IdentityAdminController(IIdentityServerDataService identityServerDataService)
        {
            _identityServerDataService = identityServerDataService;
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

        #region Scopes

        /// <summary>(Restricted to PolicyNames.ScopesAccess) manage scopes.</summary>
        /// <returns>An IActionResult.</returns>
        [Authorize(PolicyNames.ScopesAccess)]
        public IActionResult ManageScopes()
        {
            using (var uow = _identityServerDataService.StartUnitOfWork())
            {
                var scopes = uow.ScopeRepository.GetAll();
                return View(scopes);
            }
        }

        /// <summary>(Restricted to PolicyNames.ScopesCreate) adds scope.</summary>
        /// <returns>An IActionResult.</returns>
        [Authorize(PolicyNames.ScopesAccess)]
        [Authorize(PolicyNames.ScopesCreate)]
        public IActionResult AddScope()
        {
            return View(new ScopeAddModel { Emphasize = true, Required = true, ShowInDiscoveryDocument = true });
        }

        /// <summary>(An Action that handles HTTP POST requests) (Restricted to PolicyNames.ScopesCreate)
        /// adds a scope.</summary>
        /// <param name="model">    The model. </param>
        /// <returns>An IActionResult.</returns>
        [HttpPost]
        [Authorize(PolicyNames.ScopesAccess)]
        [Authorize(PolicyNames.ScopesCreate)]
        public IActionResult AddScope(ScopeAddModel model)
        {
            if (ModelState.IsValid)
            {
                using (var uow = _identityServerDataService.StartUnitOfWork())
                {
                    uow.ScopeRepository.Add(new ScopeEntity
                    {
                        Name = model.Name,
                        DisplayName = model.DisplayName,
                        Description = model.Description,
                        Required = model.Required,
                        Emphasize = model.Emphasize,
                        ShowInDiscoveryDocument = model.ShowInDiscoveryDocument
                    });
                    uow.Commit();
                }

                return RedirectToAction(nameof(ManageScopes));
            }

            return View(model);
        }

        /// <summary>(Restricted to PolicyNames.ScopesUpdate) manage scope.</summary>
        /// <param name="scopeId">  Identifier for the scope. </param>
        /// <returns>An IActionResult.</returns>
        [Authorize(PolicyNames.ScopesAccess)]
        [Authorize(PolicyNames.ScopesUpdate)]
        public IActionResult ManageScope(int scopeId)
        {
            using (var uow = _identityServerDataService.StartUnitOfWork())
            {
                var scope = uow.ScopeRepository.Get(scopeId);
                return View(new ScopeEditModel
                {
                    Id = scope.Id,
                    Name = scope.Name,
                    DisplayName = scope.DisplayName,
                    Description = scope.Description,
                    Required = scope.Required,
                    Emphasize = scope.Emphasize,
                    ShowInDiscoveryDocument = scope.ShowInDiscoveryDocument
                });
            }
        }

        /// <summary>(An Action that handles HTTP POST requests) (Restricted to PolicyNames.ScopesUpdate)
        /// manage scope.</summary>
        /// <param name="model">    The model. </param>
        /// <returns>An IActionResult.</returns>
        [HttpPost]
        [Authorize(PolicyNames.ScopesAccess)]
        [Authorize(PolicyNames.ScopesUpdate)]
        public IActionResult ManageScope(ScopeEditModel model)
        {
            model.Update();
            if (ModelState.IsValid)
            {
                using (var uow = _identityServerDataService.StartUnitOfWork())
                {
                    var existing = uow.ScopeRepository.Get(model.Id);
                    existing.Name = model.Name;
                    existing.DisplayName = model.DisplayName;
                    existing.Description = model.Description;
                    existing.Required = model.Required;
                    existing.Emphasize = model.Emphasize;
                    existing.ShowInDiscoveryDocument = model.ShowInDiscoveryDocument;
                    uow.ScopeRepository.Update(existing);
                    uow.Commit();

                    model.UpdateSuccess();
                }
            }

            return View(model);
        }

        /// <summary>
        ///     (Restricted to PolicyNames.ScopesDelete) deletes the scope described by scopeId.
        /// </summary>
        /// <param name="scopeId">  Identifier for the scope. </param>
        /// <returns>   An IActionResult. </returns>
        [Authorize(PolicyNames.ScopesAccess)]
        [Authorize(PolicyNames.ScopesDelete)]
        public IActionResult DeleteScope(int scopeId)
        {
            return View(new ScopeDeleteModel { Id = scopeId });
        }

        /// <summary>
        ///     (An Action that handles HTTP POST requests) (Restricted to PolicyNames.ScopesDelete)
        ///     deletes the scope described by model.
        /// </summary>
        /// <param name="model">    The model. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpPost]
        [Authorize(PolicyNames.ScopesAccess)]
        [Authorize(PolicyNames.ScopesDelete)]
        public IActionResult DeleteScope(ScopeDeleteModel model)
        {
            if (ModelState.IsValid)
            {
                using (var uow = _identityServerDataService.StartUnitOfWork())
                {
                    var scope = uow.ScopeRepository.Get(model.Id);
                    uow.ScopeRepository.Delete(scope);
                    uow.Commit();
                }

                return RedirectToAction(nameof(ManageScopes));
            }

            return View(model);
        }

        #endregion

        #region ClientClaims

        /// <summary>   (An Action that handles HTTP GET requests) manage Client claims. </summary>
        /// <param name="clientid">   The client-id. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpGet]
        [Authorize(PolicyNames.ClaimsAccess)]
        public IActionResult ManageClientClaims(int clientid)
        {
            using (var uow = _identityServerDataService.StartUnitOfWork())
            {
                var claims = uow.ClientClaimRepository.GetAll().Where(c => c.ClientId == clientid);
                return View(new ClientClaimsModel
                {
                    ClientId = clientid,
                    ClaimEntries = claims.Select(c => new ClientClaimsModel.ClaimEntry { Type = c.ClaimType, Value = c.ClaimValue }).ToList()
                });
            }
        }

        /// <summary>   (An Action that handles HTTP GET requests) adds a Client claim. </summary>
        /// <param name="clientid">   The client-id. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpGet]
        [Authorize(PolicyNames.ClaimsAccess)]
        [Authorize(PolicyNames.ClaimsUpdate)]
        public IActionResult AddClientClaim(int clientid)
        {
            return View(new AddClaimModel { ClientId = clientid });
        }

        /// <summary>   Adds a Client claim. </summary>
        /// <param name="model">    The model. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpPost]
        [Authorize(PolicyNames.ClaimsAccess)]
        [Authorize(PolicyNames.ClaimsUpdate)]
        public IActionResult AddClientClaim(AddClaimModel model)
        {
            model.Update();
            if (ModelState.IsValid)
            {
                using (var uow = _identityServerDataService.StartUnitOfWork())
                {
                    var existing = uow.ClientClaimRepository.GetAll().Where(c => c.ClientId == model.ClientId).SingleOrDefault(c => c.ClaimType == model.Type);
                    if (existing == null)
                    {
                        uow.ClientClaimRepository.Add(new ClientClaimEntity
                        {
                            ClientId = model.ClientId,
                            ClaimType = model.Type,
                            ClaimValue = model.Value
                        });
                    }
                    else
                    {
                        existing.ClaimValue = model.Value;
                        uow.ClientClaimRepository.Update(existing);
                    }

                    uow.Commit();
                    model.UpdateSuccess();
                    RedirectToAction(nameof(ManageClientClaims), new { Clientid = model.ClientId });
                }
            }

            return View(model);
        }

        /// <summary>   Edit Client claim. </summary>
        /// <param name="clientid">       The client-id. </param>
        /// <param name="claimType">    Type of the claim. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpGet]
        [Authorize(PolicyNames.ClaimsAccess)]
        [Authorize(PolicyNames.ClaimsUpdate)]
        public IActionResult EditClientClaim(int clientid, string claimType)
        {
            using (var uow = _identityServerDataService.StartUnitOfWork())
            { 
                var claim = uow.ClientClaimRepository.GetAll().Where(c => c.ClientId == clientid).SingleOrDefault(c => c.ClaimType == claimType);
                return View(new EditClaimModel { ClientId = clientid, Type = claimType, Value = claim?.ClaimValue });
            }
        }

        /// <summary>   (An Action that handles HTTP POST requests) edit Client claim. </summary>
        /// <param name="model">    The model. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpPost]
        [Authorize(PolicyNames.ClaimsAccess)]
        [Authorize(PolicyNames.ClaimsUpdate)]
        public IActionResult EditClientClaim(EditClaimModel model)
        {
            model.Update();
            if (ModelState.IsValid)
            {
                using (var uow = _identityServerDataService.StartUnitOfWork())
                {
                    var existing = uow.ClientClaimRepository.GetAll().Where(c => c.ClientId == model.ClientId).SingleOrDefault(c => c.ClaimType == model.Type);
                    if (existing == null)
                        return View("Error");

                    existing.ClaimValue = model.Value;
                    uow.ClientClaimRepository.Update(existing);

                    uow.Commit();
                    model.UpdateSuccess();
                }
            }

            return View(model);
        }

        /// <summary>
        ///     (An Action that handles HTTP GET requests) (Restricted to PolicyNames.ClaimsDelete)
        ///     deletes the Client claim.
        /// </summary>
        /// <param name="clientId">       Identifier for the Client. </param>
        /// <param name="claimType">    Type of the claim. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpGet]
        [Authorize(PolicyNames.ClaimsAccess)]
        [Authorize(PolicyNames.ClaimsDelete)]
        public IActionResult DeleteClientClaim(int clientId, string claimType)
        {
            return View(new DeleteClaimModel { ClientId = clientId, Type = claimType });
        }

        /// <summary>
        ///     (An Action that handles HTTP POST requests) (Restricted to PolicyNames.ClaimsDelete)
        ///     deletes the Client claim described by model.
        /// </summary>
        /// <param name="model">    The model. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpPost]
        [Authorize(PolicyNames.ClaimsAccess)]
        [Authorize(PolicyNames.ClaimsDelete)]
        public IActionResult DeleteClientClaim(DeleteClaimModel model)
        {
            if (ModelState.IsValid)
            {
                using (var uow = _identityServerDataService.StartUnitOfWork())
                {
                    var claim = uow.ClientClaimRepository.GetAll().Where(c => c.ClientId == model.ClientId).SingleOrDefault(c => c.ClaimType == model.Type);
                    uow.ClientClaimRepository.Delete(claim);
                    uow.Commit();
                }

                return RedirectToAction(nameof(ManageClientClaims), new { Clientid = model.ClientId });
            }

            return View("Error");
        }

        #endregion
    }
}