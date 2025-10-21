using DCS.CoreLib.BaseClass;
using DCS.Data;

namespace DCS.Contact.Data
{
    /// <summary>
    /// Provides functionality for managing email-related data in the database.
    /// </summary>
    /// <remarks>The <see cref="EmailRepository"/> class is responsible for interacting with the database to
    /// perform operations related to email records. It uses the specified <see cref="ISqlService"/> to execute database
    /// queries and commands. This class extends <see cref="RepositoryBase{TKey, TEntity}"/> and implements <see
    /// cref="IEmailAdressRepository"/> to provide a specialized repository for email data.</remarks>
    public class EmailRepository : RepositoryBase<Guid, Email>, IEmailAdressRepository
    {
        private readonly ISqlService sqlService = CommonServiceLocator.ServiceLocator.Current.GetInstance<ISqlService>();

        /// <summary>
        /// Represents the name of the database table associated with contact email records.
        /// </summary>
        /// <remarks>This field is a constant string that specifies the fully qualified name of the table 
        /// in the database schema. It is intended to be used in database operations where the  table name is
        /// required.</remarks>
        public static readonly new string TableName = "dbo.VT_Contact_Email";

        /// <summary>
        /// Represents the name of the primary key column used in the database.
        /// </summary>
        public static new string PrimaryKeyColumn = "Guid";

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailRepository"/> class.
        /// </summary>
        /// <remarks>The <see cref="EmailRepository"/> class provides functionality for managing
        /// email-related data in the database. It relies on the specified <paramref name="sqlService"/> to perform
        /// database operations.</remarks>
        /// <param name="sqlService">The SQL service used to interact with the database. This parameter cannot be <see langword="null"/>.</param>
        public EmailRepository(ISqlService sqlService) : base(sqlService, TableName, PrimaryKeyColumn)
        {
            this.sqlService = sqlService;
        }
    }
}
