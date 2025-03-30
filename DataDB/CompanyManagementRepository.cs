using DCS.DefaultTemplates;
using DCS.SQLService;

namespace DCS.Contact.DataDB
{
    /// <summary>
    /// Company management repository to handle company data on the table.
    /// </summary>
    public class CompanyManagementRepository : IRepositoryBase<Company>, ICompanyManagementRepository
    {
        private ISqlService sqlService = CommonServiceLocator.ServiceLocator.Current.GetInstance<ISqlService>();
        private Company model;

        /// <summary>
        /// Table name for the company data.
        /// </summary>
        public string TableName => "dbo.CompanyData";

        /// <summary>
        /// Primary key column for the company data.
        /// </summary>
        public string PrimaryKeyColumn => "Guid";

        /// <summary>
        /// Model for the company data.
        /// </summary>
        public Company Model => model;

        /// <summary>
        /// Constructor for the company management repository.
        /// </summary>
        public CompanyManagementRepository()
        {
            
        }

        /// <summary>
        /// Delete company data by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns>Wether the delete was succesfull.</returns>
        public bool Delete(Guid guid)
        {
            var sql = $"UPDATE {TableName} SET IsActive = @isActive WHERE {PrimaryKeyColumn} = @guid";

            if (sqlService.ExecuteSQL(sql, new { isActive = false, guid = guid}))
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Get company data by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns>Company instance by Guid.</returns>
        public Company Get(Company guid)
        {
            var sql = $"SELECT * FROM {TableName} WHERE {PrimaryKeyColumn} = @guid";

            return sqlService.SQLQuery<Company>(sql, new { guid = guid});
        }

        /// <summary>
        /// Get all company data.
        /// </summary>
        /// <returns>All avialable company data.</returns>
        public DefaultCollection<Company> GetAll()
        {
            var sql = $"SELECT * FROM {TableName}";

            return sqlService.SQLQueryList<Company>(sql, null) as DefaultCollection<Company>;
        }

        /// <summary>
        /// Insert new company data.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Wether the insert was succesfull.</returns>
        public bool New(Company obj)
        {
            if (obj == null) return false;

            var sql = $"INSERT INTO {TableName} (Guid, Name, Type, IsActive, CompanyContact, ContactGuid, UserGuid) VALUES (@guid, @name, @type, @isActive, @companyContact, @contactGuid, @userGuid)";

            if(sqlService.ExecuteSQL(sql, new { guid = obj.Guid, name = obj.Name, type = obj.Type, isActive = obj.IsActive, companyContact = obj.CompanyContact, contactGuid = obj.ContactGuid, userGuid = obj.UserGuid}))
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Update company data.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Wether the update was succesfull.</returns>
        public bool Update(Company obj)
        {
            if(obj == null) return false;

            var sql = $"INSERT INTO {TableName} (Guid, Name, Type, IsActive, CompanyContact, ContactGuid, UserGuid) ON EXISTING UPDATE VALUES (@guid, @name, @type, @isActive, @companyContact, @contactGuid, @userGuid)";

            if (sqlService.ExecuteSQL(sql, new { guid = obj.Guid, name = obj.Name, type = obj.Type, isActive = obj.IsActive, companyContact = obj.CompanyContact, contactGuid = obj.ContactGuid, userGuid = obj.UserGuid }))
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Not implementet in this object repository type.
        /// </summary>
        /// <param name="ident"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Company GetById(int ident)
        {
            throw new NotImplementedException();
        }
    }
}
