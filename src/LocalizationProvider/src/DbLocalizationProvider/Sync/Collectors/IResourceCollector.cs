﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace DbLocalizationProvider.Sync.Collectors
{
    public interface IResourceCollector
    {
        IEnumerable<DiscoveredResource> GetDiscoveredResources(
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
            bool isSimpleType);
    }
}
