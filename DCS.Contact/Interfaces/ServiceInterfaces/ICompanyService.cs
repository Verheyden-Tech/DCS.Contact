using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Defines the contract for operations related to managing companies.
    /// </summary>
    /// <remarks>This interface extends <see cref="IServiceBase{TKey, TEntity, TRepository}"/> to provide
    /// functionality specific to the <see cref="Company"/> entity. It serves as a blueprint for implementing business
    /// logic and data access for company-related operations.</remarks>
    public interface ICompanyService : IServiceBase<Guid, Company, ICompanyRepository>
    {
    }
}
