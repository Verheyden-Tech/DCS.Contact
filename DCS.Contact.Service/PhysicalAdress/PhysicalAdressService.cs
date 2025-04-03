using DCS.User.Service;
using DCS.CoreLib.BaseClass;
using System.Collections.ObjectModel;

namespace DCS.Contact.Service
{
    /// <summary>
    /// DCS PhysicalAdressService to manipulate adress data.
    /// </summary>
    public class PhysicalAdressService : ServiceBase<Guid, Adress, IPhysicalAdressRepository>, IPhysicalAdressService
    {
        /// <summary>
        /// Repository for PhysicalAdressService.
        /// </summary>
        private IPhysicalAdressRepository repository;

        /// <summary>
        /// Constructor for PhysicalAdressService.
        /// </summary>
        public PhysicalAdressService(IPhysicalAdressRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        /// <inheritdoc/>
        public Adress CreateNewAdress(Contact ownerContact, string streetName, string houseNumber, string adressAddon, string city, string postalCode, string country, bool isActive = true, Company? ownerCompany = null)
        {
            Adress newAdress = new Adress
            {
                Guid = Guid.NewGuid(),
                StreetName = streetName,
                HouseNumber = houseNumber,
                AdressAddon = adressAddon,
                City = city,
                PostalCode = postalCode,
                Country = country,
                IsActive = true,
                UserGuid = CurrentUserService.Instance.CurrentUser.Guid,
                ContactGuid = ownerContact.Guid,
                CompanyGuid = ownerCompany?.Guid
            };

            return newAdress;
        }

        /// <inheritdoc/>
        public ObservableCollection<Adress> GetAllByContact(Guid contactGuid)
        {
            return repository.GetAllByContact(contactGuid);
        }

        /// <inheritdoc/>
        public ObservableCollection<Adress> GetAllByContact(Contact contact)
        {
            return repository.GetAllByContact(contact.Guid);
        }
    }
}
