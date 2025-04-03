using DCS.CoreLib;
using System.Collections.ObjectModel;

namespace DCS.Contact
{
    /// <summary>
    /// Phone Management Repository to handle phone data on the table.
    /// </summary>
    public interface IPhoneRepository : IRepositoryBase<Guid, Phone>
    {
        /// <summary>
        /// Get phone data by contact guid.
        /// </summary>
        /// <param name="contactGuid"></param>
        /// <returns></returns>
        ObservableCollection<Phone> GetAllByContact(Guid contactGuid);
    }
}
