using DCS.Contact;
using DCS.DefaultTemplates;
using DCSBase.DataDB.Interfaces;
using DCSBase.Services.Interfaces;

namespace DCSBase.Services
{
    public class PhoneService : IServiceBase<Phone, IPhoneManagementRepository>, IPhoneService
    {
        private Phone model;

        public IPhoneManagementRepository Repository => CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhoneManagementRepository>();

        public Phone Model => model;

        public PhoneService()
        {
            
        }

        public PhoneService(Phone phone) : this()
        {
            this.model = phone;
        }

        /// <inheritdoc/>
        public bool Delete(Guid guid)
        {
            return Repository.Delete(guid);
        }

        /// <inheritdoc/>
        public Phone Get(Guid guid)
        {
            return Repository.Get(guid);
        }

        /// <inheritdoc/>
        public DefaultCollection<Phone> GetAll()
        {
            return Repository.GetAll();
        }

        public DefaultCollection<Phone> GetAllByContact(Guid contactGuid)
        {
            return Repository.GetAllByContact(contactGuid);
        }

        /// <inheritdoc/>
        public bool New(Phone obj)
        {
            return Repository.New(obj);
        }

        /// <inheritdoc/>
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
