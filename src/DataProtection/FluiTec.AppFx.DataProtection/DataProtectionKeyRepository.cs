using FluiTec.AppFx.DataProtection.Entities;
using Microsoft.AspNetCore.DataProtection.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FluiTec.AppFx.DataProtection
{
    /// <summary>   A data protection key repository. </summary>
    public class DataProtectionKeyRepository : IXmlRepository
    {
        /// <summary>   The data service. </summary>
        private readonly IDataProtectionDataService _dataService;

        /// <summary>   Constructor. </summary>
        /// <param name="dataService">  The data service. </param>
        public DataProtectionKeyRepository(IDataProtectionDataService dataService)
        {
            _dataService = dataService;
        }

        /// <summary>   Gets all top-level XML elements in the repository. </summary>
        /// <remarks>   All top-level elements in the repository. </remarks>
        /// <returns>   all elements. </returns>
        public IReadOnlyCollection<XElement> GetAllElements()
        {
            using (var uow = _dataService.StartUnitOfWork())
            {
                return uow.DataProtectionKeyRepository.GetAll().Select(k => XElement.Parse(k.XmlData)).ToList().AsReadOnly();
            }
        }

        /// <summary>   Adds a top-level XML element to the repository. </summary>
        /// <remarks>
        ///     The 'friendlyName' parameter must be unique if specified. For instance, it could be the
        ///     id of the key being stored.
        /// </remarks>
        /// <param name="element">      The element to add. </param>
        /// <param name="friendlyName"> An optional name to be associated with the XML element. For
        ///                             instance, if this repository stores XML files on disk, the
        ///                             friendly name may be used as part of the file name. Repository
        ///                             implementations are not required to observe this parameter even
        ///                             if it has been provided by the caller. </param>
        public void StoreElement(XElement element, string friendlyName)
        {
            using (var uow = _dataService.StartUnitOfWork())
            {
                var existing = uow.DataProtectionKeyRepository.GetAll().SingleOrDefault(k => k.FriendlyName == friendlyName);
                if (existing != null)
                {
                    // just update
                    existing.XmlData = element.ToString();
                    uow.DataProtectionKeyRepository.Update(existing);
                }
                else
                {
                    // save it
                    var entity = new DataProtectionKeyEntity()
                    {
                        FriendlyName = friendlyName,
                        XmlData = element.ToString()
                    };
                    uow.DataProtectionKeyRepository.Add(entity);
                }
                uow.Commit();
            }
        }
    }
}
