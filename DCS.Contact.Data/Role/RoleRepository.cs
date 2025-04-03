using DCS.Data;
using DCS.CoreLib.BaseClass;

namespace DCS.Contact.Data
{
    /// <summary>
    /// Repository class for Role data.
    /// </summary>
    public class RoleRepository : RepositoryBase<Guid, Role>, IRoleRepository
    {
        private ISqlService sqlService;

        /// <summary>
        /// Table name for RoleManagementRepository.
        /// </summary>
        public static string TableName => "dbo.RoleData";

        /// <summary>
        /// Primary key column for RoleManagementRepository.
        /// </summary>
        public static string PrimaryKeyColumn => "Guid";

        /// <summary>
        /// Constructor for RoleManagementRepository.
        /// </summary>
        public RoleRepository(ISqlService sqlService) : base(sqlService)
        {
            this.sqlService = sqlService;
        }
    }
}
