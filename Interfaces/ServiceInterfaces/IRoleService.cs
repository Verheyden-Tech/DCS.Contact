using DCS.Contact;
using DCS.DefaultTemplates;
using DCSBase.DataDB.Interfaces;

namespace DCSBase.Services.Interfaces
{
    public interface IRoleService : IServiceBase<Role, IRoleManagementRepository>
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
