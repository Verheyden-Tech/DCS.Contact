using DCS.CoreLib;
using System.Collections.ObjectModel;

namespace DCS.Contact
{
    /// <summary>
    /// Repository for email data management on the table.
    /// </summary>
    public interface IEmailAdressRepository : IRepositoryBase<Guid, Email>
    {
        /// <summary>
        /// Get all emails by contact guid.
        /// </summary>
        /// <param name="contactGuid">Selected contact unique identifier.</param>
        /// <returns>List of all contact related email adresses.</returns>
        ObservableCollection<Email> GetAllByContact(Guid contactGuid);

        /// <summary>
        /// Get all emails by user guid.
        /// </summary>
        /// <param name="userGuid">Selected user unique identifier.</param>
        /// <returns>List of all user related email addresses.</returns>
        ObservableCollection<Email> GetAllByUser(Guid userGuid);
    }
}
