using System;
using System.Collections.Generic;
using System.Linq;
using FluiTec.AppFx.AspNetCore.Examples.AuthExample.Models;
using FluiTec.AppFx.AspNetCore.Examples.AuthExample.Models.Localization;
using FluiTec.AppFx.Localization;
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

            var page = PageableModel<ResourceGroup>.Page(rGroups, pageNumber);

            return View(page);
        }
    }
}