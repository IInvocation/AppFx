using System;

namespace FluiTec.AppFx.Localization.Exporter
{
    /// <summary>An enum validator.</summary>
    public static class EnumHelper
    {
        /// <summary>Query if 'enumType' is enum.</summary>
        /// <param name="value">    The value. </param>
        /// <returns>True if enum, false if not.</returns>
        public static bool IsEnum<TEnum>(string value) where TEnum : struct
        {
            return Enum.TryParse(typeof(TEnum), value, true, out object _);
        }

        public static TEnum ParseEnum<TEnum>(string value) where TEnum : struct
        {
            return Enum.Parse<TEnum>(value, true);
        }
    }
}