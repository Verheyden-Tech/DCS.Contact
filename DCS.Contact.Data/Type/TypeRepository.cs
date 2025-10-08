using DCS.CoreLib.BaseClass;
using DCS.Data;

namespace DCS.Contact.Data
{
    /// <summary>
    /// Provides data access functionality for managing <see cref="Type"/> entities in the database.
    /// </summary>
    /// <remarks>This repository is designed to interact with the database table <c>VT_Contact_Type</c>, using
    /// <see cref="Guid"/> as the primary key. It leverages the provided <see cref="ISqlService"/> to execute database
    /// operations.</remarks>
    public class TypeRepository : RepositoryBase<Guid, Type>, ITypeRepository
    {
        private readonly ISqlService sqlService = CommonServiceLocator.ServiceLocator.Current.GetInstance<ISqlService>();

        private static readonly new string TableName = "VT_Contact_Type";
        private static readonly new string PrimaryKeyColumn = "Guid";

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeRepository"/> class with the specified SQL service.
        /// </summary>
        /// <param name="sqlService">The SQL service used to interact with the database. This service is required for executing queries and
        /// managing data operations.</param>
        public TypeRepository(ISqlService sqlService) : base(sqlService, TableName, PrimaryKeyColumn)
        {
            this.sqlService = sqlService;
        }
    }
}
