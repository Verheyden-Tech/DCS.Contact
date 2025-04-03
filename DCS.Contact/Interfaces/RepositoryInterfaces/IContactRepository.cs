using DCS.CoreLib;
using System.Collections.ObjectModel;

namespace DCS.Contact
{
    /// <summary>
    /// DCS ContactManagementRepository to manipulate contact data on the table.
    /// </summary>
    public interface IContactRepository : IRepositoryBase<Guid, Contact>
    {
        /// <summary>
        /// Gets a collection of contacts matching on given firstname.
        /// </summary>
        /// <param name="contactFirstName">Contacts firstname.</param>
        ObservableCollection<Contact> GetByFirstName(string contactFirstName);

        /// <summary>
        /// Gets a collection of contacts matching on given lastname.
        /// </summary>
        /// <param name="contactLastName">Contacts lastname.</param>
        ObservableCollection<Contact> GetByLastName(string contactLastName);
    }
}
