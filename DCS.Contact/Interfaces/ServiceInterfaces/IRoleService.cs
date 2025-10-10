using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// DCS RoleService to manipulate role data.
    /// </summary>
    public interface IRoleService : IServiceBase<Guid, Role, IRoleRepository>
    {
        /// <summary>
        /// Creates a new instance of <see cref="Role"/>.
        /// </summary>
        /// <param name="name">Role name.</param>
        /// <param name="companyGuid">Company role is assigned to.</param>
        /// <param name="description">Role description.</param>
        /// <returns>New instance of <see cref="Role"/>.</returns>
        Role CreateNewRole(string name, Guid companyGuid, string description = "");
    }
}
