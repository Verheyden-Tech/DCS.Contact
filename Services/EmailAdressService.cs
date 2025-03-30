using DCS.DefaultTemplates;
using DCS.User;

namespace DCS.Contact.Services
{
    /// <summary>
    /// EmailAdressService to manipulate emailadress data.
    /// </summary>
    public class EmailAdressService : IServiceBase<Email, IEmailAdressManagementRepository>, IEmailAdressService
    {
        private Email model;

        /// <summary>
        /// Repository for email data.
        /// </summary>
        public IEmailAdressManagementRepository repository => CommonServiceLocator.ServiceLocator.Current.GetInstance<IEmailAdressManagementRepository>();

        /// <summary>
        /// Model for email data.
        /// </summary>
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

        /// <summary>
        /// Delete email by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool Delete(Guid guid)
        {
            return repository.Delete(guid);
        }

        /// <summary>
        /// Get email by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public Email Get(Email guid)
        {
            return repository.Get(guid);
        }

        /// <summary>
        /// Get all emails.
        /// </summary>
        /// <returns></returns>
        public DefaultCollection<Email> GetAll()
        {
            return repository.GetAll();
        }

        /// <inheritdoc/>
        public DefaultCollection<Email> GetAllByContact(Guid contactGuid)
        {
            return repository.GetAllByContact(contactGuid);
        }

        /// <inheritdoc/>
        public DefaultCollection<Email> GetAllByUser(Guid userGuid)
        {
            return repository.GetAllByUser(userGuid);
        }

        /// <summary>
        /// Create new email.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool New(Email obj)
        {
            return repository.New(obj);
        }

        /// <summary>
        /// Update email.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(Email obj)
        {
            return repository.Update(obj);
        }

        /// <summary>
        /// Creates new email instance.
        /// </summary>
        /// <param name="mailAdress"></param>
        /// <param name="contactGuid"></param>
        /// <param name="isActive"></param>
        /// <param name="type"></param>
        /// <returns></returns>
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
