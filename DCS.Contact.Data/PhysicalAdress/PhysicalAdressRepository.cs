using DCS.CoreLib.BaseClass;
using DCS.Data;

namespace DCS.Contact.Data
{
    /// <summary>
    /// Provides data access functionality for managing physical addresses in the database.
    /// </summary>
    /// <remarks>This repository is responsible for interacting with the <see cref="TableName"/> table in the
    /// database. It uses the specified <see cref="ISqlService"/> to perform operations such as querying, inserting,
    /// updating, and deleting records. The repository is initialized with the table name <c>dbo.VT_Contact_Adress</c>
    /// and the primary key column <c>Guid</c>.</remarks>
    public class PhysicalAdressRepository : RepositoryBase<Guid, Adress>, IPhysicalAdressRepository
    {
        private ISqlService sqlService = CommonServiceLocator.ServiceLocator.Current.GetInstance<ISqlService>();

        /// <summary>
        /// Specifies the name of the database table associated with contact addresses.
        /// </summary>
        /// <remarks>This field represents the fully qualified name of the table, including the
        /// schema.</remarks>
        public static readonly new string TableName = "dbo.VT_Contact_Adress";

        /// <summary>
        /// Represents the name of the primary key column used in the database.
        /// </summary>
        public static readonly new string PrimaryKeyColumn = "Guid";

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicalAdressRepository"/> class with the specified SQL
        /// service.
        /// </summary>
        /// <param name="sqlService">The SQL service used to interact with the database.</param>
        public PhysicalAdressRepository(ISqlService sqlService) : base(sqlService, TableName, PrimaryKeyColumn)
        {
            this.sqlService = sqlService;
        }
    }
}
