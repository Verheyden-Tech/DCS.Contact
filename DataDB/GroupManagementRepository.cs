using DCS.DefaultTemplates;
using DCS.SQLService;

namespace DCS.Contact.DataDB
{
    /// <summary>
    /// Repository for group data management on the table.
    /// </summary>
    public class GroupManagementRepository : RepositoryBase<Guid, Group>, IGroupManagementRepository
    {
        private readonly ISqlService sqlService;

        /// <summary>
        /// Table name for the group repository.
        /// </summary>
        public override string TableName => "dbo.GroupData";

        /// <summary>
        /// Primary key column for the repository.
        /// </summary>
        public override string PrimaryKeyColumn => "Guid";

        /// <summary>
        /// Constructor for the repository.
        /// </summary>
        public GroupManagementRepository(ISqlService sqlService) : base(sqlService)
        {
            this.sqlService = sqlService;
        }
    }
}
