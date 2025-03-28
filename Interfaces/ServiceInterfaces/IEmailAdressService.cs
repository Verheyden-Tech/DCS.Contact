using DCS.DefaultTemplates;

namespace DCS.Contact
{
    /// <summary>
    /// EmailAdressService to manipulate emailadress data.
    /// </summary>
    public interface IEmailAdressService : IServiceBase<Email, IEmailAdressManagementRepository>
    {
        /// <summary>
        /// Creates new email instance.
        /// </summary>
        /// <param name="mailAdress">Contact email adress.</param>
        /// <param name="contactGuid">Contact guid.</param>
        /// <param name="isActive">Email is active flag.</param>
        /// <param name="type">Email type.</param>
        /// <returns>New instance of <see cref="Email"/>.</returns>
        Email CreateEmailAdress(string mailAdress, Guid contactGuid, bool isActive = true, string type = "");

        /// <summary>
        /// Get all emails by contact guid.
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
