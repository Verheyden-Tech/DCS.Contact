namespace DCS.Contact
{
    public class Email
    {
        public Email() { }

        public Guid Guid { get; set; }

        public string Type { get; set; }

        public string MailAddress { get; set; }

        public bool IsActive { get; set; }

        public Guid UserGuid { get; set; }

        public Guid? ContactGuid { get; set; }

        public Guid? CompanyGuid { get; set; }
    }
}
