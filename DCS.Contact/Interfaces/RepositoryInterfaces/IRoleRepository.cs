using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Interface for RoleManagementRepository to handle role data on the table.
    /// </summary>
    public interface IRoleRepository : IRepositoryBase<Guid, Role>
    {
    }
}
