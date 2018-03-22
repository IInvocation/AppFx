using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DbLocalizationProvider.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FluiTec.AppFx.Localization.MetadataProviders
{
    /// <summary>
    ///     Credits:
    ///     https://github.com/aspnet/Mvc/blob/dev/src/Microsoft.AspNetCore.Mvc.DataAnnotations/Internal/DataAnnotationsModelValidator.cs.
    /// </summary>
    public class LocalizedModelValidator : IModelValidator
    {
        /// <summary>   The attribute. </summary>
        private readonly ValidationAttribute _attribute;
        /// <summary>   The empty validation context instance. </summary>
        private static readonly object EmptyValidationContextInstance = new object();

        /// <summary>   Constructor. </summary>
        /// <param name="attribute">    The attribute. </param>
        public LocalizedModelValidator(ValidationAttribute attribute)
        {
            _attribute = attribute;
        }

        /// <summary>   Validates the model value. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="ArgumentException">        Thrown when one or more arguments have
        ///                                             unsupported or illegal values. </exception>
        /// <param name="validationContext">    The
        ///                                     <see cref="T:Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContext" />. </param>
        /// <returns>
        ///     A list of
        ///     <see cref="T:Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationResult" />
        ///     indicating the results of validating the model value.
        /// </returns>
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext validationContext)
        {
            if (validationContext == null)
                throw new ArgumentNullException(nameof(validationContext));

            if (validationContext.ModelMetadata == null)
                throw new ArgumentException($"{nameof(validationContext.ModelMetadata)} is null", nameof(validationContext));

            if (validationContext.MetadataProvider == null)
                throw new ArgumentException($"{nameof(validationContext.MetadataProvider)} in null", nameof(validationContext));

            var metadata = validationContext.ModelMetadata;
            var memberName = metadata.PropertyName;
            var container = validationContext.Container;

            var context = new ValidationContext(
                container ?? validationContext.Model ?? EmptyValidationContextInstance,
                validationContext.ActionContext?.HttpContext?.RequestServices,
                null)
            {
                DisplayName = metadata.GetDisplayName(),
                MemberName = memberName
            };

            var result = _attribute.GetValidationResult(validationContext.Model, context);
            if (result != ValidationResult.Success)
            {
                var resourceKey = DbLocalizationProvider.Internal.ResourceKeyBuilder.BuildResourceKey(metadata.ContainerType, metadata.PropertyName, _attribute);
                var translation = ModelMetadataLocalizationHelper.GetTranslation(resourceKey);
                var errorMessage = !string.IsNullOrEmpty(translation) ? translation : result?.ErrorMessage;

                var validationResults = new List<ModelValidationResult>();
                if (result?.MemberNames != null)
                    foreach (var resultMemberName in result.MemberNames)
                    {
                        // ModelValidationResult.MemberName is used by invoking validators (such as ModelValidator) to
                        // append construct the ModelKey for ModelStateDictionary. When validating at type level we
                        // want the returned MemberNames if specified (e.g. "person.Address.FirstName"). For property
                        // validation, the ModelKey can be constructed using the ModelMetadata and we should ignore
                        // MemberName (we don't want "person.Name.Name"). However the invoking validator does not have
                        // a way to distinguish between these two cases. Consequently we'll only set MemberName if this
                        // validation returns a MemberName that is different from the property being validated.
                        var newMemberName = string.Equals(resultMemberName, memberName, StringComparison.Ordinal)
                            ? null
                            : resultMemberName;
                        var validationResult = new ModelValidationResult(newMemberName, errorMessage);

                        validationResults.Add(validationResult);
                    }

                if (validationResults.Count == 0)
                    validationResults.Add(new ModelValidationResult(null, errorMessage));

                return validationResults;
            }

            return Enumerable.Empty<ModelValidationResult>();
        }
    }
}