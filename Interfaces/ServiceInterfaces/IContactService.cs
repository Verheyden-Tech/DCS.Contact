using DCS.DefaultTemplates;

namespace DCS.Contact
{
    /// <summary>
    /// DCS ContactService to manipulate contact data.
    /// </summary>
    public interface IContactService : IServiceBase<Contact, IContactManagementRepository>
    {
        /// <summary>
        /// Gets a collection of contacts matching on given name.
        /// </summary>
        /// <param name="contactName">Given contact name to search for.</param>
        DefaultCollection<Contact> GetByName(string contactName);

        /// <summary>
        /// Creates a new contact entity.
        /// </summary>
        /// <param name="firstName">Contact firstname.</param>
        /// <param name="lastName">Contact lastname.</param>
        /// <param name="isActive">Contact is active flag.</param>
        /// <returns>New contact entity.</returns>
        Contact CreateNewContact(string firstName, string lastName, bool isActive = true);
    }
}
