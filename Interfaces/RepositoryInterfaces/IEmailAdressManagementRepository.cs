using DCS.DefaultTemplates;

namespace DCS.Contact
{
    /// <summary>
    /// Repository for email data management on the table.
    /// </summary>
    public interface IEmailAdressManagementRepository : IRepositoryBase<Email>
    {
        /// <summary>
        /// Delete email by guid.
        /// </summary>
        /// <param name="contactGuid"></param>
        /// <returns></returns>
        DefaultCollection<Email> GetAllByContact(Guid contactGuid);

        /// <summary>
        /// Get all emails by user guid.
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        DefaultCollection<Email> GetAllByUser(Guid userGuid);
    }
}
