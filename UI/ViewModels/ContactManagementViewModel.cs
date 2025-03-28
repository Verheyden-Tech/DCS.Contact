using DCS.Contact;
using DCS.DefaultTemplates;
using DCSBase.Services.Interfaces;

namespace DCSBase.Contacts
{
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
        public ContactManagementViewModel(Contact contact) : this()
        {
            this.Model = contact;

            physicalAddressViewModel = new PhysicalAddressViewModel(contact);
            emailAdressViewModel = new EmailAdressViewModel(contact);
            phoneNumberViewModel = new PhoneNumberViewModel(contact);
        }
        #endregion

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
            }
        }
        #endregion

        #region Public Lists
        public DefaultCollection<Adress> Adresses
        {
            get => adresses;
            set => adresses = value;
        }

        public DefaultCollection<Email> Emails
        {
            get => emails;
            set => emails = value;
        }

        public DefaultCollection<Phone> PhoneNumbers
        {
            get => phoneNumbers;
            set => phoneNumbers = value;
        }

        public DefaultCollection<Company> Companies
        {
            get => companies;
            set => companies = value;
        }

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
