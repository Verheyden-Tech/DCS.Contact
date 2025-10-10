using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Service for group data management on the table.
    /// </summary>
    public interface IGroupService : IServiceBase<Guid, Group, IGroupRepository>
    {
        /// <summary>
        /// Creates a new instance of <see cref="Group"/>.
        /// </summary>
        /// <param name="name">Group name.</param>
        /// <param name="companyGuid">Company group is assigned to.</param>
        /// <param name="description">Company description.</param>
        /// <returns>New instance of <see cref="Group"/>.</returns>
        Group CreateNewGroup(string name, Guid companyGuid, string description = "");
    }
}
