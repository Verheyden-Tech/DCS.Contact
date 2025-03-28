using DCS.Contact;
using DCS.DefaultTemplates;

namespace DCSBase.Contacts
{
    public class ContactInfoStatsViewModel : ViewModelBase<Contact>
    {
        private DefaultCollection<Adress> adresses;
        private DefaultCollection<Phone> phoneNumbers;
        private DefaultCollection<Email> emails;

        public ContactInfoStatsViewModel(Contact contact)
        {
            this.Model = contact;

            Adresses = new DefaultCollection<Adress>();
            PhoneNumbers = new DefaultCollection<Phone>();
            EmailAdresses = new DefaultCollection<Email>();
        }

        #region Public Props
        public string FirstName
        {
            get => Model.FirstName;
            set
            {
                Model.FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => Model.LastName;
            set
            {
                Model.LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public DefaultCollection<Adress> Adresses
        {
            get => adresses;
            set => adresses = value;
        }

        public DefaultCollection<Phone> PhoneNumbers
        {
            get => phoneNumbers;
            set => phoneNumbers = value;
        }

        public DefaultCollection<Email> EmailAdresses
        {
            get => emails;
            set => emails = value;
        }
        #endregion
    }
}
