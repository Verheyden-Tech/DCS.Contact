using DCS.DefaultTemplates;
using DCS.SQLService;

namespace DCS.Contact.DataDB
{
    /// <summary>
    /// Company management repository to handle company data on the table.
    /// </summary>
    public class CompanyManagementRepository : RepositoryBase<Guid, Company>, ICompanyManagementRepository
    {
        private readonly ISqlService sqlService;

        /// <summary>
        /// Table name for the company data.
        /// </summary>
        public override string TableName => "dbo.CompanyData";

        /// <summary>
        /// Primary key column for the company data.
        /// </summary>
        public override string PrimaryKeyColumn => "Guid";

        /// <summary>
        /// Constructor for the company management repository.
        /// </summary>
        public CompanyManagementRepository(ISqlService sqlService) : base(sqlService)
        {
            this.sqlService = sqlService;
        }
    }
}
