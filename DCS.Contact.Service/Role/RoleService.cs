using DCS.User;
using DCS.DefaultTemplates;

namespace DCS.Contact.Service
{
    /// <summary>
    /// DCS RoleService to manipulate role data.
    /// </summary>
    public class RoleService : ServiceBase<Guid, Role, IRoleRepository>, IRoleService
    {
        /// <summary>
        /// Repository for RoleService.
        /// </summary>
        private readonly IRoleRepository repository;

        /// <summary>
        /// Constructor for RoleService.
        /// </summary>
        public RoleService(IRoleRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        /// <inheritdoc/>
        public Role CreateNewRole(string name, Guid companyGuid, string description = "", bool isAdmin = false, bool isActive = true)
        {
            var newRole = new Role
            {
                Guid = Guid.NewGuid(),
                Name = name,
                Description = description,
                IsAdmin = isAdmin,
                IsActive = isActive,
                CompanyGuid = companyGuid,
                UserGuid = CurrentUserService.Instance.CurrentUser.Guid
            };

            return newRole;
        }
    }
}
