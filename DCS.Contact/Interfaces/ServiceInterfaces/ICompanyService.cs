namespace DCS.Contact
{
    /// <summary>
    /// Defines the contract for services that manage company-related operations.
    /// </summary>
    /// <remarks>This interface extends <see cref="ICompanyRepository"/>, inheriting its data access methods,
    /// and may include additional business logic specific to company management. Implementations of this interface
    /// should encapsulate the business rules and workflows related to company operations.</remarks>
    public interface ICompanyService : ICompanyRepository
    {
    }
}
