using DCS.DefaultTemplates;
using DCS.User;

namespace DCS.Contact.Services
{
    /// <summary>
    /// Phone Service to handle phone data on the table.
    /// </summary>
    public class PhoneService : IServiceBase<Phone, IPhoneManagementRepository>, IPhoneService
    {
        private Phone model;

        /// <summary>
        /// Repository to handle phone data on the table.
        /// </summary>
        public IPhoneManagementRepository Repository => CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhoneManagementRepository>();

        /// <summary>
        /// Model for phone data.
        /// </summary>
        public Phone Model => model;

        /// <summary>
        /// Constructor for <see cref="PhoneService"/>.
        /// </summary>
        public PhoneService()
        {
            
        }

        /// <summary>
        /// Constructor for <see cref="PhoneService"/>.
        /// </summary>
        /// <param name="phone"></param>
        public PhoneService(Phone phone) : this()
        {
            this.model = phone;
        }

        /// <summary>
        /// Delete phone data by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool Delete(Guid guid)
        {
            return Repository.Delete(guid);
        }

        /// <summary>
        /// Get phone data by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public Phone Get(Guid guid)
        {
            return Repository.Get(guid);
        }

        /// <summary>
        /// Get all phone data.
        /// </summary>
        /// <returns></returns>
        public DefaultCollection<Phone> GetAll()
        {
            return Repository.GetAll();
        }

        /// <inheritdoc/>
        public DefaultCollection<Phone> GetAllByContact(Guid contactGuid)
        {
            return Repository.GetAllByContact(contactGuid);
        }

        /// <summary>
        /// Insert new phone data.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool New(Phone obj)
        {
            return Repository.New(obj);
        }

        /// <summary>
        /// Update phone data.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(Phone obj)
        {
            return Repository.Update(obj);
        }

        /// <inheritdoc/>
        public Phone CreateNewPhone(string phoneNumber, string type = "", bool isActive = true, Guid? contactGuid = null, Guid? companyGuid = null)
        {
            var newPhone = new Phone
            {
                Guid = Guid.NewGuid(),
                PhoneNumber = phoneNumber,
                Type = type,
                IsActive = isActive,
                ContactGuid = contactGuid,
                CompanyGuid = companyGuid,
                UserGuid = CurrentUserService.Instance.CurrentUser.Guid
            };

            return newPhone;
        }
    }
}
