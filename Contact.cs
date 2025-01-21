namespace ContactLibrary
{
    public class Contact
    {
        public Contact() { }

        public Guid Guid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsActive { get; set; }

        public IList<Adress> Adresses { get; set; }

        public IList<Phone> PhoneNumbers { get; set; }

        public IList<Email> EmailAdresses { get; set; }

        public IList<Company> Companies { get; set; }
    }
}
