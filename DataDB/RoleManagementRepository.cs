using DCS.DefaultTemplates;
using DCS.SQLService;

namespace DCS.Contact.DataDB
{
    /// <summary>
    /// Repository class for Role data.
    /// </summary>
    public class RoleManagementRepository : RepositoryBase<Guid, Role>, IRoleManagementRepository
    {
        private ISqlService sqlService;

        /// <summary>
        /// Table name for RoleManagementRepository.
        /// </summary>
        public override string TableName => "dbo.RoleData";

        /// <summary>
        /// Primary key column for RoleManagementRepository.
        /// </summary>
        public override string PrimaryKeyColumn => "Guid";

        /// <summary>
        /// Constructor for RoleManagementRepository.
        /// </summary>
        public RoleManagementRepository(ISqlService sqlService) : base(sqlService)
        {
            this.sqlService = sqlService;
        }
    }
}
