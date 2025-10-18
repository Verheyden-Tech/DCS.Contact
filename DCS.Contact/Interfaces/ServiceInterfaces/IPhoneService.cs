using DCS.CoreLib;
using System.Collections.ObjectModel;

namespace DCS.Contact
{
    /// <summary>
    /// Phone Service to handle phone data on the table.
    /// </summary>
    public interface IPhoneService : IServiceBase<Guid, Phone, IPhoneRepository>
    {
    }
}
