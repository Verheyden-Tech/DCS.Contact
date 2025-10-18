using DCS.CoreLib.BaseClass;

namespace DCS.Contact.Service
{
    /// <summary>
    /// DCS PhysicalAdressService to manipulate adress data.
    /// </summary>
    public class PhysicalAdressService : ServiceBase<Guid, Adress, IPhysicalAdressRepository>, IPhysicalAdressService
    {
        /// <summary>
        /// Repository for PhysicalAdressService.
        /// </summary>
        private IPhysicalAdressRepository repository;

        /// <summary>
        /// Constructor for PhysicalAdressService.
        /// </summary>
        public PhysicalAdressService(IPhysicalAdressRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
