using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Defines a repository interface for managing <see cref="Company"/> entities, identified by a <see cref="Guid"/>
    /// key.
    /// </summary>
    /// <remarks>This interface extends <see cref="IRepositoryBase{TKey, TEntity}"/> to provide a contract for
    /// data access operations  specific to <see cref="Company"/> entities. Implementations of this interface should
    /// handle the persistence and retrieval  of <see cref="Company"/> objects.</remarks>
    public interface ICompanyRepository : IRepositoryBase<Guid, Company>
    {
    }
}
