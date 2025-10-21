using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Defines a repository for managing <see cref="Phone"/> entities, identified by a <see cref="Guid"/>.
    /// </summary>
    /// <remarks>This interface extends <see cref="IRepositoryBase{TKey, TEntity}"/> to provide functionality
    /// specific to <see cref="Phone"/> entities. Implementations of this interface should handle data access operations
    /// such as retrieving, adding, updating, and deleting <see cref="Phone"/> objects.</remarks>
    public interface IPhoneRepository : IRepositoryBase<Guid, Phone>
    {
    }
}
