using DCS.DefaultTemplates;
using DCS.SQLService;

namespace DCS.Contact.DataDB
{
    /// <summary>
    /// Repository class for Role data.
    /// </summary>
    public class RoleManagementRepository : IRepositoryBase<Role>, IRoleManagementRepository
    {
        private ISqlService sqlService = CommonServiceLocator.ServiceLocator.Current.GetInstance<ISqlService>();
        private Role model;

        /// <summary>
        /// Constructor for RoleManagementRepository.
        /// </summary>
        public RoleManagementRepository()
        {
            
        }

        /// <summary>
        /// Constructor for RoleManagementRepository.
        /// </summary>
        /// <param name="role"></param>
        public RoleManagementRepository(Role role) : this()
        {
            this.model = role;
        }

        /// <summary>
        /// Model for RoleManagementRepository.
        /// </summary>
        public Role Model => model;

        /// <summary>
        /// Table name for RoleManagementRepository.
        /// </summary>
        public string TableName => "dbo.RoleData";

        /// <summary>
        /// Primary key column for RoleManagementRepository.
        /// </summary>
        public string PrimaryKeyColumn => "Guid";

        /// <summary>
        /// Delete role data by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool Delete(Guid guid)
        {
            var sql = $"UPDATE {TableName} SET IsActive = @isActive WHERE Guid = @guid";

            return sqlService.ExecuteSQL(sql, new { isActive = false, guid = guid});
        }

        /// <summary>
        /// Get role data by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public Role Get(Guid guid)
        {
            var sql = $"SELECT * FROM {TableName} WHERE {PrimaryKeyColumn} = @guid";

            return sqlService.SQLQuery<Role>(sql, new { guid = guid});
        }

        /// <summary>
        /// Get all role data.
        /// </summary>
        /// <returns></returns>
        public DefaultCollection<Role> GetAll()
        {
            var sql = $"SELECT * FROM {TableName}";

            return sqlService.SQLQueryList<Role>(sql, null) as DefaultCollection<Role>;
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="ident"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Role GetById(int ident)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Insert new role data.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool New(Role obj)
        {
            var sql = $"INSERT INTO {TableName} (Guid, Name, Description, IsAdmin, IsActive, UserGuid, CompanyGuid) VALUES (@guid, @name, @description, @isAdmin, @isActive, @userGuid, @companyGuid)";

            return sqlService.ExecuteSQL(sql, new { guid = obj.Guid, name = obj.Name, description = obj.Description, isAdmin = obj.IsAdmin, isActive = obj.IsActive, userGuid = obj.UserGuid, companyGuid = obj.CompanyGuid});
        }

        /// <summary>
        /// Update role data.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(Role obj)
        {
            var sql = $"INSERT INTO {TableName} (Guid, Name, Description, IsAdmin, IsActive, UserGuid, CompanyGuid) ON EXISTING UPDATE VALUES (@guid, @name, @description, @isAdmin, @isActive, @userGuid, @companyGuid)";

            return sqlService.ExecuteSQL(sql, new { guid = obj.Guid, name = obj.Name, description = obj.Description, isAdmin = obj.IsAdmin, isActive = obj.IsActive, userGuid = obj.UserGuid, companyGuid = obj.CompanyGuid });
        }
    }
}
