using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Defines the contract for managing and interacting with groups within the application.
    /// </summary>
    /// <remarks>This interface extends <see cref="IServiceBase{TKey, TEntity, TRepository}"/> to provide
    /// group-specific functionality. It serves as the abstraction for operations related to the <see cref="Group"/>
    /// entity, such as retrieval, creation, updating, and deletion.</remarks>
    public interface IGroupService : IServiceBase<Guid, Group, IGroupRepository>
    {
    }
}
