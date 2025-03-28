using DCS.DefaultTemplates;

namespace DCS.Contact
{
    /// <summary>
    /// Phone Management Repository to handle phone data on the table.
    /// </summary>
    public interface IPhoneManagementRepository : IRepositoryBase<Phone>
    {
        /// <summary>
        /// Get phone data by contact guid.
        /// </summary>
        /// <param name="contactGuid"></param>
        /// <returns></returns>
        DefaultCollection<Phone> GetAllByContact(Guid contactGuid);
    }
}
