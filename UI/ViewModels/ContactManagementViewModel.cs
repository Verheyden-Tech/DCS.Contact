using DCS.DefaultTemplates;
using System.Collections.ObjectModel;

namespace DCS.Contact.UI
{
    /// <summary>
    /// ViewModel for contact management.
    /// </summary>
    public class ContactManagementViewModel : ViewModelBase<Guid, Contact>
    {
        private IContactService contactService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IContactService>();
        private ObservableCollection<Adress> adresses;
        private ObservableCollection<Email> emails;
        private ObservableCollection<Phone> phoneNumbers;
        private ObservableCollection<Company> companies;

        private ObservableCollection<Contact> selectedContacts;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactManagementViewModel"/> class.
        /// </summary>
        public ContactManagementViewModel()
        {
            Collection = new ObservableCollection<Contact>();
            Collection = contactService.GetAll();

            Adresses = new ObservableCollection<Adress>();
            Emails = new ObservableCollection<Email>();
            PhoneNumbers = new ObservableCollection<Phone>();
            Companies = new ObservableCollection<Company>();

            SelectedContacts = new ObservableCollection<Contact>();
        }

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactManagementViewModel"/> class.
        /// </summary>
        /// <param name="contact"></param>
        public ContactManagementViewModel(Contact contact) : this()
        {
            this.Model = contact;
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
        public ObservableCollection<Adress> Adresses
        {
            get => adresses;
            set => adresses = value;
        }

        /// <summary>
        /// Gets or sets the contact's emails.
        /// </summary>
        public ObservableCollection<Email> Emails
        {
            get => emails;
            set => emails = value;
        }

        /// <summary>
        /// Gets or sets the contact's phone numbers.
        /// </summary>
        public ObservableCollection<Phone> PhoneNumbers
        {
            get => phoneNumbers;
            set => phoneNumbers = value;
        }

        /// <summary>
        /// Gets or sets the contact's companies.
        /// </summary>
        public ObservableCollection<Company> Companies
        {
            get => companies;
            set => companies = value;
        }

        /// <summary>
        /// Gets or sets the selected contacts.
        /// </summary>
        public ObservableCollection<Contact> SelectedContacts
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
