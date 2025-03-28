using DCS.Contact;
using DCS.DefaultTemplates;
using DCS.User;
using DCSBase.Services.Interfaces;

namespace DCSBase.Contacts
{
    public class ContactEditorViewModel : ViewModelBase<Contact>
    {
        private IContactService contactService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IContactService>();

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

        public ContactEditorViewModel()
        {
            Collection = new DefaultCollection<Contact>();
            ContactAdresses = new DefaultCollection<Adress>();
            ContactEmails = new DefaultCollection<Email>();
            ContactPhoneNumbers = new DefaultCollection<Phone>();
            ContactCompanies = new DefaultCollection<Company>();

            if (Model == null)
                Model = new Contact();

            physicalAddressViewModel = new PhysicalAddressViewModel();
            emailAdressViewModel = new EmailAdressViewModel();
            phoneNumberViewModel = new PhoneNumberViewModel();
        }

        public ContactEditorViewModel(Contact contact) : this()
        {
            this.Model = contact;

            physicalAddressViewModel = new PhysicalAddressViewModel(contact);
            emailAdressViewModel = new EmailAdressViewModel(contact);
            phoneNumberViewModel = new PhoneNumberViewModel(contact);

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

        public bool AddNewAdress(Adress newAdress)
        {
            if(newAdress == null)
                return false;

            if(!this.ContactAdresses.Contains(newAdress))
            {
                ContactAdresses.Add(newAdress);
                if(physicalAddressViewModel.New(newAdress))
                    return true;
            }
            return false;
        }

        public bool AddNewPhoneNumber(Phone newPhone)
        {
            if(newPhone == null)
                return false;

            if(!this.ContactPhoneNumbers.Contains(newPhone))
            {
                ContactPhoneNumbers.Add(newPhone);
                if(phoneNumberViewModel.New(newPhone))
                    return true;
            }
            return false;
        }

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
