using DCS.DefaultTemplates;
using DCS.User;

namespace DCS.Contact.UI
{
    /// <summary>
    /// ViewModel for physical adresses.
    /// </summary>
    public class PhysicalAddressViewModel : ViewModelBase<Adress>
    {
        private IPhysicalAdressService physicalAdressService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhysicalAdressService>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicalAddressViewModel"/> class.
        /// </summary>
        public PhysicalAddressViewModel()
        {
            this.Collection = new DefaultCollection<Adress>();
        }

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicalAddressViewModel"/> class.
        /// </summary>
        /// <param name="adress"></param>
        public PhysicalAddressViewModel(Adress adress) : this()
        {
            this.Model = adress;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicalAddressViewModel"/> class.
        /// </summary>
        /// <param name="contact"></param>
        public PhysicalAddressViewModel(Contact contact) : this()
        {
            this.SelectedContact = contact;

            Collection = GetContactAdresses(contact);

            if(this.Model == null && this.Collection != null && this.Collection.Count > 0)
            {
                this.Model = this.Collection.First();
            }
            else
            {
                this.Model = new Adress();
            }
        }
        #endregion

        /// <summary>
        /// Gets all adresses assigned to a contact.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public DefaultCollection<Adress> GetContactAdresses(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException("contact");

            var adresses = new DefaultCollection<Adress>();

            adresses = physicalAdressService.GetAllByContact(contact);

            return adresses;
        }

        /// <summary>
        /// Creates a new adress on the table.
        /// </summary>
        /// <param name="adress"></param>
        /// <returns></returns>
        public bool New(Adress adress)
        {
            return physicalAdressService.New(adress);
        }

        /// <summary>
        /// Adds a new adress to the collection.
        /// </summary>
        /// <param name="adress"></param>
        /// <returns></returns>
        public bool AddNewAdress(Adress adress)
        {
            if (adress == null)
                return false;

            this.Collection.Add(adress);
            return true;
        }

        /// <summary>
        /// Saves all adresses in the collection.
        /// </summary>
        /// <returns></returns>
        public bool SaveAdresses()
        {
            foreach (var adress in this.Collection)
            {
                physicalAdressService.Update(adress);
            }

            return true;
        }

        /// <summary>
        /// Removes an adress from the collection.
        /// </summary>
        /// <param name="adress"></param>
        /// <returns></returns>
        public bool RemoveAdress(Adress adress)
        {
            if (adress != null)
            {
                this.Collection.Remove(adress);
                if (!CurrentUserService.Instance.CurrentUser.IsLocalUser)
                {
                    physicalAdressService.Delete(adress.Guid);
                }
            }
            return true;
        }

        /// <summary>
        /// Gets the display adress.
        /// </summary>
        public string DisplayAdress
        {
            get
            {
                if (Model != null)
                {
                    string adress = Model.StreetName + " " + Model.HouseNumber + ", " + Model.PostalCode + " " + Model.City;
                    return adress;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets or sets the adresses collection.
        /// </summary>
        public DefaultCollection<Adress> Adresses
        {
            get => this.Collection;
            set => this.Collection = value;
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

        /// <summary>
        /// Gets or sets the selected contact.
        /// </summary>
        public Contact SelectedContact { get; set; }
    }
}
