using DCS.CoreLib.BaseClass;
using DCS.Data;

namespace DCS.Contact.Data
{
    /// <summary>
    /// Provides a repository for managing <see cref="ContactAssignement"/> entities, enabling database operations such
    /// as retrieval, insertion, updating, and deletion.
    /// </summary>
    /// <remarks>This repository is specifically configured to operate on the database table defined by the
    /// <c>TableName</c> constant (<c>VT_Contact_Assignement</c>) and uses the column defined by the
    /// <c>PrimaryKeyColumn</c> constant (<c>Guid</c>) as the primary key. It leverages the provided <see
    /// cref="ISqlService"/> to perform SQL-based operations.</remarks>
    public class ContactAssignementRepository : RepositoryBase<Guid, ContactAssignement>, IContactAssignementRepository
    {
        private readonly ISqlService sqlService = CommonServiceLocator.ServiceLocator.Current.GetInstance<ISqlService>();

        /// <summary>
        /// Represents the name of the database table used for contact assignments.
        /// </summary>
        /// <remarks>This field is a constant string that specifies the table name
        /// "VT_Contact_Assignement". It is intended for use in database operations where the table name is
        /// required.</remarks>
        private static readonly new string TableName = "VT_Contact_Assignement";

        /// <summary>
        /// Represents the name of the primary key column used in the database.
        /// </summary>
        /// <remarks>This field is set to "Guid" by default and is intended to be used as the identifier
        /// for primary key operations.</remarks>
        private static readonly new string PrimaryKeyColumn = "Guid";

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactAssignementRepository"/> class,  providing access to the
        /// specified SQL service for database operations.
        /// </summary>
        /// <remarks>This repository is configured to operate on the table specified by the
        /// <c>TableName</c> constant  and uses the column specified by the <c>PrimaryKeyColumn</c> constant as the
        /// primary key.</remarks>
        /// <param name="sqlService">The SQL service used to interact with the database. This parameter cannot be <see langword="null"/>.</param>
        public ContactAssignementRepository(ISqlService sqlService) : base(sqlService, TableName, PrimaryKeyColumn)
        {
            this.sqlService = sqlService;
        }
    }
}
