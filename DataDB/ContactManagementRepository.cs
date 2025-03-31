using DCS.DefaultTemplates;
using DCS.SQLService;
using System.Collections.ObjectModel;

namespace DCS.Contact.DataDB
{
    /// <summary>
    /// DCS ContactManagementRepository to manipulate contact data on the table.
    /// </summary>
    public class ContactManagementRepository : RepositoryBase<Guid, Contact>, IContactManagementRepository
    {
        private readonly ISqlService sqlService;

        /// <summary>
        /// Table name for the contact data.
        /// </summary>
        public override string TableName => "dbo.ContactData";

        /// <summary>
        /// Primary key column for the contact data.
        /// </summary>
        public override string PrimaryKeyColumn => "Guid";

        /// <summary>
        /// Constructor for the contact management repository.
        /// </summary>
        public ContactManagementRepository(ISqlService sqlService) : base(sqlService)
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
