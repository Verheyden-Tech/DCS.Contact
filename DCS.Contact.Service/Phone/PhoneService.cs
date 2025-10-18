using DCS.CoreLib.BaseClass;

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
    }
}
