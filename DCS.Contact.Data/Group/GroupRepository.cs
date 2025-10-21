using DCS.Data;
using DCS.CoreLib.BaseClass;

namespace DCS.Contact.Data
{
    /// <summary>
    /// Provides a repository for managing <see cref="Group"/> entities, including operations for retrieving, adding,
    /// updating, and deleting groups in the database. This repository uses a SQL-based data store.
    /// </summary>
    /// <remarks>This class extends <see cref="RepositoryBase{TKey, TEntity}"/> to provide functionality
    /// specific to <see cref="Group"/> entities. It relies on an <see cref="ISqlService"/> implementation for database
    /// interactions. The repository is configured to use the "dbo.VT_Contact_Group" table with "Guid" as the primary
    /// key column.</remarks>
    public class GroupRepository : RepositoryBase<Guid, Group>, IGroupRepository
    {
        private readonly ISqlService sqlService = CommonServiceLocator.ServiceLocator.Current.GetInstance<ISqlService>();

        /// <summary>
        /// Specifies the name of the database table associated with the contact group.
        /// </summary>
        public static readonly new string TableName = "dbo.VT_Contact_Group";

        /// <summary>
        /// Represents the name of the primary key column used in the database.
        /// </summary>
        /// <remarks>The value of this field is a constant string, "Guid", which is typically used to
        /// identify the primary key column in database tables.</remarks>
        public static readonly new string PrimaryKeyColumn = "Guid";

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupRepository"/> class with the specified SQL service.
        /// </summary>
        /// <param name="sqlService">The SQL service used to interact with the database.</param>
        public GroupRepository(ISqlService sqlService) : base(sqlService, TableName, PrimaryKeyColumn)
        {
            this.sqlService = sqlService;
        }
    }
}
