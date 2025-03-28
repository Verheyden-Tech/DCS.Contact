using DCS.DefaultTemplates;

namespace DCS.Contact.UI
{
    /// <summary>
    /// ViewModel for contact management.
    /// </summary>
    public class ContactManagementViewModel : ViewModelBase<Contact>
    {
        private IContactService contactService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IContactService>();
        private DefaultCollection<Adress> adresses;
        private DefaultCollection<Email> emails;
        private DefaultCollection<Phone> phoneNumbers;
        private DefaultCollection<Company> companies;

        private PhysicalAddressViewModel physicalAddressViewModel;
        private EmailAdressViewModel emailAdressViewModel;
        private PhoneNumberViewModel phoneNumberViewModel;
        private DefaultCollection<Contact> selectedContacts;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactManagementViewModel"/> class.
        /// </summary>
        public ContactManagementViewModel()
        {
            Collection = new DefaultCollection<Contact>();
            Collection = contactService.GetAll();

            Adresses = new DefaultCollection<Adress>();
            Emails = new DefaultCollection<Email>();
            PhoneNumbers = new DefaultCollection<Phone>();
            Companies = new DefaultCollection<Company>();

            SelectedContacts = new DefaultCollection<Contact>();
        }

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactManagementViewModel"/> class.
        /// </summary>
        /// <param name="contact"></param>
        public ContactManagementViewModel(Contact contact) : this()
        {
            this.Model = contact;

            physicalAddressViewModel = new PhysicalAddressViewModel(contact);
            emailAdressViewModel = new EmailAdressViewModel(contact);
            phoneNumberViewModel = new PhoneNumberViewModel(contact);
        }
        #endregion

        #region Public Props
        /// <summary>
        /// Gets or sets the contact's guid.
        /// </summary>
        public Guid Guid
        {
            get
            {
                return Model.Guid;
            }
            set
            {
                Model.Guid = value;
            }
        }

        /// <summary>
        /// Gets or sets the contact's first name.
        /// </summary>
        public string FirstName
        {
            get
            {
                return Model.FirstName;
            }
            set
            {
                Model.FirstName = value;
            }
        }

        /// <summary>
        /// Gets or sets the contact's last name.
        /// </summary>
        public string LastName
        {
            get
            {
                return Model.LastName;
            }
            set
            {
                Model.LastName = value;
            }
        }

        /// <summary>
        /// Indicates if the contact is active.
        /// </summary>
        public bool IsActive
        {
            get
            {
                return Model.IsActive;
            }
            set
            {
                Model.IsActive = value;
            }
        }
        #endregion

        #region Public Lists
        /// <summary>
        /// Gets or sets the contact's adresses.
        /// </summary>
        public DefaultCollection<Adress> Adresses
        {
            get => adresses;
            set => adresses = value;
        }

        /// <summary>
        /// Gets or sets the contact's emails.
        /// </summary>
        public DefaultCollection<Email> Emails
        {
            get => emails;
            set => emails = value;
        }

        /// <summary>
        /// Gets or sets the contact's phone numbers.
        /// </summary>
        public DefaultCollection<Phone> PhoneNumbers
        {
            get => phoneNumbers;
            set => phoneNumbers = value;
        }

        /// <summary>
        /// Gets or sets the contact's companies.
        /// </summary>
        public DefaultCollection<Company> Companies
        {
            get => companies;
            set => companies = value;
        }

        /// <summary>
        /// Gets or sets the selected contacts.
        /// </summary>
        public DefaultCollection<Contact> SelectedContacts
        {
            get => selectedContacts;
            set
            {
                if(!Equals(value, selectedContacts))
                {
                    selectedContacts = value;
                    OnPropertyChanged(nameof(SelectedContacts));
                }
            }
        }
        #endregion
    }
}
