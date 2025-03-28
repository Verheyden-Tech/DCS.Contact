using DCS.DefaultTemplates;
using DCS.SQLService;

namespace DCS.Contact.DataDB
{
    /// <summary>
    /// Repository for group data management on the table.
    /// </summary>
    public class GroupManagementRepository : IRepositoryBase<Group>, IGroupManagementRepository
    {
        private ISqlService sqlService = CommonServiceLocator.ServiceLocator.Current.GetInstance<ISqlService>();
        private Group model;

        /// <summary>
        /// Table name for the repository.
        /// </summary>
        public string TableName => "dbo.GroupData";

        /// <summary>
        /// Primary key column for the repository.
        /// </summary>
        public string PrimaryKeyColumn => "Guid";

        /// <summary>
        /// Model for the repository.
        /// </summary>
        public Group Model => model;

        /// <summary>
        /// Constructor for the repository.
        /// </summary>
        public GroupManagementRepository()
        {
            
        }

        /// <summary>
        /// Delete group by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool Delete(Guid guid)
        {
            var sql = $"UPDATE {TableName} SET IsActive = @isActive WHERE {PrimaryKeyColumn} = @guid";

            return sqlService.ExecuteSQL(sql, new { isActive = false, guid = guid });
        }

        /// <summary>
        /// Get group by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public Group Get(Guid guid)
        {
            var sql = $"SELECT * FROM {TableName} WHERE {PrimaryKeyColumn} = @guid";

            return sqlService.SQLQuery<Group>(sql, new { guid = guid});
        }

        /// <summary>
        /// Get all groups.
        /// </summary>
        /// <returns></returns>
        public DefaultCollection<Group> GetAll()
        {
            var sql = $"SELECT * FROM {TableName}";

            return sqlService.SQLQueryList<Group>(sql, null) as DefaultCollection<Group>;
        }

        /// <summary>
        /// Insert new group on the table.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool New(Group obj)
        {
            var sql = $"INSERT INTO {TableName} (Guid, Name, Description, IsActive, UserGuid, CompanyGuid) VALUES (@guid, @name, @description, @isActive, @userGuid, @companyGuid)";

            if(sqlService.ExecuteSQL(sql, new { guid = obj.Guid, name  = obj.Name, description = obj.Description, isActive = obj.IsActive, userGuid = obj.UserGuid, companyGuid = obj.CompanyGuid }))
            {
                return true;
            } 
            else { return false; }
        }

        /// <summary>
        /// Update group on the table.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(Group obj)
        {
            var sql = $"INSERT INTO {TableName} (Guid, Name, Description, IsActive, UserGuid, CompanyGuid) ON EXISTING UPDATE VALUES (@guid, @name, @description, @isActive, @userGuid, @companyGuid)";

            if (sqlService.ExecuteSQL(sql, new { guid = obj.Guid, name = obj.Name, description = obj.Description, isActive = obj.IsActive, userGuid = obj.UserGuid, companyGuid = obj.CompanyGuid }))
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="ident"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Group GetById(int ident)
        {
            throw new NotImplementedException();
        }
    }
}
