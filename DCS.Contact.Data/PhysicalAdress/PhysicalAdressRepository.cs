using DCS.CoreLib.BaseClass;
using DCS.Data;

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
        public static readonly new string TableName = "dbo.VT_Contact_Adress";

        /// <summary>
        /// Primary key column for PhysicalAdressManagementRepository.
        /// </summary>
        public static readonly new string PrimaryKeyColumn = "Guid";

        /// <summary>
        /// Constructor for PhysicalAdressManagementRepository.
        /// </summary>
        public PhysicalAdressRepository(ISqlService sqlService) : base(sqlService, TableName, PrimaryKeyColumn)
        {
            this.sqlService = sqlService;
        }
    }
}
