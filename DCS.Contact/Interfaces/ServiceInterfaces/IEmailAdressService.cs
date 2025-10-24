namespace DCS.Contact
{
    /// <summary>
    /// Defines methods for managing and validating email addresses.
    /// </summary>
    /// <remarks>This interface extends <see cref="IEmailAdressRepository"/> to provide additional
    /// functionality  for handling email address-related operations. Implementations may include features such as 
    /// email validation, formatting, or domain-specific logic.</remarks>
    public interface IEmailAdressService : IEmailAdressRepository
    {
    }
}
