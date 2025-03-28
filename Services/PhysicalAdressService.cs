using DCS.Contact;
using DCS.DefaultTemplates;
using DCSBase.DataDB.Interfaces;
using DCSBase.Services.Interfaces;

namespace DCSBase.Services
{
    /// <summary>
    /// DCS PhysicalAdressService to manipulate adress data.
    /// </summary>
    public class PhysicalAdressService : IServiceBase<Adress, IPhysicalAdressManagementRepository>, IPhysicalAdressService
    {
        private Adress model;

        public IPhysicalAdressManagementRepository Repository => CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhysicalAdressManagementRepository>();

        /// <summary>
        /// Physical adress model.
        /// </summary>
        public Adress Model => model;

        /// <summary>
        /// Constructor for PhysicalAdressService.
        /// </summary>
        public PhysicalAdressService()
        {
            
        }

        /// <summary>
        /// Copy constructor with parameters.
        /// </summary>
        public PhysicalAdressService(Adress adress) : this()
        {
            this.model = adress;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool Delete(Guid guid)
        {
            return Repository.Delete(guid);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
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

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Adress Get(Guid guid)
        {
            return Repository.Get(guid);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public DefaultCollection<Adress> GetAll()
        {
            return Repository.GetAll();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public DefaultCollection<Adress> GetAllByContact(Contact contact)
        {
            return Repository.GetAllByContact(contact.Guid);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool New(Adress obj)
        {
            return Repository.New(obj);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool Update(Adress obj)
        {
            return Repository.Update(obj);
        }
    }
}
