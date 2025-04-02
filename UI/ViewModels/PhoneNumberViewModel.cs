using DCS.DefaultTemplates;

namespace DCS.Contact.UI
{
    /// <summary>
    /// Phone number view model.
    /// </summary>
    public class PhoneNumberViewModel : ViewModelBase<Guid, Phone>
    {
        private IPhoneService phoneService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhoneService>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberViewModel"/> class.
        /// </summary>
        /// <param name="phone">Selected phone model instance.</param>
        public PhoneNumberViewModel(Phone phone)
        {
            Collection = new DefaultCollection<Phone>();
            this.Model = phone;
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
    }
}
