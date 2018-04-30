using System.Collections.Generic;
using DbLocalizationProvider;

namespace FluiTec.AppFx.Localization.Exporter
{
    /// <summary>Interface for export source reader.</summary>
    public interface IExportSourceReader
    {
        /// <summary>Enumerates read all in this collection.</summary>
        /// <returns>An enumerator that allows foreach to be used to process read all in this collection.</returns>
        IEnumerable<LocalizationResource> ReadAll();
    }
}