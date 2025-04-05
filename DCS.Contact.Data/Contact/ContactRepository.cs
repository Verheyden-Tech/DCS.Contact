using DCS.Data;
using DCS.CoreLib.BaseClass;
using System.Collections.ObjectModel;

namespace DCS.Contact.Data
{
    /// <summary>
    /// DCS ContactManagementRepository to manipulate contact data on the table.
    /// </summary>
    public class ContactRepository : RepositoryBase<Guid, Contact>, IContactRepository
    {
        private readonly ISqlService sqlService;

        /// <summary>
        /// Table name for the contact data.
        /// </summary>
        public static string tableName => "dbo.VT_Contact";

        /// <summary>
        /// Primary key column for the contact data.
        /// </summary>
        public static string primaryKeyColumn => "Guid";

        /// <summary>
        /// Constructor for the contact management repository.
        /// </summary>
        public ContactRepository(ISqlService sqlService) : base(sqlService, tableName, primaryKeyColumn)
        {
            this.sqlService = sqlService;
        }

        /// <inheritdoc/>
        public ObservableCollection<Contact> GetByFirstName(string contactFirstName)
        {
            var sql = $"SELECT * FROM {TableName} WHERE FirstName = @firstName";

            return sqlService.SQLQueryList<Contact>(sql, new { firstName = contactFirstName });
        }

        /// <inheritdoc/>
        public ObservableCollection<Contact> GetByLastName(string contactLastName)
        {
            var sql = $"SELECT * FROM {TableName} WHERE LastName = @lastName";

            return sqlService.SQLQueryList<Contact>(sql, new { lastName = contactLastName });
        }
    }
}
