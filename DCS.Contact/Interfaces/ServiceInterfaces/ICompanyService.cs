using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Company service to handle company data.
    /// </summary>
    public interface ICompanyService : IServiceBase<Guid, Company, ICompanyRepository>
    {
    }
}
