using DCS.DefaultTemplates;
using DCS.User;

namespace DCS.Contact.Services
{
    /// <summary>
    /// Company service to handle company data.
    /// </summary>
    public class CompanyService : IServiceBase<Company, ICompanyManagementRepository>, ICompanyService
    {
        private Company model;

        /// <summary>
        /// Model of the company.
        /// </summary>
        public Company Model => model;

        /// <summary>
        /// Repository for company management.
        /// </summary>
        public ICompanyManagementRepository repository => CommonServiceLocator.ServiceLocator.Current.GetInstance<ICompanyManagementRepository>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CompanyService()
        {
            
        }

        /// <summary>
        /// Constructor with company model.
        /// </summary>
        /// <param name="company"></param>
        public CompanyService(Company company) : this()
        {
            this.model = company;
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

        /// <summary>
        /// Get company by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Company Get(Company guid)
        {
            return repository.Get(guid);
        }

        /// <summary>
        /// Get all companies.
        /// </summary>
        /// <returns></returns>
        public DefaultCollection<Company> GetAll()
        {
            return repository.GetAll();
        }

        /// <summary>
        /// Create a new company.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool New(Company obj)
        {
            return repository.New(obj);
        }

        /// <summary>
        /// Update company.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Update(Company obj)
        {
            return repository.Update(obj);
        }

        /// <summary>
        /// Delete company by guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool Delete(Guid guid)
        {
            return repository.Delete(guid);
        }
    }
}
