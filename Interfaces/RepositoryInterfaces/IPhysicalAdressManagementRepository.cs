using DCS.DefaultTemplates;
using System.Collections.ObjectModel;

namespace DCS.Contact
{
    /// <summary>
    /// Physical Adress Management Repository to handle physical adress data on the table.
    /// </summary>
    public interface IPhysicalAdressManagementRepository : IRepositoryBase<Guid, Adress>
    {
        /// <summary>
        /// Get all physical adress data by contact guid.
        /// </summary>
        /// <param name="contactGuid"></param>
        /// <returns></returns>
        ObservableCollection<Adress> GetAllByContact(Guid contactGuid);
    }
}
