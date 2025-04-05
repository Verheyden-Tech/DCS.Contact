using DCS.Data;
using DCS.CoreLib.BaseClass;
using System.Collections.ObjectModel;

namespace DCS.Contact.Data
{
    /// <summary>
    /// PhysicalAdressManagementRepository to handle physical adress data on the table.
    /// </summary>
    public class PhysicalAdressRepository : RepositoryBase<Guid, Adress>, IPhysicalAdressRepository
    {
        private ISqlService sqlService;

        /// <summary>
        /// Table name for PhysicalAdressManagementRepository.
        /// </summary>
        public static string tableName => "dbo.VT_Contact_Adress";

        /// <summary>
        /// Primary key column for PhysicalAdressManagementRepository.
        /// </summary>
        public static string primaryKeyColumn => "Guid";

        /// <summary>
        /// Constructor for PhysicalAdressManagementRepository.
        /// </summary>
        public PhysicalAdressRepository(ISqlService sqlService) : base(sqlService, tableName, primaryKeyColumn)
        {
            this.sqlService = sqlService;
        }

        /// <inheritdoc/>
        public ObservableCollection<Adress> GetAllByContact(Guid contactGuid)
        {
            var sql = $"SELECT * FROM {TableName} WHERE ContactGuid = @contactGuid";

            return sqlService.SQLQueryList<Adress>(sql, contactGuid);
        }
    }
}
