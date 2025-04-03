using DCS.DefaultTemplates;
using System.Collections.ObjectModel;

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
        public PhoneNumberViewModel(Phone phone) : base()
        {
            this.Model = phone;
            this.Collection = new ObservableCollection<Phone>();
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
