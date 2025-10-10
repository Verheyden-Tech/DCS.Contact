using DCS.CoreLib.BaseClass;
using DCS.User.Service;

namespace DCS.Contact.Service
{
    /// <summary>
    /// Service for group data management on the table.
    /// </summary>
    public class GroupService : ServiceBase<Guid, Group, IGroupRepository>, IGroupService
    {
        /// <summary>
        /// Repository for group data management on the table.
        /// </summary>
        private IGroupRepository repository;

        /// <summary>
        /// Default constructor for <see cref="GroupService"/> class.
        /// </summary>
        /// <param name="repository"><see cref="IGroupRepository"/> interface.</param>
        public GroupService(IGroupRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        /// <inheritDoc/>
        public Group CreateNewGroup(string name, Guid companyGuid, string description = "")
        {
            var newGroup = new Group
            {
                Guid = Guid.NewGuid(),
                Name = name,
                Description = description,
                IsActive = true
            };

            return newGroup;
        }
    }
}
