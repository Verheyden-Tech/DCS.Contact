namespace DCS.Contact
{
    /// <summary>
    /// Defines a service for managing contact-related operations, extending the functionality of <see
    /// cref="IContactRepository"/>.
    /// </summary>
    /// <remarks>This interface serves as a contract for implementing higher-level contact management features
    /// that build upon the basic repository operations provided by <see cref="IContactRepository"/>.</remarks>
    public interface IContactService : IContactRepository
    {
    }
}
