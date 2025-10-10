using DCS.CoreLib;
using System.Collections.ObjectModel;

namespace DCS.Contact
{
    /// <summary>
    /// Phone Service to handle phone data on the table.
    /// </summary>
    public interface IPhoneService : IServiceBase<Guid, Phone, IPhoneRepository>
    {
        /// <summary>
        /// Creates a new instance of <see cref="Phone"/>.
        /// </summary>
        /// <param name="phoneNumber">Contact phonenumber.</param>
        /// <param name="type">Phonenumber type.</param>
        /// <returns>New instance of <see cref="Phone"/>.</returns>
        Phone CreateNewPhone(string phoneNumber, string type = "");
    }
}
