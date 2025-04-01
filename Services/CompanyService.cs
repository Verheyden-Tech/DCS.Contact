using DCS.Contact.DataDB;
using DCS.DefaultTemplates;
using DCS.User;

namespace DCS.Contact.Services
{
    /// <summary>
    /// Company service to handle company data.
    /// </summary>
    public class CompanyService : ServiceBase<Guid, Company, ICompanyManagementRepository>, ICompanyService
    {
        private readonly ICompanyManagementRepository repository;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CompanyService(ICompanyManagementRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Company"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="isActive"></param>
        /// <param name="companyContact"></param>
        /// <param name="contactGuid"></param>
        /// <returns></returns>
        public Company CreateNewCompany(string name, string type = "", bool isActive = true, Guid? companyContact = null, Guid? contactGuid = null)
        {
            var newCompany = new Company
            {
                Guid = Guid.NewGuid(),
                Name = name,
                Type = type,
                IsActive = isActive,
                UserGuid = CurrentUserService.Instance.CurrentUser.Guid,
                ContactGuid = contactGuid,
                CompanyContact = companyContact
            };

            return newCompany;
        }
    }
}
