using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Defines a repository for managing physical address entities.
    /// </summary>
    /// <remarks>This interface extends <see cref="IRepositoryBase{TKey, TEntity}"/> to provide functionality
    /// specific to managing <see cref="Adress"/> entities identified by a <see cref="Guid"/>.</remarks>
    public interface IPhysicalAdressRepository : IRepositoryBase<Guid, Adress>
    {
    }
}
