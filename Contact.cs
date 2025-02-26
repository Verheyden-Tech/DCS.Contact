namespace DCS.Contact
{
    public class Contact
    {
        public Contact() { }

        public Guid Guid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? LastModificationDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public Guid UserGuid { get; set; }
    }
}
