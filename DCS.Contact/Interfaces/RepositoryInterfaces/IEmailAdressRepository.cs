using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Repository for email data management on the table.
    /// </summary>
    public interface IEmailAdressRepository : IRepositoryBase<Guid, Email>
    {
    }
}
