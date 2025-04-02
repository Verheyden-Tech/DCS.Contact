using DCS.User;
using DCS.DefaultTemplates;

namespace DCS.Contact.UI
{
    /// <summary>
    /// ViewModel for the contact editor.
    /// </summary>
    public class ContactEditorViewModel : ViewModelBase<Guid, Contact>
    {
        private readonly IContactService contactService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IContactService>();

        private DefaultCollection<Adress> adresses;
        private DefaultCollection<Email> emails;
        private DefaultCollection<Phone> phoneNumbers;
        private DefaultCollection<Company> companies;

        private PhysicalAddressViewModel physicalAddressViewModel;
        private EmailAdressViewModel emailAdressViewModel;
        private PhoneNumberViewModel phoneNumberViewModel;
        private Adress selectedAdress;
        private Email selectedEmailAdress;
        private Phone selectedPhoneNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactEditorViewModel"/> class.
        /// </summary>
        public ContactEditorViewModel()
        {
            Collection = new DefaultCollection<Contact>();
            ContactAdresses = new DefaultCollection<Adress>();
            ContactEmails = new DefaultCollection<Email>();
            ContactPhoneNumbers = new DefaultCollection<Phone>();
            ContactCompanies = new DefaultCollection<Company>();

            if (Model == null)
                Model = new Contact();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactEditorViewModel"/> class.
        /// </summary>
        /// <param name="contact"></param>
        public ContactEditorViewModel(Contact contact) : this()
        {
            this.Model = contact;

            foreach (var loadedAdress in physicalAddressViewModel.GetContactAdresses(contact))
            {
                if (!ContactAdresses.Contains(loadedAdress))
                {
                    ContactAdresses.Add(loadedAdress);
                }
            }
            foreach (var loadedEmail in emailAdressViewModel.GetContactEmailAdresses(contact))
            {
                if (!ContactEmails.Contains(loadedEmail))
                {
                    ContactEmails.Add(loadedEmail);
                }
            }
            foreach (var loadedPhoneNumber in phoneNumberViewModel.GetContactPhoneNumbers(contact))
            {
                if (!ContactPhoneNumbers.Contains(loadedPhoneNumber))
                {
                    ContactPhoneNumbers.Add(loadedPhoneNumber);
                }
            }
        }

        /// <summary>
        /// Adds a new adress to the contact.
        /// </summary>
        /// <param name="newAdress"></param>
        /// <returns></returns>
        public bool AddNewAdress(Adress newAdress)
        {
            if(newAdress == null)
                return false;

            if(!this.ContactAdresses.Contains(newAdress))
            {
                ContactAdresses.Add(newAdress);
                if(physicalAddressViewModel.Add(newAdress))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Adds a new phone number to the contact.
        /// </summary>
        /// <param name="newPhone"></param>
        /// <returns></returns>
        public bool AddNewPhoneNumber(Phone newPhone)
        {
            if(newPhone == null)
                return false;

            if(!this.ContactPhoneNumbers.Contains(newPhone))
            {
                ContactPhoneNumbers.Add(newPhone);
                if(phoneNumberViewModel.Add(newPhone))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Adds a new email adress to the contact.
        /// </summary>
        /// <param name="newEmail"></param>
        /// <returns></returns>
        public bool AddNewEmailAdress(Email newEmail)
        {
            if(newEmail == null)
                return false;

            if(!this.ContactEmails.Contains(newEmail))
            {
                ContactEmails.Add(newEmail);
                if(emailAdressViewModel.Add(newEmail))
                    return true;
            }
            return false;
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

        /// <summary>
        /// Gets or sets the selected adresses.
        /// </summary>
        public Adress SelectedAdress
        {
            get => selectedAdress;
            set
            {
                if(!Equals(value, selectedAdress))
                {
                    selectedAdress = value;
                    OnPropertyChanged(nameof(SelectedAdress));
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected email adress.
        /// </summary>
        public Email SelectedEmailAdress
        {
            get => selectedEmailAdress;
            set
            {
                if(!Equals(value, selectedEmailAdress))
                {
                    selectedEmailAdress = value;
                    OnPropertyChanged(nameof(SelectedEmailAdress));
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected phone number.
        /// </summary>
        public Phone SelectedPhoneNumber
        {
            get => selectedPhoneNumber;
            set
            {
                if(!Equals(value, selectedPhoneNumber))
                {
                    selectedPhoneNumber = value;
                    OnPropertyChanged(nameof(SelectedPhoneNumber));
                }
            }
        }
        #endregion

        #region Contact Data Collections
        /// <summary>
        /// Contains all contact related adresses.
        /// </summary>
        public DefaultCollection<Adress> ContactAdresses
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
        public DefaultCollection<Phone> ContactPhoneNumbers
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
        public DefaultCollection<Email> ContactEmails
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
        public DefaultCollection<Company> ContactCompanies
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
