using DCS.CoreLib;
using System.Collections.ObjectModel;
using Telerik.Windows.Data;

namespace DCS.Contact
{
    /// <summary>
    /// Physical Adress Service to handle contact adress data on the table.
    /// </summary>
    public interface IPhysicalAdressService : IServiceBase<Guid, Adress, IPhysicalAdressRepository>
    {
        /// <summary>
        /// Creates a new address for the specified contact and company.
        /// </summary>
        /// <param name="ownerContact">The contact who owns the address.</param>
        /// <param name="streetName">The street name of the address.</param>
        /// <param name="houseNumber">The house number of the address.</param>
        /// <param name="adressAddon">Additional address information.</param>
        /// <param name="city">The city of the address.</param>
        /// <param name="postalCode">The postal code of the address.</param>
        /// <param name="country">The country of the address.</param>
        /// <param name="isActive">Indicates whether the address is active.</param>
        /// <param name="ownerCompany">The company that owns the address (optional).</param>
        /// <returns>The newly created address.</returns>
        Adress CreateNewAdress(Contact ownerContact, string streetName, string houseNumber, string adressAddon, string city, string postalCode, string country, bool isActive = true, Company? ownerCompany = null);

        /// <summary>
        /// Gets all contact assigned adresses.
        /// </summary>
        /// <param name="contact">Selected contact.</param>
        /// <returns>Collection of all adresses assigned to given contact.</returns>
        ObservableCollection<Adress> GetAllByContact(Contact contact);
    }
}
