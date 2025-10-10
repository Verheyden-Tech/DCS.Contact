using DCS.CoreLib.BaseClass;
using DCS.User.Service;
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
        public Phone CreateNewPhone(string phoneNumber, string type = "")
        {
            var newPhone = new Phone
            {
                Guid = Guid.NewGuid(),
                PhoneNumber = phoneNumber,
                Type = type,
                IsActive = true
            };

            return newPhone;
        }
    }
}
