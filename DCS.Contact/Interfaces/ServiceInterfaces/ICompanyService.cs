using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Company service to handle company data.
    /// </summary>
    public interface ICompanyService : IServiceBase<Guid, Company, ICompanyRepository>
    {
        /// <summary>
        /// Creates a new instance of <see cref="Company"/>.
        /// </summary>
        /// <param name="name">Company name.</param>
        /// <param name="type">Company type.</param>
        /// <returns>New instance of <see cref="Company"/>.</returns>
        Company CreateNewCompany(string name, string type = "");
    }
}
