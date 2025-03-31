using DCS.DefaultTemplates;
using DCS.SQLService;
using System.Collections.ObjectModel;

namespace DCS.Contact.DataDB
{
    /// <summary>
    /// Phone Management Repository to handle phone data on the table.
    /// </summary>
    public class PhoneManagementRepository : RepositoryBase<Guid, Phone>, IPhoneManagementRepository
    {
        private readonly ISqlService sqlService;

        /// <summary>
        /// Table name for PhoneManagementRepository.
        /// </summary>
        public override string TableName => "dbo.PhoneData";

        /// <summary>
        /// Primary key column for PhoneManagementRepository.
        /// </summary>
        public override string PrimaryKeyColumn => "Guid";

        /// <summary>
        /// Constructor for PhoneManagementRepository.
        /// </summary>
        public PhoneManagementRepository(ISqlService sqlService) : base(sqlService)
        {
            this.sqlService = sqlService;
        }

        /// <inheritdoc/>
        public ObservableCollection<Phone> GetAllByContact(Guid contactGuid)
        {
            var sql = $"SELECT * FROM {TableName} WHERE ContactGuid = @guid";

            return sqlService.SQLQueryList<Phone>(sql, new { guid = contactGuid });
        }
    }
}
