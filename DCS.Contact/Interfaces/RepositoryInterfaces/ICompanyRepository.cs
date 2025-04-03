using DCS.DefaultTemplates;

namespace DCS.Contact
{
    /// <summary>
    /// Company management repository to handle company data on the table.
    /// </summary>
    public interface ICompanyRepository : IRepositoryBase<Guid, Company>
    {
    }
}
