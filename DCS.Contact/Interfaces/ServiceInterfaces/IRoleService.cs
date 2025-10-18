using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// DCS RoleService to manipulate role data.
    /// </summary>
    public interface IRoleService : IServiceBase<Guid, Role, IRoleRepository>
    {
    }
}
