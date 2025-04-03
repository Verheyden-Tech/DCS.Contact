using DCS.DefaultTemplates;
using DCS.User;
using System.Collections.ObjectModel;

namespace DCS.Contact.Service
{
    /// <summary>
    /// Phone Service to handle phone data on the table.
    /// </summary>
    public class PhoneService : ServiceBase<Guid, Phone, IPhoneRepository>, IPhoneService
    {
        /// <summary>
        /// Repository to handle phone data on the table.
        /// </summary>
        private IPhoneRepository repository;

        /// <summary>
        /// Constructor for <see cref="PhoneService"/>.
        /// </summary>
        public PhoneService(IPhoneRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        /// <inheritdoc/>
        public ObservableCollection<Phone> GetAllByContact(Guid contactGuid)
        {
            return repository.GetAllByContact(contactGuid);
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
