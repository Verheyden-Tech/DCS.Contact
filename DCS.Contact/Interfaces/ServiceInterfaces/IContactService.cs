using DCS.DefaultTemplates;
using System.Collections.ObjectModel;

namespace DCS.Contact
{
    /// <summary>
    /// Represents the contact service to handle and manipulate contact data on the table.
    /// </summary>
    public interface IContactService : IServiceBase<Guid, Contact, IContactRepository>
    {
        /// <summary>
        /// Gets a collection of contacts matching on given name.
        /// </summary>
        /// <param name="contactName">Given contact name to search for.</param>
        ObservableCollection<Contact> GetByName(string contactName);

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
