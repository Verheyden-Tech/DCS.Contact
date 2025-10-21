using DCS.Data;
using DCS.CoreLib.BaseClass;

namespace DCS.Contact.Data
{
    /// <summary>
    /// Provides a repository for managing <see cref="Company"/> entities, including database operations such as
    /// retrieval, insertion, and updates. This repository is specifically tailored to work with the
    /// "dbo.VT_Contact_Company" database table.
    /// </summary>
    /// <remarks>This class extends <see cref="RepositoryBase{TKey, TEntity}"/> and implements <see
    /// cref="ICompanyRepository"/>. It uses the provided <see cref="ISqlService"/> to interact with the database. The
    /// table name and primary key column are predefined as "dbo.VT_Contact_Company" and "Guid", respectively.</remarks>
    public class CompanyManagementRepository : RepositoryBase<Guid, Company>, ICompanyRepository
    {
        private readonly ISqlService sqlService = CommonServiceLocator.ServiceLocator.Current.GetInstance<ISqlService>();

        /// <summary>
        /// Gets the name of the database table associated with the contact company.
        /// </summary>
        public static readonly new string TableName = "dbo.VT_Contact_Company";

        /// <summary>
        /// Represents the name of the primary key column used in the database.
        /// </summary>
        public static readonly new string PrimaryKeyColumn = "Guid";

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyManagementRepository"/> class.
        /// </summary>
        /// <remarks>This constructor sets up the repository with the specified SQL service and
        /// initializes the base repository with the table name and primary key column specific to the company
        /// management data.</remarks>
        /// <param name="sqlService">The SQL service used to interact with the database.</param>
        public CompanyManagementRepository(ISqlService sqlService) : base(sqlService, TableName, PrimaryKeyColumn)
        {
            this.sqlService = sqlService;
        }
    }
}
