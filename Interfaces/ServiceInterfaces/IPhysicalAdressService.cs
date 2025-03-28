using DCS.Contact;
using DCS.DefaultTemplates;
using DCSBase.DataDB.Interfaces;

namespace DCSBase.Services.Interfaces
{
    /// <summary>
    /// DCS PhysicalAdressService to manipulate adress data.
    /// </summary>
    public interface IPhysicalAdressService : IServiceBase<Adress, IPhysicalAdressManagementRepository>
    {
        /// <summary>
        /// Creates a new adress instance.
        /// </summary>
        /// <param name="ownerContact">Contact to assign to.</param>
        /// <param name="ownerCompany">Company to assign to.</param>
        /// <returns>New adress instance.</returns>
        Adress CreateNewAdress(Contact ownerContact, string streetName, string houseNumber, string adressAddon, string city, string postalCode, string country, bool isActive = true, Company? ownerCompany = null);

        /// <summary>
        /// Gets all contact assigned adresses.
        /// </summary>
        /// <param name="contact">Selected contact.</param>
        /// <returns>Collection of all adresses assigned to given contact.</returns>
        DefaultCollection<Adress> GetAllByContact(Contact contact);
    }
}
