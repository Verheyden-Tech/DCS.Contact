using DCS.CoreLib.BaseClass;
using DCS.Data;

namespace DCS.Contact.Data
{
    /// <summary>
    /// Provides data access functionality for managing phone records in the database.
    /// </summary>
    /// <remarks>This repository is responsible for interacting with the <see cref="TableName"/> table in the
    /// database and uses the specified <see cref="PrimaryKeyColumn"/> as the primary key. It extends the functionality
    /// of <see cref="RepositoryBase{TKey, TEntity}"/> to provide operations specific to the <see cref="Phone"/>
    /// entity.</remarks>
    public class PhoneRepository : RepositoryBase<Guid, Phone>, IPhoneRepository
    {
        private readonly ISqlService sqlService = CommonServiceLocator.ServiceLocator.Current.GetInstance<ISqlService>();

        /// <summary>
        /// Specifies the name of the database table associated with contact phone records.
        /// </summary>
        public static readonly new string TableName = "dbo.VT_Contact_Phone";

        /// <summary>
        /// Represents the name of the primary key column used in the database.
        /// </summary>
        public static readonly new string PrimaryKeyColumn = "Guid";

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneRepository"/> class, providing access to phone-related
        /// data operations.
        /// </summary>
        /// <remarks>This constructor sets up the repository with the specified SQL service, using
        /// predefined table and primary key column names. Ensure that the <paramref name="sqlService"/> parameter is
        /// properly configured before using this repository.</remarks>
        /// <param name="sqlService">The <see cref="ISqlService"/> instance used to interact with the database.</param>
        public PhoneRepository(ISqlService sqlService) : base(sqlService, TableName, PrimaryKeyColumn)
        {
            this.sqlService = sqlService;
        }
    }
}
