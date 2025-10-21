using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Defines the contract for managing phone entities, including operations for retrieving, creating, updating, and
    /// deleting phones.
    /// </summary>
    /// <remarks>This interface extends <see cref="IServiceBase{TKey, TEntity, TRepository}"/> with <see
    /// cref="Guid"/> as the key type, <see cref="Phone"/> as the entity type, and <see cref="IPhoneRepository"/> as the
    /// repository type. It provides a standardized way to interact with phone-related data.</remarks>
    public interface IPhoneService : IServiceBase<Guid, Phone, IPhoneRepository>
    {
    }
}
