﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DbLocalizationProvider.Abstractions;
using DbLocalizationProvider.Refactoring;

namespace DbLocalizationProvider.Sync.Collectors
{
    internal class CasualResourceCollector : IResourceCollector
    {
        public IEnumerable<DiscoveredResource> GetDiscoveredResources(
            Type target,
            object instance,
            MemberInfo mi,
            string translation,
            string resourceKey,
            string resourceKeyPrefix,
            bool typeKeyPrefixSpecified,
            bool isHidden,
            string typeOldName,
            string typeOldNamespace,
            Type declaringType,
            Type returnType,
            bool isSimpleType)
        {
            // check if there are [ResourceKey] attributes
            var keyAttributes = mi.GetCustomAttributes<ResourceKeyAttribute>().ToList();
            if(keyAttributes.Any())
                yield break;

            // check if there are [UseResource] attributes
            var useAttribute = mi.GetCustomAttribute<UseResourceAttribute>();
            if(useAttribute != null)
                yield break;

            var isResourceHidden = isHidden || mi.GetCustomAttribute<HiddenAttribute>() != null;
            var translations = DiscoveredTranslation.FromSingle(translation);

            var additionalTranslationsAttributes = mi.GetCustomAttributes<TranslationForCultureAttribute>().ToArray();

            if(additionalTranslationsAttributes != null && additionalTranslationsAttributes.Any())
                translations.AddRange(additionalTranslationsAttributes.Select(a => new DiscoveredTranslation(a.Translation, a.Culture)));

            var oldResourceKeys = OldResourceKeyBuilder.GenerateOldResourceKey(target, mi.Name, mi, resourceKeyPrefix, typeOldName, typeOldNamespace);

            yield return new DiscoveredResource(mi,
                                                resourceKey,
                                                translations,
                                                mi.Name,
                                                declaringType,
                                                returnType,
                                                isSimpleType,
                                                isResourceHidden)
                         {
                             TypeName = target.Name,
                             TypeNamespace = target.Namespace,
                             TypeOldName = oldResourceKeys.Item2,
                             TypeOldNamespace = typeOldNamespace,
                             OldResourceKey = oldResourceKeys.Item1
                         };
        }
    }
}
