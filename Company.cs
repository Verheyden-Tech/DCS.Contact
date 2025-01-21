namespace DCS.Contact
{
    public class Company
    {
        public Company() { }

        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public Adress Adress { get; set; }

        public Phone Phone { get; set; }

        public Email Email { get; set; }

        public Guid? CompanyContact { get; set; }

        public Guid UserGuid { get; set; }

        public Guid? CompanyGuid { get; set; }
    }
}
