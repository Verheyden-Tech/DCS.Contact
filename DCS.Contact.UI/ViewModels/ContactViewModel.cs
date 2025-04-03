using DCS.DefaultTemplates;
using System.Collections.ObjectModel;

namespace DCS.Contact.UI
{
    /// <summary>
    /// ViewModel for the contact editor.
    /// </summary>
    public class ContactViewModel : ViewModelBase<Guid, Contact>
    {
        private IContactService contactService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IContactService>();

        private ObservableCollection<Adress> adresses;
        private ObservableCollection<Email> emails;
        private ObservableCollection<Phone> phoneNumbers;
        private ObservableCollection<Company> companies;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactViewModel"/> class.
        /// </summary>
        public ContactViewModel(Contact contact) : base(contact)
        {
            Collection = new ObservableCollection<Contact>();
            ContactAdresses = new ObservableCollection<Adress>();
            ContactEmails = new ObservableCollection<Email>();
            ContactPhoneNumbers = new ObservableCollection<Phone>();
            ContactCompanies = new ObservableCollection<Company>();
        }

        #region Public Props
        /// <summary>
        /// Gets or sets the unique identifier of the contact.
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
                OnPropertyChanged(nameof(Guid));
            }
        }

        /// <summary>
        /// Gets or sets the first name of the contact.
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
                OnPropertyChanged(nameof(FirstName));
            }
        }

        /// <summary>
        /// Gets or sets the last name of the contact.
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
                OnPropertyChanged(nameof(LastName));
            }
        }

        /// <summary>
        /// Indicates whether the contact is active.
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
                OnPropertyChanged(nameof(IsActive));
            }
        }
        #endregion

        #region Contact Data Collections
        /// <summary>
        /// Contains all contact related adresses.
        /// </summary>
        public ObservableCollection<Adress> ContactAdresses
        {
            get
            {
                return adresses;
            }
            set
            {
                adresses = value;
                OnPropertyChanged(nameof(ContactAdresses));
            }
        }

        /// <summary>
        /// Contains all contact related phone numbers.
        /// </summary>
        public ObservableCollection<Phone> ContactPhoneNumbers
        {
            get
            {
                return phoneNumbers;
            }
            set
            {
                phoneNumbers = value;
                OnPropertyChanged(nameof(ContactPhoneNumbers));
            }
        }

        /// <summary>
        /// Contains all contact related email adresses.
        /// </summary>
        public ObservableCollection<Email> ContactEmails
        {
            get
            {
                return emails;
            }
            set
            {
                emails = value;
                OnPropertyChanged(nameof(ContactEmails));
            }
        }

        /// <summary>
        /// Contains all contact related companies.
        /// </summary>
        public ObservableCollection<Company> ContactCompanies
        {
            get
            {
                return companies;
            }
            set
            {
                companies = value;
                OnPropertyChanged(nameof(ContactCompanies));
            }
        }
        #endregion
    }
}
