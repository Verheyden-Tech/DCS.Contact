using DCS.DefaultTemplates;

namespace DCS.Contact.UI
{
    /// <summary>
    /// ViewModel for the contact info stats.
    /// </summary>
    public class ContactInfoStatsViewModel : ViewModelBase<Guid, Contact>
    {
        private DefaultCollection<Adress> adresses;
        private DefaultCollection<Phone> phoneNumbers;
        private DefaultCollection<Email> emails;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactInfoStatsViewModel"/> class.
        /// </summary>
        /// <param name="contact"></param>
        public ContactInfoStatsViewModel(Contact contact)
        {
            this.Model = contact;

            Adresses = new DefaultCollection<Adress>();
            PhoneNumbers = new DefaultCollection<Phone>();
            EmailAdresses = new DefaultCollection<Email>();
        }

        #region Public Props
        /// <summary>
        /// Gets or sets the first name of the contact.
        /// </summary>
        public string FirstName
        {
            get => Model.FirstName;
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
            get => Model.LastName;
            set
            {
                Model.LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        /// <summary>
        /// Gets or sets the adresses of the contact.
        /// </summary>
        public DefaultCollection<Adress> Adresses
        {
            get => adresses;
            set => adresses = value;
        }

        /// <summary>
        /// Gets or sets the phone numbers of the contact.
        /// </summary>
        public DefaultCollection<Phone> PhoneNumbers
        {
            get => phoneNumbers;
            set => phoneNumbers = value;
        }

        /// <summary>
        /// Gets or sets the email adresses of the contact.
        /// </summary>
        public DefaultCollection<Email> EmailAdresses
        {
            get => emails;
            set => emails = value;
        }
        #endregion
    }
}
