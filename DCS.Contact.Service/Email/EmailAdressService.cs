using DCS.CoreLib.BaseClass;

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
    }
}
