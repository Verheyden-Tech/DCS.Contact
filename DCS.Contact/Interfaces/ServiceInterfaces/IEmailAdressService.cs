using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// EmailAdressService to manipulate emailadress data.
    /// </summary>
    public interface IEmailAdressService : IServiceBase<Guid, Email, IEmailAdressRepository>
    {
    }
}
