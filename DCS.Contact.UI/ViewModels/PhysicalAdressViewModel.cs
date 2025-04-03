using DCS.CoreLib.BaseClass;
using System.Collections.ObjectModel;

namespace DCS.Contact.UI
{
    /// <summary>
    /// ViewModel for physical adresses.
    /// </summary>
    public class PhysicalAdressViewModel : ViewModelBase<Guid, Adress>
    {
        private IPhysicalAdressService physicalAdressService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhysicalAdressService>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicalAdressViewModel"/> class.
        /// </summary>
        public PhysicalAdressViewModel(Adress adress) : base()
        {
            this.Model = adress;
            this.Collection = new ObservableCollection<Adress>();
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
