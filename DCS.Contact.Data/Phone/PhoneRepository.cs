using DCS.CoreLib.BaseClass;
using DCS.Data;

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
        public static readonly new string TableName = "dbo.VT_Contact_Phone";

        /// <summary>
        /// Primary key column for PhoneManagementRepository.
        /// </summary>
        public static readonly new string PrimaryKeyColumn = "Guid";

        /// <summary>
        /// Constructor for PhoneManagementRepository.
        /// </summary>
        public PhoneRepository(ISqlService sqlService) : base(sqlService, TableName, PrimaryKeyColumn)
        {
            this.sqlService = sqlService;
        }
    }
}
