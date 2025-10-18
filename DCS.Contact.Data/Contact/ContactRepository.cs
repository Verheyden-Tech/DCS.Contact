using DCS.CoreLib.BaseClass;
using DCS.Data;

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
    }
}
