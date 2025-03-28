using DCS.Contact;
using DCS.DefaultTemplates;
using DCSBase.DataDB.Interfaces;
using DCSBase.Services.Interfaces;

namespace DCSBase.Services
{
    public class RoleService : IServiceBase<Role, IRoleManagementRepository>, IRoleService
    {
        private Role model;

        public IRoleManagementRepository Repository => CommonServiceLocator.ServiceLocator.Current.GetInstance<IRoleManagementRepository>();

        public Role Model => model;

        public RoleService()
        {
            
        }

        public RoleService(Role role) : this()
        {
            this.model = role;
        }

        /// <inheritdoc/>
        public bool Delete(Guid guid)
        {
            return Repository.Delete(guid);
        }

        /// <inheritdoc/>
        public Role Get(Guid guid)
        {
            return Repository.Get(guid);
        }

        /// <inheritdoc/>
        public DefaultCollection<Role> GetAll()
        {
            return Repository.GetAll();
        }

        /// <inheritdoc/>
        public bool New(Role obj)
        {
            return Repository.New(obj);
        }

        /// <inheritdoc/>
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
