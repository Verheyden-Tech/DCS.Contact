using DCS.CoreLib.BaseClass;
using DCS.Data;

namespace DCS.Contact.Data
{
    /// <summary>
    /// Repository for email data management on the table.
    /// </summary>
    public class EmailRepository : RepositoryBase<Guid, Email>, IEmailAdressRepository
    {
        private readonly ISqlService sqlService;

        /// <summary>
        /// Table name for the repository.
        /// </summary>
        public static readonly new string TableName = "dbo.VT_Contact_Email";

        /// <summary>
        /// Primary key column for the repository.
        /// </summary>
        public static new string PrimaryKeyColumn = "Guid";

        /// <summary>
        /// Constructor for the repository.
        /// </summary>
        public EmailRepository(ISqlService sqlService) : base(sqlService, TableName, PrimaryKeyColumn)
        {
            this.sqlService = sqlService;
        }
    }
}
