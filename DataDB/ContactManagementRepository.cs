using DCS.DefaultTemplates;
using DCS.SQLService;

namespace DCS.Contact.DataDB
{
    /// <summary>
    /// DCS ContactManagementRepository to manipulate contact data on the table.
    /// </summary>
    public class ContactManagementRepository : IRepositoryBase<Contact>, IContactManagementRepository
    {
        private Contact model;
        private ISqlService sqlService = CommonServiceLocator.ServiceLocator.Current.GetInstance<ISqlService>();

        /// <summary>
        /// Model for the contact data.
        /// </summary>
        public Contact Model => model;

        /// <summary>
        /// Table name for the contact data.
        /// </summary>
        public string TableName => "dbo.ContactData";

        /// <summary>
        /// Primary key column for the contact data.
        /// </summary>
        public string PrimaryKeyColumn => "Guid";

        /// <summary>
        /// Constructor for the contact management repository.
        /// </summary>
        public ContactManagementRepository()
        {
            
        }

        /// <summary>
        /// Constructor for the contact management repository.
        /// </summary>
        /// <param name="contact"></param>
        public ContactManagementRepository(Contact contact) : this()
        {
            this.model = contact;
        }

        /// <summary>
        /// Delete contact data by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns>Wether the delete was succesfull.</returns>
        public bool Delete(Guid guid)
        {
            var sql = $"UPDATE {TableName} SET IsActive = @isActive WHERE {PrimaryKeyColumn} = @guid";

            return sqlService.ExecuteSQL(sql, new { isActive = false, guid = guid});
        }

        /// <summary>
        /// Get contact data by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns>Contact instance by Guid.</returns>
        public Contact Get(Guid guid)
        {
            var sql = $"SELECT * FROM {TableName} WHERE {PrimaryKeyColumn} = @guid";

            return sqlService.SQLQuery<Contact>(sql, new { guid = guid});
        }

        /// <inheritdoc/>
        public DefaultCollection<Contact> GetByFirstName(string contactFirstName)
        {
            var sql = $"SELECT * FROM {TableName} WHERE FirstName = @firstName";

            return sqlService.SQLQueryList<Contact>(sql, new { firstName = contactFirstName }) as DefaultCollection<Contact>;
        }

        /// <inheritdoc/>
        public DefaultCollection<Contact> GetByLastName(string contactLastName)
        {
            var sql = $"SELECT * FROM {TableName} WHERE LastName = @lastName";

            return sqlService.SQLQueryList<Contact>(sql, new { lastName = contactLastName }) as DefaultCollection<Contact>;
        }

        /// <summary>
        /// Get all contacts.
        /// </summary>
        /// <returns>All avialable contacts.</returns>
        public DefaultCollection<Contact> GetAll()
        {
            var sql = $"SELECT * FROM {TableName}";

            var loadedContacts = sqlService.SQLQueryList<Contact>(sql, null);
            return loadedContacts as DefaultCollection<Contact>;
        }

        /// <summary>
        /// Insert new contact data on the table.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Wether the insert was succesfull.</returns>
        public bool New(Contact obj)
        {
            var sql = $"INSERT INTO {TableName} (Guid, FirstName, LastName, IsActive, UserGuid) VALUES (@guid, @firstName, @lastName, @isActive, @userGuid)";

            sqlService.ExecuteSQL(sql, new { guid = obj.Guid, firstName = obj.FirstName, lastName = obj.LastName, isActive = obj.IsActive, userGuid = obj.UserGuid});
            return true;
        }

        /// <summary>
        /// Update contact data on the table.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Wether the update was succesfull.</returns>
        public bool Update(Contact obj)
        {
            var sql = $"INSERT INTO {TableName} (Guid, FirstName, LastName, IsActive, UserGuid) ON EXISTING UPDATE VALUES (@guid, @firstName, @lastName, @isActive, @userGuid)";

            sqlService.ExecuteSQL(sql, new { guid = obj.Guid, firstName = obj.FirstName, lastName = obj.LastName, isActive = obj.IsActive, userGuid = obj.UserGuid });
            return true;
        }

        /// <summary>
        /// Not implemented in this object repository type.
        /// </summary>
        /// <param name="ident"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Contact GetById(int ident)
        {
            throw new NotImplementedException();
        }
    }
}
