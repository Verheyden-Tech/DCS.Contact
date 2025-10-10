using DCS.CoreLib.BaseClass;
using DCS.User.Service;

namespace DCS.Contact.Service
{
    /// <summary>
    /// Company service to handle company data.
    /// </summary>
    public class CompanyService : ServiceBase<Guid, Company, ICompanyRepository>, ICompanyService
    {
        private readonly ICompanyRepository repository;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CompanyService(ICompanyRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Company"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public Company CreateNewCompany(string name, string type = "")
        {
            var newCompany = new Company
            {
                Guid = Guid.NewGuid(),
                Name = name,
                Type = type,
                IsActive = true
            };

            return newCompany;
        }
    }
}
