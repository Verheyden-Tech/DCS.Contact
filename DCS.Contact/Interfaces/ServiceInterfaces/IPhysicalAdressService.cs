using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Defines the contract for managing physical address entities, including operations for retrieving, creating,
    /// updating, and deleting addresses.
    /// </summary>
    /// <remarks>This interface extends <see cref="IServiceBase{TKey, TEntity, TRepository}"/> to provide a
    /// standardized set of operations for handling physical address data. Implementations of this service are expected
    /// to interact with a repository of type <see cref="IPhysicalAdressRepository"/>.</remarks>
    public interface IPhysicalAdressService : IServiceBase<Guid, Adress, IPhysicalAdressRepository>
    {
    }
}
