using DCS.Contact;
using DCS.DefaultTemplates;
using DCSBase.Services.Interfaces;

namespace DCSBase.Contacts
{
    public class PhysicalAddressViewModel : ViewModelBase<Adress>
    {
        private IPhysicalAdressService physicalAdressService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhysicalAdressService>();

        public PhysicalAddressViewModel()
        {
            this.Collection = new DefaultCollection<Adress>();
        }

        #region Constructor
        public PhysicalAddressViewModel(Adress adress) : this()
        {
            this.Model = adress;
        }

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

        public DefaultCollection<Adress> GetContactAdresses(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException("contact");

            var adresses = new DefaultCollection<Adress>();

            adresses = physicalAdressService.GetAllByContact(contact);

            return adresses;
        }

        public bool New(Adress adress)
        {
            return physicalAdressService.New(adress);
        }

        public bool AddNewAdress(Adress adress)
        {
            if (adress == null)
                return false;

            this.Collection.Add(adress);
            return true;
        }

        public bool SaveAdresses()
        {
            foreach (var adress in this.Collection)
            {
                physicalAdressService.Update(adress);
            }

            return true;
        }

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

        public DefaultCollection<Adress> Adresses
        {
            get => this.Collection;
            set => this.Collection = value;
        }

        public string StreetName
        {
            get => Model.StreetName;
            set => Model.StreetName = value;
        }

        public string HouseNumber
        {
            get => Model.HouseNumber;
            set => Model.HouseNumber = value;
        }

        public string PostalCode
        {
            get => Model.PostalCode;
            set => Model.PostalCode = value;
        }

        public string City
        {
            get => Model.City;
            set => Model.City = value;
        }

        public string Country
        {
            get => Model.Country;
            set => Model.Country = value;
        }

        public Contact SelectedContact { get; set; }
    }
}
