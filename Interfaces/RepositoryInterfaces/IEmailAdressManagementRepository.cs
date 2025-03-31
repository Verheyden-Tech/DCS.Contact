using DCS.DefaultTemplates;
using System.Collections.ObjectModel;

namespace DCS.Contact
{
    /// <summary>
    /// Repository for email data management on the table.
    /// </summary>
    public interface IEmailAdressManagementRepository : IRepositoryBase<Guid, Email>
    {
        /// <summary>
        /// Delete email by guid.
        /// </summary>
        /// <param name="contactGuid"></param>
        /// <returns></returns>
        ObservableCollection<Email> GetAllByContact(Guid contactGuid);

        /// <summary>
        /// Get all emails by user guid.
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        ObservableCollection<Email> GetAllByUser(Guid userGuid);
    }
}
