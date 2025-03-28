using DCS.Contact;
using DCS.DefaultTemplates;
using DCSBase.DataDB.Interfaces;
using DCSBase.Services.Interfaces;

namespace DCSBase.Services
{
    /// <inheritdoc/>
    public class EmailAdressService : IServiceBase<Email, IEmailAdressManagementRepository>, IEmailAdressService
    {
        private Email model;

        public IEmailAdressManagementRepository Repository => CommonServiceLocator.ServiceLocator.Current.GetInstance<IEmailAdressManagementRepository>();

        public Email Model => model;

        /// <summary>
        /// EmailAdressService constructor.
        /// </summary>
        public EmailAdressService()
        {
            
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        public EmailAdressService(Email email) : this()
        {
            this.model = email;
        }

        /// <inheritdoc/>
        public bool Delete(Guid guid)
        {
            return Repository.Delete(guid);
        }

        /// <inheritdoc/>
        public Email Get(Guid guid)
        {
            return Repository.Get(guid);
        }

        /// <inheritdoc/>
        public DefaultCollection<Email> GetAll()
        {
            return Repository.GetAll();
        }

        /// <inheritdoc/>
        public DefaultCollection<Email> GetAllByContact(Guid contactGuid)
        {
            return Repository.GetAllByContact(contactGuid);
        }

        /// <inheritdoc/>
        public DefaultCollection<Email> GetAllByUser(Guid userGuid)
        {
            return Repository.GetAllByUser(userGuid);
        }

        /// <inheritdoc/>
        public bool New(Email obj)
        {
            return Repository.New(obj);
        }

        /// <inheritdoc/>
        public bool Update(Email obj)
        {
            return Repository.Update(obj);
        }

        /// <inheritdoc/>
        public Email CreateEmailAdress(string mailAdress, Guid contactGuid, bool isActive = true, string type = "")
        {
            var newEmail = new Email
            {
                Guid = Guid.NewGuid(),
                Type = type,
                MailAdress = mailAdress,
                IsActive = isActive,
                UserGuid = CurrentUserService.Instance.CurrentUser.Guid,
                ContactGuid = contactGuid
            };

            return newEmail;
        }
    }
}
