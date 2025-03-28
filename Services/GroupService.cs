using DCS.Contact;
using DCS.DefaultTemplates;
using DCSBase.DataDB.Interfaces;
using DCSBase.Services.Interfaces;

namespace DCSBase.Services
{
    public class GroupService : IServiceBase<Group, IGroupManagementRepository>, IGroupService
    {
        private Group model;

        public IGroupManagementRepository Repository => CommonServiceLocator.ServiceLocator.Current.GetInstance<IGroupManagementRepository>();

        public Group Model => model;

        public GroupService()
        {
            
        }

        public GroupService(Group group) : this()
        {
            this.model = group;
        }

        public bool Delete(Guid guid)
        {
            return Repository.Delete(guid);
        }

        public Group Get(Guid guid)
        {
            return Repository.Get(guid);
        }

        public DefaultCollection<Group> GetAll()
        {
            return Repository.GetAll();
        }

        public bool New(Group obj)
        {
            return Repository.New(obj);
        }

        public bool Update(Group obj)
        {
            return Repository.Update(obj);
        }

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
