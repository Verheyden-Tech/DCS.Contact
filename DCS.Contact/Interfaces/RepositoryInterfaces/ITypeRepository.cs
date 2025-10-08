using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Defines a repository for managing and retrieving <see cref="Type"/> objects, identified by <see cref="Guid"/>
    /// keys.
    /// </summary>
    /// <remarks>This interface extends <see cref="IRepositoryBase{TKey, TValue}"/> to provide functionality
    /// specific to  repositories handling <see cref="Type"/> instances. Implementations of this interface are expected
    /// to  support operations such as adding, updating, retrieving, and deleting <see cref="Type"/> objects.</remarks>
    public interface ITypeRepository : IRepositoryBase<Guid, Type>
    {
    }
}
