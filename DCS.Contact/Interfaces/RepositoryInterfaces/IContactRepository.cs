using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// DCS ContactManagementRepository to manipulate contact data on the table.
    /// </summary>
    public interface IContactRepository : IRepositoryBase<Guid, Contact>
    {
    }
}
