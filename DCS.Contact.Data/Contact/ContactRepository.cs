using DCS.CoreLib.BaseClass;
using DCS.Data;

namespace DCS.Contact.Data
{
    /// <summary>
    /// Provides a repository for managing contact data, including operations for retrieving, updating, and deleting
    /// contacts.
    /// </summary>
    /// <remarks>This repository is built on top of the <see cref="RepositoryBase{TKey, TEntity}"/> class and
    /// is tailored for managing contact entities identified by a <see cref="Guid"/> key. It uses the specified SQL
    /// service to interact with the database.</remarks>
    public class ContactRepository : RepositoryBase<Guid, Contact>, IContactRepository
    {
        private readonly ISqlService sqlService = CommonServiceLocator.ServiceLocator.Current.GetInstance<ISqlService>();

        /// <summary>
        /// Table name for the contact data.
        /// </summary>
        public static readonly new string TableName = "dbo.VT_Contact";

        /// <summary>
        /// Primary key column for the contact data.
        /// </summary>
        public static readonly new string PrimaryKeyColumn = "Guid";

        /// <summary>
        /// Constructor for the contact management repository.
        /// </summary>
        public ContactRepository(ISqlService sqlService) : base(sqlService, TableName, PrimaryKeyColumn)
        {
            this.sqlService = sqlService;
        }
    }
}
