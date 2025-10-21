using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Defines the contract for managing roles within the application.
    /// </summary>
    /// <remarks>This interface extends <see cref="IServiceBase{TKey, TEntity, TRepository}"/> to provide
    /// role-specific operations. Implementations of this interface are responsible for handling role-related business
    /// logic and data access through the associated repository.</remarks>
    public interface IRoleService : IServiceBase<Guid, Role, IRoleRepository>
    {
    }
}
