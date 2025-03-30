using DCS.DefaultTemplates;
using DCS.SQLService;

namespace DCS.Contact.DataDB
{
    /// <summary>
    /// Repository for email data management on the table.
    /// </summary>
    public class EmailManagementRepository : IRepositoryBase<Email>, IEmailAdressManagementRepository
    {
        private ISqlService sqlService = CommonServiceLocator.ServiceLocator.Current.GetInstance<ISqlService>();
        private Email model;

        /// <summary>
        /// Table name for the repository.
        /// </summary>
        public string TableName => "dbo.EmailData";

        /// <summary>
        /// Primary key column for the repository.
        /// </summary>
        public string PrimaryKeyColumn => "Guid";

        /// <summary>
        /// Model for the repository.
        /// </summary>
        public Email Model => model;

        /// <summary>
        /// Constructor for the repository.
        /// </summary>
        public EmailManagementRepository()
        {
            
        }

        /// <summary>
        /// Delete email by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
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
        /// Get email by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public Email Get(Email guid)
        {
            var sql = $"SELECT * FROM {TableName} WHERE {PrimaryKeyColumn} = @guid";
            
            return sqlService.SQLQuery<Email>(sql, new { guid = guid});
        }

        /// <summary>
        /// Get all emails.
        /// </summary>
        /// <returns></returns>
        public DefaultCollection<Email> GetAll()
        {
            var sql = $"SELECT * FROM {TableName}";

            return sqlService.SQLQueryList<Email>(sql, null) as DefaultCollection<Email>;
        }

        /// <inheritdoc/>
        public DefaultCollection<Email> GetAllByContact(Guid contactGuid)
        {
            var sql = $"SELECT * FROM {TableName} WHERE ContactGuid = @guid";

            return sqlService.SQLQueryList<Email>(sql, new { guid = contactGuid }) as DefaultCollection<Email>;
        }

        /// <inheritdoc/>
        public DefaultCollection<Email> GetAllByUser(Guid userGuid)
        {
            var sql = $"SELECT * FROM {TableName} WHERE UserGuid = @guid";

            return sqlService.SQLQueryList<Email>(sql, new { guid = userGuid }) as DefaultCollection<Email>;
        }

        /// <summary>
        /// Get all emails by company guid.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool New(Email obj)
        {
            var sql = $"INSERT INTO {TableName} (Guid, Type, MailAdress, IsActive, UserGuid, ContactGuid, CompanyGuid) VALUES (@guid, @type, @mailAdress, @isActive, @userGuid, @contactGuid, @companyGuid)";

            if(sqlService.ExecuteSQL(sql, new { guid  = obj.Guid, type = obj.Type, mailAdress = obj.MailAdress, isActive = obj.IsActive, userGuid = obj.UserGuid, contactGuid = obj.ContactGuid, companyGuid = obj.CompanyGuid }))
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Update email.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(Email obj)
        {
            var sql = $"INSERT INTO {TableName} (Guid, Type, MailAdress, IsActive, UserGuid, ContactGuid, CompanyGuid) ON EXISTING UPDATE VALUES (@guid, @type, @mailAdress, @isActive, @userGuid, @contactGuid, @companyGuid)";

            if (sqlService.ExecuteSQL(sql, new { guid = obj.Guid, type = obj.Type, mailAdress = obj.MailAdress, isActive = obj.IsActive, userGuid = obj.UserGuid, contactGuid = obj.ContactGuid, companyGuid = obj.CompanyGuid }))
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
        public Email GetById(int ident)
        {
            throw new NotImplementedException();
        }
    }
}
