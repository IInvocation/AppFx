using System;
using System.Collections.Generic;
using System.Linq;
using DbLocalizationProvider;
using DbLocalizationProvider.Cache;
using FluiTec.AppFx.AspNetCore.Examples.AuthExample.Models;
using FluiTec.AppFx.AspNetCore.Examples.AuthExample.Models.Localization;
using FluiTec.AppFx.Localization;
using FluiTec.AppFx.Localization.Entities;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Controllers
{
    /// <summary>   A controller for handling localizations. </summary>
    [Authorize(PolicyNames.LocalizationAccess)]
    public class LocalizationController : Controller
    {
        #region Fields

        /// <summary>   The localization data service. </summary>
        private readonly ILocalizationDataService _localizationDataService;

        /// <summary>   The localizer. </summary>
        private readonly IStringLocalizer<Resources.Controllers.LocalizationResource> _localizer;

        #endregion

        /// <summary>   Constructor. </summary>
        /// <param name="localizationDataService">  The localization data service. </param>
        /// <param name="localizer">                The localizer. </param>
        public LocalizationController(ILocalizationDataService localizationDataService, IStringLocalizer<Resources.Controllers.LocalizationResource> localizer)
        {
            _localizationDataService = localizationDataService;
            _localizer = localizer;
        }

        /// <summary>   Gets the index. </summary>
        /// <returns>   An IActionResult. </returns>
        [Authorize(PolicyNames.LocalizationAccess)]
        public IActionResult Index(int pageNumber = 1)
        {
            var rGroups = new List<ResourceGroup>();
            using (var uow = _localizationDataService.StartUnitOfWork())
            {
                var resources = uow.ResourceRepository.GetAll().ToList();

                var ungroupable = resources.Where(r => r.ResourceKey != null && !r.ResourceKey.Contains(".")).OrderBy(r => r.ResourceKey).ToList();
                var groupable = resources.Except(ungroupable);
                var groups = groupable.GroupBy(r =>
                    r.ResourceKey.Substring(0, r.ResourceKey.LastIndexOf(".", StringComparison.Ordinal))).OrderBy(g => g.Key);

                rGroups.Add(new ResourceGroup { Name = _localizer.GetString(r => r.Ungrouped), Entries = ungroupable.Count});
                rGroups.AddRange(groups.Select(g => new ResourceGroup { Name = g.Key, Entries = g.Count() }));
            }

            var page = PageableModel<ResourceGroup>.PageExisting(rGroups, pageNumber).InitRoute(this, nameof(Index));

            return View(page);
        }

        /// <summary>   Groups. </summary>
        /// <param name="groupKey">     (Optional) The group key. </param>
        /// <param name="pageNumber">   (Optional) The page number. </param>
        /// <returns>   An IActionResult. </returns>
        public IActionResult Group(string groupKey = "", int pageNumber = 1)
        {
            if (groupKey == _localizer.GetString(r => r.Ungrouped)) groupKey = string.Empty;
            var displayResources = new List<ResourceEntity>();
            using (var uow = _localizationDataService.StartUnitOfWork())
            {
                var resources = uow.ResourceRepository.GetAll().ToList();

                var ungroupable = resources.Where(r => r.ResourceKey != null && !r.ResourceKey.Contains(".")).OrderBy(r => r.ResourceKey).ToList();
                var groupable = resources.Except(ungroupable);
                var groups = groupable.GroupBy(r =>
                    r.ResourceKey.Substring(0, r.ResourceKey.LastIndexOf(".", StringComparison.Ordinal))).OrderBy(g => g.Key);

                if (groupKey == string.Empty)
                {
                    displayResources.AddRange(ungroupable);
                    var page = PageableModel<ResourceEntity>.PageExisting(displayResources, pageNumber)
                        .InitRoute(this, nameof(Group));
                    return View(page);
                }

                var group = groups.SingleOrDefault(g => g.Key == groupKey);
                if (group == null) return RedirectToAction(nameof(Index));
                {
                    displayResources.AddRange(group);
                    var page = PageableModel<ResourceEntity>.PageExisting(displayResources, pageNumber)
                        .InitRoute(this, nameof(Group));
                    return View(page);
                }

            }
        }

        /// <summary>   Translations. </summary>
        /// <param name="resourceKey">  The resource key. </param>
        /// <param name="pageNumber">   (Optional) The page number. </param>
        /// <returns>   An IActionResult. </returns>
        public IActionResult Translations(string resourceKey, int pageNumber = 1)
        {
            using (var uow = _localizationDataService.StartUnitOfWork())
            {
                var resource = uow.ResourceRepository.GetByKey(resourceKey);
                if (resource == null) return RedirectToAction(nameof(Index));
                var translations = uow.TranslationRepository.ByResource(resource);
                var page = PageableModel<TranslationEntity>.PageExisting(translations, pageNumber)
                    .InitRoute(this, nameof(Translations));
                return View(page);
            }
        }

        /// <summary>   Translations. </summary>
        /// <param name="id">   The identifier. </param>
        /// <returns>   An IActionResult. </returns>
        public IActionResult Translation(int id)
        {
            using (var uow = _localizationDataService.StartUnitOfWork())
            {
                var translation = uow.TranslationRepository.Get(id);
                if (translation == null) return RedirectToAction(nameof(Index));

                return View(new Translation {Id = translation.Id, Value = translation.Value});
            }
        }

        /// <summary>
        ///     (An Action that handles HTTP POST requests) translations the given model.
        /// </summary>
        /// <param name="model">    The model. </param>
        /// <returns>   An IActionResult. </returns>
        [HttpPost]
        public IActionResult Translation(Translation model)
        {
            model.Update();
            if (ModelState.IsValid)
            {
                using (var uow = _localizationDataService.StartUnitOfWork())
                {
                    var existing = uow.TranslationRepository.Get(model.Id);
                    if (existing == null) return RedirectToAction(nameof(Index));

                    var resource = uow.ResourceRepository.Get(existing.ResourceId);
                    resource.Author = User.GetDisplayName();
                    resource.FromCode = false;
                    uow.ResourceRepository.Update(resource);

                    existing.Value = model.Value;
                    uow.TranslationRepository.Update(existing);

                    uow.Commit();
                    model.UpdateSuccess();
                    new ClearCache.Command().Execute();
                }
            }

            return View(model);
        }

        /// <summary>   Adds a translation. </summary>
        /// <param name="id">   The identifier. </param>
        /// <returns>   An IActionResult. </returns>
        public IActionResult AddTranslation(int id)
        {
            using (var uow = _localizationDataService.StartUnitOfWork())
            {
                var resource = uow.ResourceRepository.Get(id);
                if (resource == null) return RedirectToAction(nameof(Index));
                return View(new AddTranslation { ResourceId = resource.Id });
            }
        }

        /// <summary>   Adds a translation. </summary>
        /// <param name="model">    The model. </param>
        /// <returns>   An IActionResult. </returns>
        public IActionResult AddTranslation(AddTranslation model)
        {
            if (ModelState.IsValid)
            {
                using (var uow = _localizationDataService.StartUnitOfWork())
                {
                    var resource = uow.ResourceRepository.Get(model.ResourceId);
                    if (resource == null) return RedirectToAction(nameof(Index));

                    var translation = uow.TranslationRepository.ByResource(resource).SingleOrDefault(t => t.Language == model.Language);
                    if (translation != null) return RedirectToAction(nameof(Translation), new {id = translation.Id});

                    var newTranslation = new TranslationEntity
                    {
                        ResourceId = model.ResourceId,
                        Language = model.Language,
                        Value = model.Value
                    };
                    uow.TranslationRepository.Add(newTranslation);
                    uow.Commit();
                }
            }

            return View(model);
        }
    }
}