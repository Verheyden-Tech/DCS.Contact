using DCS.DefaultTemplates;

namespace DCS.Contact
{
    /// <summary>
    /// Service for group data management on the table.
    /// </summary>
    public interface IGroupService : IServiceBase<Group, IGroupManagementRepository>
    {
        /// <summary>
        /// Creates a new instance of <see cref="Group"/>.
        /// </summary>
        /// <param name="name">Group name.</param>
        /// <param name="companyGuid">Company group is assigned to.</param>
        /// <param name="description">Company description.</param>
        /// <param name="isActive">Company is active flag.</param>
        /// <returns>New instance of <see cref="Group"/>.</returns>
        Group CreateNewGroup(string name, Guid companyGuid, string description = "", bool isActive = true);
    }
}
