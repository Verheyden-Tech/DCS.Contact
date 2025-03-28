using DCS.Contact;
using DCS.DefaultTemplates;
using DCSBase.DataDB.Interfaces;

namespace DCSBase.Services.Interfaces
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

        DefaultCollection<Email> GetAllByContact(Guid contactGuid);

        DefaultCollection<Email> GetAllByUser(Guid userGuid);
    }
}
