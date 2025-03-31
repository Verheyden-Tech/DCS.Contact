using DCS.DefaultTemplates;
using DCS.SQLService;
using System.Collections.ObjectModel;

namespace DCS.Contact.DataDB
{
    /// <summary>
    /// PhysicalAdressManagementRepository to handle physical adress data on the table.
    /// </summary>
    public class PhysicalAdressManagementRepository : RepositoryBase<Guid, Adress>, IPhysicalAdressManagementRepository
    {
        private ISqlService sqlService;

        /// <summary>
        /// Table name for PhysicalAdressManagementRepository.
        /// </summary>
        public override string TableName => "dbo.AdressData";

        /// <summary>
        /// Primary key column for PhysicalAdressManagementRepository.
        /// </summary>
        public override string PrimaryKeyColumn => "Guid";

        /// <summary>
        /// Constructor for PhysicalAdressManagementRepository.
        /// </summary>
        public PhysicalAdressManagementRepository(ISqlService sqlService) : base(sqlService)
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
