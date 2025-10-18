using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Service for group data management on the table.
    /// </summary>
    public interface IGroupService : IServiceBase<Guid, Group, IGroupRepository>
    {
    }
}
