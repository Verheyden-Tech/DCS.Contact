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
        /// <param name="isAdmin">Role has admin rights flag.</param>
        /// <param name="isActive">Role is active flag.</param>
        /// <returns>New instance of <see cref="Role"/>.</returns>
        Role CreateNewRole(string name, Guid companyGuid, string description = "", bool isAdmin = false, bool isActive = true);
    }
}
