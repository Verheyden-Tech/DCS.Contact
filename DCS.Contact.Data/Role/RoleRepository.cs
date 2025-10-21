using DCS.Data;
using DCS.CoreLib.BaseClass;

namespace DCS.Contact.Data
{
    /// <summary>
    /// Provides data access functionality for managing roles in the system.
    /// </summary>
    /// <remarks>This repository is responsible for interacting with the database table <see
    /// cref="TableName"/>  and performing operations related to roles. It uses the specified SQL service for database
    /// communication.</remarks>
    public class RoleRepository : RepositoryBase<Guid, Role>, IRoleRepository
    {
        private ISqlService sqlService = CommonServiceLocator.ServiceLocator.Current.GetInstance<ISqlService>();

        /// <summary>
        /// Represents the name of the database table associated with the contact role entity.
        /// </summary>
        public static readonly new string TableName = "dbo.VT_Contact_Role";

        /// <summary>
        /// Represents the name of the primary key column used in the database.
        /// </summary>
        public static readonly new string PrimaryKeyColumn = "Guid";

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepository"/> class, providing access to role-related data
        /// operations.
        /// </summary>
        /// <param name="sqlService">The SQL service used to interact with the database. This parameter cannot be null.</param>
        public RoleRepository(ISqlService sqlService) : base(sqlService, TableName, PrimaryKeyColumn)
        {
            this.sqlService = sqlService;
        }
    }
}
