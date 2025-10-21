using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Defines a repository for managing <see cref="Contact"/> entities, identified by a <see cref="Guid"/>.
    /// </summary>
    /// <remarks>This interface extends <see cref="IRepositoryBase{TKey, TEntity}"/> to provide a contract for
    /// operations specific to <see cref="Contact"/> entities. Implementations of this interface  should handle data
    /// access and persistence for contacts.</remarks>
    public interface IContactRepository : IRepositoryBase<Guid, Contact>
    {
    }
}
