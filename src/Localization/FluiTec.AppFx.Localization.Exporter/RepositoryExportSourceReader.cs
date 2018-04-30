using System;
using System.Collections.Generic;
using DbLocalizationProvider;
using DbLocalizationProvider.Queries;
using FluiTec.AppFx.Localization.Handlers;

namespace FluiTec.AppFx.Localization.Exporter
{
    public class RepositoryExportSourceReader : IExportSourceReader
    {
        /// <summary>The data service.</summary>
        private readonly ILocalizationDataService _dataService;

        /// <summary>Constructor.</summary>
        /// <param name="dataService">  The data service. </param>
        public RepositoryExportSourceReader(ILocalizationDataService dataService)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        /// <summary>Enumerates read all in this collection.</summary>
        /// <returns>An enumerator that allows foreach to be used to process read all in this collection.</returns>
        public IEnumerable<LocalizationResource> ReadAll()
        {
            var handler = new GetAllResourcesHandler(_dataService);
            return handler.Execute(new GetAllResources.Query());
        }
    }
}