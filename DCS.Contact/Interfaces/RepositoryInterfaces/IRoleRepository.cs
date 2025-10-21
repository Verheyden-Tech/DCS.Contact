using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Defines a repository for managing <see cref="Role"/> entities, identified by a <see cref="Guid"/> key.
    /// </summary>
    /// <remarks>This interface extends <see cref="IRepositoryBase{TKey, TEntity}"/> to provide functionality
    /// specific to <see cref="Role"/> entities. It serves as a contract for implementing data access operations related
    /// to roles.</remarks>
    public interface IRoleRepository : IRepositoryBase<Guid, Role>
    {
    }
}
