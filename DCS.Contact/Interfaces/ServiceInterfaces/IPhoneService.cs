namespace DCS.Contact
{
    /// <summary>
    /// Defines the contract for managing phone entities, including operations for retrieving, creating, updating, and
    /// deleting phones.
    /// </summary>
    /// <remarks>This interface extends <see cref="IPhoneRepository"/> with <see
    /// cref="Guid"/> as the key type and <see cref="Phone"/> as the entity type.</remarks>
    public interface IPhoneService : IPhoneRepository
    {
    }
}
