using System;
using System.Collections.Generic;
using System.Reflection;

namespace FluiTec.AppFx.Reflection
{
    /// <summary>   An assembly scanner. </summary>
    public static class AssemblyScanner
    {
        /// <summary>   Finds all attributed types in this collection. </summary>
        /// <param name="attributeType">    Type of the attribute. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process all attributed types in this
        ///     collection.
        /// </returns>
        public static IEnumerable<Type> FindAllAttributedTypes(Type attributeType)
        {
            if (attributeType == null) throw new ArgumentNullException(nameof(attributeType));

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
            foreach (var type in GetAttributedTypes(assembly, attributeType))
                yield return type;
        }

        /// <summary>   Gets the attributed types in this collection. </summary>
        /// <param name="assembly">         The assembly. </param>
        /// <param name="attributeType">    Type of the attribute. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the attributed types in this
        ///     collection.
        /// </returns>
        public static IEnumerable<Type> GetAttributedTypes(Assembly assembly, Type attributeType)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            if (attributeType == null) throw new ArgumentNullException(nameof(attributeType));

            foreach (var type in assembly.GetTypes())
                if (type.GetCustomAttributes(attributeType, true).Length > 0)
                    yield return type;
        }
    }
}