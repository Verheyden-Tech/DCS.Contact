using DCS.DefaultTemplates;
using System.Collections.ObjectModel;

namespace DCS.Contact.UI
{
    /// <summary>
    /// ViewModel for physical adresses.
    /// </summary>
    public class PhysicalAddressViewModel : ViewModelBase<Guid, Adress>
    {
        private IPhysicalAdressService physicalAdressService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhysicalAdressService>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicalAddressViewModel"/> class.
        /// </summary>
        /// <param name="adress"></param>
        public PhysicalAddressViewModel(Adress adress)
        {
            this.Collection = new ObservableCollection<Adress>();
            this.Model = adress;
        }

        /// <summary>
        /// Gets all contact related adresses.
        /// </summary>
        /// <param name="contact">Selected contact.</param>
        /// <returns>List of contact related adresses.</returns>
        /// <exception cref="ArgumentNullException">Gets thrown if given contact is null.</exception>
        public ObservableCollection<Adress> GetContactAdresses(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException("contact");

            return physicalAdressService.GetAllByContact(contact);
        }

        /// <summary>
        /// Gets or sets the street name.
        /// </summary>
        public string StreetName
        {
            get => Model.StreetName;
            set => Model.StreetName = value;
        }

        /// <summary>
        /// Gets or sets the house number.
        /// </summary>
        public string HouseNumber
        {
            get => Model.HouseNumber;
            set => Model.HouseNumber = value;
        }

        /// <summary>
        /// Gets or sets the adress postal code.
        /// </summary>
        public string PostalCode
        {
            get => Model.PostalCode;
            set => Model.PostalCode = value;
        }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City
        {
            get => Model.City;
            set => Model.City = value;
        }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        public string Country
        {
            get => Model.Country;
            set => Model.Country = value;
        }
    }
}
