namespace DCS.Contact
{
    public class Phone
    {
        public Phone() { }

        public Guid Guid { get; set; }

        public string Type { get; set; }

        public int PhoneNumber { get; set; }

        public Guid UserGuid { get; set; }

        public Guid? ContactGuid { get; set; }

        public Guid? CompanyGuid { get; set; }
    }
}
