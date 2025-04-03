using DCS.CoreLib.BaseClass;
using DCS.User.Service;
using System.Collections.ObjectModel;

namespace DCS.Contact.Service
{
    /// <summary>
    /// EmailAdressService to manipulate emailadress data.
    /// </summary>
    public class EmailAdressService : ServiceBase<Guid, Email, IEmailAdressRepository>, IEmailAdressService
    {
        /// <summary>
        /// Repository for email data.
        /// </summary>
        private IEmailAdressRepository repository;

        /// <summary>
        /// EmailAdressService constructor.
        /// </summary>
        public EmailAdressService(IEmailAdressRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        /// <inheritdoc/>
        public ObservableCollection<Email> GetAllByContact(Guid contactGuid)
        {
            return repository.GetAllByContact(contactGuid);
        }

        /// <inheritdoc/>
        public ObservableCollection<Email> GetAllByUser(Guid userGuid)
        {
            return repository.GetAllByUser(userGuid);
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
