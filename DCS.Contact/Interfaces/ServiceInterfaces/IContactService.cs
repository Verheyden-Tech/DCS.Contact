using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Represents the contact service to handle and manipulate contact data on the table.
    /// </summary>
    public interface IContactService : IServiceBase<Guid, Contact, IContactRepository>
    {
    }
}
