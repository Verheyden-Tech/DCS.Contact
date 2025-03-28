using DCS.DefaultTemplates;
using DCS.User;

namespace DCS.Contact.Services
{
    /// <summary>
    /// DCS ContactService to manipulate contact data.
    /// </summary>
    public class ContactService : IServiceBase<Contact, IContactManagementRepository>, IContactService
    {
        private Contact model;

        /// <summary>
        /// Repository for contact management.
        /// </summary>
        public IContactManagementRepository Repository => CommonServiceLocator.ServiceLocator.Current.GetInstance<IContactManagementRepository>();

        /// <summary>
        /// Model of the contact.
        /// </summary>
        public Contact Model => model;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ContactService()
        {

        }

        /// <summary>
        /// Constructor with contact model.
        /// </summary>
        /// <param name="contact"></param>
        public ContactService(Contact contact) : this()
        {
            this.model = contact;
        }

        /// <summary>
        /// Deletes a contact by given guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool Delete(Guid guid)
        {
            return Repository.Delete(guid);
        }

        /// <summary>
        /// Gets a contact by given guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public Contact Get(Guid guid)
        {
            return Repository.Get(guid);
        }

        /// <inheritdoc/>
        public DefaultCollection<Contact> GetByName(string contactName)
        {
            if (contactName == null)
                throw new ArgumentNullException(nameof(contactName));

            var foundContacts = new DefaultCollection<Contact>();

            //Get all contacts with matching firstname.
            foundContacts = Repository.GetByFirstName(contactName);
            if(foundContacts == null || foundContacts.Count == 0)
            {
                //If no contact could be fund by firstname, checks on the lastname.
                foundContacts = Repository.GetByLastName(contactName);
                if(foundContacts != null && foundContacts.Count != 0)
                {
                    return foundContacts;
                }

                //If still no matching contact could be fund returns an empty list.
                return new DefaultCollection<Contact>();
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
            return Repository.GetAll();
        }

        /// <summary>
        /// Creates a new contact entity.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool New(Contact obj)
        {
            return Repository.New(obj);
        }

        /// <summary>
        /// Updates a contact entity.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(Contact obj)
        {
            return Repository.Update(obj);
        }
    }
}
