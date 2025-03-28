using DCS.DefaultTemplates;

namespace DCS.Contact
{
    /// <summary>
    /// DCS ContactManagementRepository to manipulate contact data on the table.
    /// </summary>
    public interface IContactManagementRepository : IRepositoryBase<Contact>
    {
        /// <summary>
        /// Gets a collection of contacts matching on given firstname.
        /// </summary>
        /// <param name="contactFirstName">Contacts firstname.</param>
        DefaultCollection<Contact> GetByFirstName(string contactFirstName);

        /// <summary>
        /// Gets a collection of contacts matching on given lastname.
        /// </summary>
        /// <param name="contactLastName">Contacts lastname.</param>
        DefaultCollection<Contact> GetByLastName(string contactLastName);
    }
}
