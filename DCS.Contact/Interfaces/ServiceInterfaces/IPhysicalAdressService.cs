using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Physical Adress Service to handle contact adress data on the table.
    /// </summary>
    public interface IPhysicalAdressService : IServiceBase<Guid, Adress, IPhysicalAdressRepository>
    {
    }
}
