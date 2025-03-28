using DCS.User;
using DCS.DefaultTemplates;

namespace DCS.Contact.Services
{
    /// <summary>
    /// DCS RoleService to manipulate role data.
    /// </summary>
    public class RoleService : IServiceBase<Role, IRoleManagementRepository>, IRoleService
    {
        private Role model;

        /// <summary>
        /// Repository for RoleService.
        /// </summary>
        public IRoleManagementRepository Repository => CommonServiceLocator.ServiceLocator.Current.GetInstance<IRoleManagementRepository>();

        /// <summary>
        /// Model for role data.
        /// </summary>
        public Role Model => model;

        /// <summary>
        /// Constructor for RoleService.
        /// </summary>
        public RoleService()
        {
            
        }

        /// <summary>
        /// Copy constructor with parameters.
        /// </summary>
        /// <param name="role"></param>
        public RoleService(Role role) : this()
        {
            this.model = role;
        }

        /// <summary>
        /// Deletes a role by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool Delete(Guid guid)
        {
            return Repository.Delete(guid);
        }

        /// <summary>
        /// Gets a role by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public Role Get(Guid guid)
        {
            return Repository.Get(guid);
        }

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns></returns>
        public DefaultCollection<Role> GetAll()
        {
            return Repository.GetAll();
        }

        /// <summary>
        /// Creates a new role.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool New(Role obj)
        {
            return Repository.New(obj);
        }

        /// <summary>
        /// Updates a role.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(Role obj)
        {
            return Repository.Update(obj);
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
