using DCS.Data;
using DCS.CoreLib.BaseClass;

namespace DCS.Contact.Data
{
    /// <summary>
    /// Repository for group data management on the table.
    /// </summary>
    public class GroupRepository : RepositoryBase<Guid, Group>, IGroupRepository
    {
        private readonly ISqlService sqlService;

        /// <summary>
        /// Table name for the group repository.
        /// </summary>
        public static string TableName => "dbo.VT_Contact_Group";

        /// <summary>
        /// Primary key column for the repository.
        /// </summary>
        public static string PrimaryKeyColumn => "Guid";

        /// <summary>
        /// Constructor for the repository.
        /// </summary>
        public GroupRepository(ISqlService sqlService) : base(sqlService)
        {
            this.sqlService = sqlService;
        }
    }
}
