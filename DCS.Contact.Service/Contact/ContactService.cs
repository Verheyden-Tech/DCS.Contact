using DCS.CoreLib.BaseClass;

namespace DCS.Contact.Service
{
    /// <summary>
    /// DCS ContactService to manipulate contact data.
    /// </summary>
    public class ContactService : ServiceBase<Guid, Contact, IContactRepository>, IContactService
    {
        /// <summary>
        /// Repository for contact management.
        /// </summary>
        private IContactRepository repository;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ContactService(IContactRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
