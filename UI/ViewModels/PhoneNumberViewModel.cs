using DCS.DefaultTemplates;
using DCS.Contact;
using DCS.User;
using System.Security.Cryptography;
using DCSBase.Services.Interfaces;

namespace DCSBase.Contacts
{
    public class PhoneNumberViewModel : ViewModelBase<Phone>
    {
        private IPhoneService phoneService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhoneService>();

        public PhoneNumberViewModel()
        {
            Collection = new DefaultCollection<Phone>();
        }

        public PhoneNumberViewModel(Phone phone) : this()
        {
            this.Model = phone;
        }

        public PhoneNumberViewModel(Contact contact) : this()
        {
            this.SelectedContact = contact;

            if (Model == null)
            {
                Model = new Phone() { ContactGuid = contact.Guid, UserGuid = CurrentUserService.Instance.CurrentUser.Guid };
            }

            this.Collection = phoneService.GetAll();

            if (Model != null)
            {
                if (Collection != null && Collection.Count > 0)
                {
                    Model = Collection.First();
                }
                else
                {
                    Model = new Phone();
                }
            }
        }

        public DefaultCollection<Phone> GetContactPhoneNumbers(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException("contact");

            return phoneService.GetAllByContact(contact.Guid);
        }
        
        public bool New(Phone newPhone)
        {
            return phoneService.New(newPhone);
        }

        public bool AddNewPhoneNumber(Contact contact, Phone phone)
        {
            if(SelectedContact == contact && phone != null)
            {
                this.Collection.Add(phone);
                if(SavePhoneNumbers(PhoneNumbers))
                {
                    return true;
                }
            }
            return false;
        }

        public bool SavePhoneNumbers(DefaultCollection<Phone> phoneNumbers)
        {
            if (phoneNumbers != null)
            {
                foreach (var phone in phoneNumbers)
                {
                    phoneService.Update(phone);
                }
                return true;
            }
            return false;
        }

        public Guid Guid
        {
            get => Model.Guid;
            set => Model.Guid = value;
        }

        public string PhoneNumber
        {
            get => Model.PhoneNumber;
            set => Model.PhoneNumber = value;
        }

        public string Type
        {
            get => Model.Type;
            set => Model.Type = value;
        }

        public DefaultCollection<Phone> PhoneNumbers
        {
            get => this.Collection;
            set => this.Collection = value;
        }

        public Contact SelectedContact { get; set; }
    }
}
