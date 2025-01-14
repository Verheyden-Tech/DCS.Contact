namespace ContactLibrary
{
    public class Contact
    {
        public Contact() { }

        public Guid Guid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsActive { get; set; }

        public Adress Adress { get; set; }

        public Phone Phone { get; set; }

        public Email Email { get; set; }

        public Company Company { get; set; }
    }
}
