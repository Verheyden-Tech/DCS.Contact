using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Defines a repository for managing email addresses, providing methods for data access and manipulation.
    /// </summary>
    /// <remarks>This interface extends <see cref="IRepositoryBase{TKey, TEntity}"/> with <see cref="Guid"/>
    /// as the key type  and <see cref="Email"/> as the entity type. It is intended to handle operations specific to
    /// email address entities.</remarks>
    public interface IEmailAdressRepository : IRepositoryBase<Guid, Email>
    {
    }
}
