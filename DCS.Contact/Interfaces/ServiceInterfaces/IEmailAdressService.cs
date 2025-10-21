using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Defines the contract for managing email addresses within the application.
    /// </summary>
    /// <remarks>This interface extends the <see cref="IServiceBase{TKey, TEntity, TRepository}"/> interface, 
    /// providing functionality specific to the handling of email addresses. It is designed to work  with a repository
    /// implementation of type <see cref="IEmailAdressRepository"/>.</remarks>
    public interface IEmailAdressService : IServiceBase<Guid, Email, IEmailAdressRepository>
    {
    }
}
