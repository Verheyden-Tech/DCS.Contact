using DCS.DefaultTemplates;
using DCS.User;

namespace DCS.Contact.UI
{
    /// <summary>
    /// Phone number view model.
    /// </summary>
    public class PhoneNumberViewModel : ViewModelBase<Phone>
    {
        private IPhoneService phoneService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhoneService>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberViewModel"/> class.
        /// </summary>
        public PhoneNumberViewModel()
        {
            Collection = new DefaultCollection<Phone>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberViewModel"/> class.
        /// </summary>
        /// <param name="phone"></param>
        public PhoneNumberViewModel(Phone phone) : this()
        {
            this.Model = phone;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberViewModel"/> class.
        /// </summary>
        /// <param name="contact"></param>
        public PhoneNumberViewModel(Contact contact) : this()
        {
            this.SelectedContact = contact;

            if (Model == null)
            {
                Model = new Phone() { ContactGuid = contact.Guid, UserGuid = CurrentUserService.Instance.CurrentUser.Guid };
            }

            this.Collection = phoneService.GetAll();

            if (Model != null)
            {
                if (Collection != null && Collection.Count > 0)
                {
                    Model = Collection.First();
                }
                else
                {
                    Model = new Phone();
                }
            }
        }

        /// <summary>
        /// Get all phone numbers assigned to a contact.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public DefaultCollection<Phone> GetContactPhoneNumbers(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException("contact");

            return phoneService.GetAllByContact(contact.Guid);
        }

        /// <summary>
        /// Create a new phone number on the table.
        /// </summary>
        /// <param name="newPhone"></param>
        /// <returns></returns>
        public bool New(Phone newPhone)
        {
            return phoneService.New(newPhone);
        }

        /// <summary>
        /// Add a new phone number to the contact.
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool AddNewPhoneNumber(Contact contact, Phone phone)
        {
            if(SelectedContact == contact && phone != null)
            {
                this.Collection.Add(phone);
                if(SavePhoneNumbers(PhoneNumbers))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Save all phone numbers in the collection.
        /// </summary>
        /// <param name="phoneNumbers"></param>
        /// <returns></returns>
        public bool SavePhoneNumbers(DefaultCollection<Phone> phoneNumbers)
        {
            if (phoneNumbers != null)
            {
                foreach (var phone in phoneNumbers)
                {
                    phoneService.Update(phone);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets or sets the phone number guid.
        /// </summary>
        public Guid Guid
        {
            get => Model.Guid;
            set => Model.Guid = value;
        }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber
        {
            get => Model.PhoneNumber;
            set => Model.PhoneNumber = value;
        }

        /// <summary>
        /// Gets or sets the phone number type.
        /// </summary>
        public string Type
        {
            get => Model.Type;
            set => Model.Type = value;
        }

        /// <summary>
        /// Gets or sets the phone number collection.
        /// </summary>
        public DefaultCollection<Phone> PhoneNumbers
        {
            get => this.Collection;
            set => this.Collection = value;
        }

        /// <summary>
        /// Gets or sets the selected contact.
        /// </summary>
        public Contact SelectedContact { get; set; }
    }
}
