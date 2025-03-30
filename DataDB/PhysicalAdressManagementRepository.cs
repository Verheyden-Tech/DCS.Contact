using DCS.DefaultTemplates;
using DCS.SQLService;

namespace DCS.Contact.DataDB
{
    /// <summary>
    /// PhysicalAdressManagementRepository to handle physical adress data on the table.
    /// </summary>
    public class PhysicalAdressManagementRepository : IRepositoryBase<Adress>, IPhysicalAdressManagementRepository
    {
        private ISqlService sqlService = CommonServiceLocator.ServiceLocator.Current.GetInstance<ISqlService>();
        private Adress model;

        /// <summary>
        /// Table name for PhysicalAdressManagementRepository.
        /// </summary>
        public string TableName => "dbo.AdressData";

        /// <summary>
        /// Primary key column for PhysicalAdressManagementRepository.
        /// </summary>
        public string PrimaryKeyColumn => "Guid";

        /// <summary>
        /// Model for PhysicalAdressManagementRepository.
        /// </summary>
        public Adress Model => model;

        /// <summary>
        /// Constructor for PhysicalAdressManagementRepository.
        /// </summary>
        public PhysicalAdressManagementRepository()
        {
            
        }

        /// <summary>
        /// Constructor for PhysicalAdressManagementRepository.
        /// </summary>
        /// <param name="adress"></param>
        public PhysicalAdressManagementRepository(Adress adress) : this()
        {
            this.model = adress;
        }

        /// <summary>
        /// Delete physical adress data by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool Delete(Guid guid)
        {
            var sql = $"DELETE FROM {TableName} WHERE {PrimaryKeyColumn} = @guid";

            return sqlService.ExecuteSQL(sql, new { guid = guid });
        }

        /// <summary>
        /// Get physical adress data by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public Adress Get(Adress guid)
        {
            var sql = $"SELECT * FROM {TableName} WHERE {PrimaryKeyColumn} = @guid";

            return sqlService.SQLQuery<Adress>(sql, new { guid = guid});
        }

        /// <summary>
        /// Get all physical adress data.
        /// </summary>
        /// <returns></returns>
        public DefaultCollection<Adress> GetAll()
        {
            var sql = $"SELECT * FROM {TableName}";

            return sqlService.SQLQueryList<Adress>(sql, null) as DefaultCollection<Adress>;
        }

        /// <inheritdoc/>
        public DefaultCollection<Adress> GetAllByContact(Guid contactGuid)
        {
            var sql = $"SELECT * FROM {TableName} WHERE ContactGuid = @contactGuid";

            return sqlService.SQLQueryList<Adress>(sql, new { contactGuid = contactGuid}) as DefaultCollection<Adress>;
        }

        /// <summary>
        /// Insert new physical adress data.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool New(Adress obj)
        {
            var sql = $"INSERT INTO {TableName} (Guid, StreetName, HouseNumber, AdressAddon, City, PostalCode, Country, UserGuid, ContactGuid, CompanyGuid) VALUES (@guid, @streetName, @houseNumber, @adressAddon, @city, @postalCode, @country, @userGuid, @contactGuid, @companyGuid)";

            if(sqlService.ExecuteSQL(sql, new { guid = obj.Guid, streetName = obj.StreetName, houseNumber = obj.HouseNumber, adressAddon = obj.AdressAddon, city = obj.City, postalCode = obj.PostalCode, country = obj.Country, userGuid = obj.UserGuid, contactGuid = obj.ContactGuid, companyGuid = obj.CompanyGuid }))
            {
                return true;
            }
            else { return false; };
        }

        /// <summary>
        /// Update physical adress data.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(Adress obj)
        {
            var sql = $"INSERT INTO {TableName} (Guid, StreetName, HouseNumber, AdressAddon, City, PostalCode, Country, UserGuid, ContactGuid, CompanyGuid) ON EXISTING UPDATE VALUES (@guid, @streetName, @houseNumber, @adressAddon, @city, @postalCode, @country, @userGuid, @contactGuid, @companyGuid)";

            if (sqlService.ExecuteSQL(sql, new { guid = obj.Guid, streetName = obj.StreetName, houseNumber = obj.HouseNumber, adressAddon = obj.AdressAddon, city = obj.City, postalCode = obj.PostalCode, country = obj.Country, userGuid = obj.UserGuid, contactGuid = obj.ContactGuid, companyGuid = obj.CompanyGuid }))
            {
                return true;
            }
            else { return false; };
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="ident"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Adress GetById(int ident)
        {
            throw new NotImplementedException();
        }
    }
}
