using DCS.Data;
using DCS.CoreLib.BaseClass;
using System.Collections.ObjectModel;

namespace DCS.Contact.Data
{
    /// <summary>
    /// Repository for email data management on the table.
    /// </summary>
    public class EmailRepository : RepositoryBase<Guid, Email>, IEmailAdressRepository
    {
        private readonly ISqlService sqlService;

        /// <summary>
        /// Table name for the repository.
        /// </summary>
        public static string TableName => "dbo.VT_Contact_Email";

        /// <summary>
        /// Primary key column for the repository.
        /// </summary>
        public static string PrimaryKeyColumn => "Guid";

        /// <summary>
        /// Constructor for the repository.
        /// </summary>
        public EmailRepository(ISqlService sqlService) : base(sqlService)
        {
            this.sqlService = sqlService;
        }

        /// <inheritdoc/>
        public ObservableCollection<Email> GetAllByContact(Guid contactGuid)
        {
            var sql = $"SELECT * FROM {TableName} WHERE ContactGuid = @guid";

            return sqlService.SQLQueryList<Email>(sql, new { guid = contactGuid });
        }

        /// <inheritdoc/>
        public ObservableCollection<Email> GetAllByUser(Guid userGuid)
        {
            var sql = $"SELECT * FROM {TableName} WHERE UserGuid = @guid";

            return sqlService.SQLQueryList<Email>(sql, new { guid = userGuid });
        }
    }
}
