using System.Collections.ObjectModel;

namespace DCS.Contact
{
    public class Contact
    {
        public Contact() { }

        public Guid Guid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsActive { get; set; }

        public ObservableCollection<Adress>? Adresses { get; set; }

        public ObservableCollection<Phone>? PhoneNumbers { get; set; }

        public ObservableCollection<Email>? EmailAdresses { get; set; }

        public ObservableCollection<Company>? Companies { get; set; }
    }
}
