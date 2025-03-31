using DCS.DefaultTemplates;
using DCS.SQLService;
using System.Collections.ObjectModel;

namespace DCS.Contact.DataDB
{
    /// <summary>
    /// Repository for email data management on the table.
    /// </summary>
    public class EmailManagementRepository : RepositoryBase<Guid, Email>, IEmailAdressManagementRepository
    {
        private readonly ISqlService sqlService;

        /// <summary>
        /// Table name for the repository.
        /// </summary>
        public override string TableName => "dbo.EmailData";

        /// <summary>
        /// Primary key column for the repository.
        /// </summary>
        public override string PrimaryKeyColumn => "Guid";

        /// <summary>
        /// Constructor for the repository.
        /// </summary>
        public EmailManagementRepository(ISqlService sqlService) : base(sqlService)
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
