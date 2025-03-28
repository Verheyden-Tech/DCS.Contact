using DCS.Contact;
using DCS.DefaultTemplates;
using DCSBase.DataDB.Interfaces;

namespace DCSBase.Services.Interfaces
{
    public interface IPhoneService : IServiceBase<Phone, IPhoneManagementRepository>
    {
        /// <summary>
        /// Creates a new instance of <see cref="Phone"/>.
        /// </summary>
        /// <param name="phoneNumber">Contact phonenumber.</param>
        /// <param name="type">Phonenumber type.</param>
        /// <param name="isActive">Phonenumber is active flag.</param>
        /// <param name="contactGuid">Contact phonenumber is assigned to.</param>
        /// <param name="companyGuid">Company phonenumber is assigned to.</param>
        /// <returns>New instance of <see cref="Phone"/>.</returns>
        Phone CreateNewPhone(string phoneNumber, string type = "", bool isActive = true, Guid? contactGuid = null, Guid? companyGuid = null);

        DefaultCollection<Phone> GetAllByContact(Guid contactGuid);
    }
}
