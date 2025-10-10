using DCS.CoreLib.BaseClass;
using DCS.User.Service;
using System.Collections.ObjectModel;

namespace DCS.Contact.Service
{
    /// <summary>
    /// DCS ContactService to manipulate contact data.
    /// </summary>
    public class ContactService : ServiceBase<Guid, Contact, IContactRepository>, IContactService
    {
        /// <summary>
        /// Repository for contact management.
        /// </summary>
        private IContactRepository repository;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ContactService(IContactRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        /// <inheritdoc/>
        public ObservableCollection<Contact> GetByName(string contactName)
        {
            if (contactName == null)
                throw new ArgumentNullException(nameof(contactName));

            var foundContacts = new ObservableCollection<Contact>();

            //Get all contacts with matching firstname.
            foundContacts = repository.GetByFirstName(contactName);
            if(foundContacts == null || foundContacts.Count == 0)
            {
                //If no contact could be fund by firstname, checks on the lastname.
                foundContacts = repository.GetByLastName(contactName);
                if(foundContacts != null && foundContacts.Count != 0)
                {
                    return foundContacts;
                }

                //If still no matching contact could be fund returns an empty list.
                return new ObservableCollection<Contact>();
            }
            else
            {
                return foundContacts;
            }
        }

        /// <inheritdoc/>
        public Contact CreateNewContact(string firstName, string lastName)
        {
            var newContact = new Contact
            {
                Guid = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                IsActive = true,
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now
            };

            return newContact;
        }

        /// <inheritdoc/>
        public ObservableCollection<Contact> GetByFirstName(string contactFirstName)
        {
            return repository.GetByFirstName(contactFirstName);
        }

        /// <inheritdoc/>
        public ObservableCollection<Contact> GetByLastName(string contactLastName)
        {
            return repository.GetByLastName(contactLastName);
        }
    }
}
