using DCS.DefaultTemplates;
using DCS.User;

namespace DCS.Contact.Services
{
    /// <summary>
    /// Service for group data management on the table.
    /// </summary>
    public class GroupService : IServiceBase<Group, IGroupManagementRepository>, IGroupService
    {
        private Group model;

        /// <summary>
        /// Repository for group data management on the table.
        /// </summary>
        public IGroupManagementRepository Repository => CommonServiceLocator.ServiceLocator.Current.GetInstance<IGroupManagementRepository>();

        /// <summary>
        /// Model for group data.
        /// </summary>
        public Group Model => model;

        /// <summary>
        /// Constructor for group service.
        /// </summary>
        public GroupService()
        {
            
        }

        /// <summary>
        /// Constructor for group service.
        /// </summary>
        /// <param name="group"></param>
        public GroupService(Group group) : this()
        {
            this.model = group;
        }

        /// <summary>
        /// Deletes a group.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool Delete(Guid guid)
        {
            return Repository.Delete(guid);
        }

        /// <summary>
        /// Gets a group.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public Group Get(Guid guid)
        {
            return Repository.Get(guid);
        }

        /// <summary>
        /// Gets all groups.
        /// </summary>
        /// <returns></returns>
        public DefaultCollection<Group> GetAll()
        {
            return Repository.GetAll();
        }

        /// <summary>
        /// Creates a new group.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool New(Group obj)
        {
            return Repository.New(obj);
        }

        /// <summary>
        /// Updates a group.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(Group obj)
        {
            return Repository.Update(obj);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Group"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="companyGuid"></param>
        /// <param name="description"></param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        public Group CreateNewGroup(string name, Guid companyGuid, string description = "", bool isActive = true)
        {
            var newGroup = new Group
            {
                Guid = Guid.NewGuid(),
                Name = name,
                Description = description,
                IsActive = isActive,
                UserGuid = CurrentUserService.Instance.CurrentUser.Guid,
                CompanyGuid = companyGuid
            };

            return newGroup;
        }
    }
}
