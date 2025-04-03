using DCS.Data;
using DCS.CoreLib.BaseClass;
using System.Collections.ObjectModel;

namespace DCS.Contact.Data
{
    /// <summary>
    /// Phone Management Repository to handle phone data on the table.
    /// </summary>
    public class PhoneRepository : RepositoryBase<Guid, Phone>, IPhoneRepository
    {
        private readonly ISqlService sqlService;

        /// <summary>
        /// Table name for PhoneManagementRepository.
        /// </summary>
        public static string TableName => "dbo.PhoneData";

        /// <summary>
        /// Primary key column for PhoneManagementRepository.
        /// </summary>
        public static string PrimaryKeyColumn => "Guid";

        /// <summary>
        /// Constructor for PhoneManagementRepository.
        /// </summary>
        public PhoneRepository(ISqlService sqlService) : base(sqlService)
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
