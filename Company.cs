namespace DCS.Contact
{
    public class Company
    {
        public Company() { }

        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
        public bool IsActive { get; set; }

        public Guid? CompanyContact { get; set; }

        public Guid? ContactGuid { get; set; }

        public Guid UserGuid { get; set; }
    }
}
