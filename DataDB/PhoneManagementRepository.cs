using DCS.DefaultTemplates;
using DCS.SQLService;

namespace DCS.Contact.DataDB
{
    /// <summary>
    /// Phone Management Repository to handle phone data on the table.
    /// </summary>
    public class PhoneManagementRepository : IRepositoryBase<Phone>, IPhoneManagementRepository
    {
        private ISqlService sqlService = CommonServiceLocator.ServiceLocator.Current.GetInstance<ISqlService>();
        private Phone model;

        /// <summary>
        /// Constructor for PhoneManagementRepository.
        /// </summary>
        public PhoneManagementRepository()
        {
            
        }

        /// <summary>
        /// Constructor for PhoneManagementRepository.
        /// </summary>
        /// <param name="phone"></param>
        public PhoneManagementRepository(Phone phone) : this()
        {
            this.model = phone;
        }

        /// <summary>
        /// Model for PhoneManagementRepository.
        /// </summary>
        public Phone Model => model;

        /// <summary>
        /// Table name for PhoneManagementRepository.
        /// </summary>
        public string TableName => "dbo.PhoneData";

        /// <summary>
        /// Primary key column for PhoneManagementRepository.
        /// </summary>
        public string PrimaryKeyColumn => "Guid";

        /// <summary>
        /// Delete phone data by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool Delete(Guid guid)
        {
            var sql = $"UPDATE {TableName} SET IsActive = @isActive WHERE {PrimaryKeyColumn} = @guid";

            return sqlService.ExecuteSQL(sql, new { isActive = false, guid = guid});
        }

        /// <summary>
        /// Get phone data by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public Phone Get(Guid guid)
        {
            var sql = $"SELECT * FROM {TableName} WHERE {PrimaryKeyColumn} = @guid";

            return sqlService.SQLQuery<Phone>(sql, new { guid = guid});
        }

        /// <summary>
        /// Get all phone data.
        /// </summary>
        /// <returns></returns>
        public DefaultCollection<Phone> GetAll()
        {
            var sql = $"SELECT * FROM {TableName}";

            return sqlService.SQLQueryList<Phone>(sql, null) as DefaultCollection<Phone>;
        }

        /// <inheritdoc/>
        public DefaultCollection<Phone> GetAllByContact(Guid contactGuid)
        {
            var sql = $"SELECT * FROM {TableName} WHERE ContactGuid = @guid";

            return sqlService.SQLQueryList<Phone>(sql, new { guid = contactGuid }) as DefaultCollection<Phone>;
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="ident"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Phone GetById(int ident)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Insert new phone data.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool New(Phone obj)
        {
            var sql = $"INSERT INTO {TableName} (Guid, Type, PhoneNumber, IsActive, UserGuid, ContactGuid, CompanyGuid) VALUES (@guid, @type, @phoneNumber, @isActive, @userGuid, @contactGuid, @companyGuid)";

            return sqlService.ExecuteSQL(sql, new { guid = obj.Guid, type = obj.Type, phoneNumber = obj.PhoneNumber, obj.IsActive, userGuid = obj.UserGuid, contactGuid = obj.ContactGuid, companyGuid = obj.CompanyGuid});
        }

        /// <summary>
        /// Update phone data.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(Phone obj)
        {
            var sql = $"INSERT INTO {TableName} (Guid, Type, PhoneNumber, IsActive, UserGuid, ContactGuid, CompanyGuid) ON EXISTING UPDATE VALUES (@guid, @type, @phoneNumber, @isActive, @userGuid, @contactGuid, @companyGuid)";

            return sqlService.ExecuteSQL(sql, new { guid = obj.Guid, type = obj.Type, phoneNumber = obj.PhoneNumber, isActive = obj.IsActive, userGuid = obj.UserGuid, contactGuid = obj.ContactGuid, companyGuid = obj.CompanyGuid });
        }
    }
}
