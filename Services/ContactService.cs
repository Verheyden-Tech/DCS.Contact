using DCS.DefaultTemplates;
using DCS.User;
using System.Collections.ObjectModel;

namespace DCS.Contact.Services
{
    /// <summary>
    /// DCS ContactService to manipulate contact data.
    /// </summary>
    public class ContactService : ServiceBase<Guid, Contact, IContactManagementRepository>, IContactService
    {
        /// <summary>
        /// Repository for contact management.
        /// </summary>
        private IContactManagementRepository repository;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ContactService(IContactManagementRepository repository) : base(repository)
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
        public Contact CreateNewContact(string firstName, string lastName, bool isActive = true)
        {
            var newContact = new Contact
            {
                Guid = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                IsActive = isActive,
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                UserGuid = CurrentUserService.Instance.CurrentUser.Guid
            };

            return newContact;
        }

        /// <summary>
        /// Gets all contacts.
        /// </summary>
        /// <returns></returns>
        public DefaultCollection<Contact> GetAll()
        {
            return repository.GetAll();
        }

        /// <summary>
        /// Creates a new contact entity.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool New(Contact obj)
        {
            return repository.New(obj);
        }

        /// <summary>
        /// Updates a contact entity.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(Contact obj)
        {
            return repository.Update(obj);
        }
    }
}
