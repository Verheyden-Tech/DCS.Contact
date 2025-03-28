using DCS.User;
using DCS.DefaultTemplates;

namespace DCS.Contact.Services
{
    /// <summary>
    /// DCS PhysicalAdressService to manipulate adress data.
    /// </summary>
    public class PhysicalAdressService : IServiceBase<Adress, IPhysicalAdressManagementRepository>, IPhysicalAdressService
    {
        private Adress model;

        /// <summary>
        /// Repository for PhysicalAdressService.
        /// </summary>
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
        /// Deletes a physical adress by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool Delete(Guid guid)
        {
            return Repository.Delete(guid);
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

        /// <summary>
        /// Gets a physical adress by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public Adress Get(Guid guid)
        {
            return Repository.Get(guid);
        }

        /// <summary>
        /// Gets all physical adresses.
        /// </summary>
        /// <returns></returns>
        public DefaultCollection<Adress> GetAll()
        {
            return Repository.GetAll();
        }

        /// <inheritdoc/>
        public DefaultCollection<Adress> GetAllByContact(Contact contact)
        {
            return Repository.GetAllByContact(contact.Guid);
        }

        /// <summary>
        /// Creates a new physical adress.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool New(Adress obj)
        {
            return Repository.New(obj);
        }

        /// <summary>
        /// Updates a physical adress.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(Adress obj)
        {
            return Repository.Update(obj);
        }
    }
}
