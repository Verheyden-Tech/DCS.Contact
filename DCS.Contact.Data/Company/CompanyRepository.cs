using DCS.Data;
using DCS.CoreLib.BaseClass;

namespace DCS.Contact.Data
{
    /// <summary>
    /// Company management repository to handle company data on the table.
    /// </summary>
    public class CompanyManagementRepository : RepositoryBase<Guid, Company>, ICompanyRepository
    {
        private readonly ISqlService sqlService;

        /// <summary>
        /// Table name for the company data.
        /// </summary>
        public static string TableName => "dbo.CompanyData";

        /// <summary>
        /// Primary key column for the company data.
        /// </summary>
        public static string PrimaryKeyColumn => "Guid";

        /// <summary>
        /// Constructor for the company management repository.
        /// </summary>
        public CompanyManagementRepository(ISqlService sqlService) : base(sqlService)
        {
            this.sqlService = sqlService;
        }
    }
}
