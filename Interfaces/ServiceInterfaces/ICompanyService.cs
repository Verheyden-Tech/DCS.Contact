using DCS.DefaultTemplates;

namespace DCS.Contact
{
    /// <summary>
    /// Company service to handle company data.
    /// </summary>
    public interface ICompanyService : IServiceBase<Guid, Company, ICompanyManagementRepository>
    {
        /// <summary>
        /// Creates a new instance of <see cref="Company"/>.
        /// </summary>
        /// <param name="name">Company name.</param>
        /// <param name="type">Company type.</param>
        /// <param name="isActive">Company active flag.</param>
        /// <param name="companyContact"></param>
        /// <param name="contactGuid"></param>
        /// <returns>New instance of <see cref="Company"/>.</returns>
        Company CreateNewCompany(string name, string type = "", bool isActive = true, Guid? companyContact = null, Guid? contactGuid = null);
    }
}
