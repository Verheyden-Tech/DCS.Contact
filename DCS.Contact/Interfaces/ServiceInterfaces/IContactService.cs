using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Defines the contract for managing and interacting with contact entities.
    /// </summary>
    /// <remarks>This interface extends <see cref="IServiceBase{TKey, TEntity, TRepository}"/> to provide
    /// functionality specific to the <see cref="Contact"/> entity. It is intended to be implemented by services that
    /// handle operations such as creating, updating, retrieving, and deleting contact records.</remarks>
    public interface IContactService : IServiceBase<Guid, Contact, IContactRepository>
    {
    }
}
