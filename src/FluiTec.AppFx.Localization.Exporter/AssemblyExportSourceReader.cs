using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using DbLocalizationProvider;
using DbLocalizationProvider.Abstractions;
using DbLocalizationProvider.Internal;
using DbLocalizationProvider.Queries;
using DbLocalizationProvider.Sync;

namespace FluiTec.AppFx.Localization.Exporter
{
    /// <summary>An assembly export source reader.</summary>
    public class AssemblyExportSourceReader : IExportSourceReader
    {
        /// <summary>The assembly.</summary>
        private readonly Assembly _assembly;

        /// <summary>Constructor.</summary>
        public AssemblyExportSourceReader(string assemblyFile)
        {
            if (File.Exists(assemblyFile))
            {
                _assembly = Assembly.LoadFrom(assemblyFile);
            }
            else
            {
                throw new FileNotFoundException("Could not find Assembly-File.", assemblyFile);
            }
        }

        /// <summary>Enumerates read all in this collection.</summary>
        /// <returns>An enumerator that allows foreach to be used to process read all in this collection.</returns>
        public IEnumerable<LocalizationResource> ReadAll()
        {
            ConfigurationContext.Current.TypeFactory.ForQuery<DetermineDefaultCulture.Query>().SetHandler<DetermineDefaultCulture.Handler>();

            var discoveredTypes = TypeDiscoveryHelper.GetTypes(t => t.GetCustomAttribute<LocalizedResourceAttribute>() != null,
                t => t.GetCustomAttribute<LocalizedModelAttribute>() != null);

            var discoveredResources = discoveredTypes[0];
            var discoveredModels = discoveredTypes[1];
            var types = discoveredResources.Concat(discoveredModels);

            var helper = new TypeDiscoveryHelper();
            var props = types.SelectMany(type => helper.ScanResources(type)).DistinctBy(r => r.Key);

            return props.Select(p => new LocalizationResource(p.Key)
            {
                Author = "Code",
                FromCode = true,
                IsHidden = p.IsHidden,
                IsModified = false,
                ModificationDate = DateTime.Now,
                Translations = p.Translations.Select(t => new LocalizationResourceTranslation
                {
                    Language = t.Culture,
                    Value = t.Translation
                }).ToList()
            });
        }
    }
}