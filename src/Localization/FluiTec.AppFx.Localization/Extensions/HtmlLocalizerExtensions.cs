﻿using System;
using System.Globalization;
using System.Linq.Expressions;
using DbLocalizationProvider.Internal;
using Microsoft.AspNetCore.Mvc.Localization;

namespace FluiTec.AppFx.Localization
{
    /// <summary>A HTML localizer extensions.</summary>
    public static class HtmlLocalizerExtensions
    {
        /// <summary>An IHtmlLocalizer extension method that gets a string.</summary>
        /// <param name="target">           The target to act on. </param>
        /// <param name="model">            The model. </param>
        /// <param name="formatArguments">
        ///     A variable-length parameters list containing format
        ///     arguments.
        /// </param>
        /// <returns>The string.</returns>
        public static LocalizedHtmlString GetString(this IHtmlLocalizer target, Expression<Func<object>> model,
            params object[] formatArguments)
        {
            return target[ExpressionHelper.GetFullMemberName(model), formatArguments];
        }

        /// <summary>An IHtmlLocalizer extension method that gets string by culture.</summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are
        ///     null.
        /// </exception>
        /// <param name="target">           The target to act on. </param>
        /// <param name="model">            The model. </param>
        /// <param name="language">         The language. </param>
        /// <param name="formatArguments">
        ///     A variable-length parameters list containing format
        ///     arguments.
        /// </param>
        /// <returns>The string by culture.</returns>
        public static LocalizedHtmlString GetStringByCulture(this IHtmlLocalizer target, Expression<Func<object>> model,
            CultureInfo language, params object[] formatArguments)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (language == null)
                throw new ArgumentNullException(nameof(language));

            return target.WithCulture(language)[ExpressionHelper.GetFullMemberName(model), formatArguments];
        }

        /// <summary>An IHtmlLocalizer&lt;T&gt; extension method that gets a string.</summary>
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="target">           The target to act on. </param>
        /// <param name="model">            The model. </param>
        /// <param name="formatArguments">
        ///     A variable-length parameters list containing format
        ///     arguments.
        /// </param>
        /// <returns>The string.</returns>
        public static LocalizedHtmlString GetString<T>(this IHtmlLocalizer<T> target, Expression<Func<T, object>> model,
            params object[] formatArguments)
        {
            return target[ExpressionHelper.GetFullMemberName(model), formatArguments];
        }

        /// <summary>An IHtmlLocalizer&lt;T&gt; extension method that gets string by culture.</summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are
        ///     null.
        /// </exception>
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="target">           The target to act on. </param>
        /// <param name="model">            The model. </param>
        /// <param name="language">         The language. </param>
        /// <param name="formatArguments">
        ///     A variable-length parameters list containing format
        ///     arguments.
        /// </param>
        /// <returns>The string by culture.</returns>
        public static LocalizedHtmlString GetStringByCulture<T>(
            this IHtmlLocalizer<T> target,
            Expression<Func<T, object>> model,
            CultureInfo language,
            params object[] formatArguments)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (language == null)
                throw new ArgumentNullException(nameof(language));

            return target.WithCulture(language)[ExpressionHelper.GetFullMemberName(model), formatArguments];
        }
    }
}