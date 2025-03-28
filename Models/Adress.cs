namespace DCS.Contact
{
    public class Adress
    {
        public Adress() { }

        public Guid Guid { get; set; }

        public string StreetName { get; set; }

        public string HouseNumber { get; set; }

        public string AdressAddon { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public bool IsActive { get; set; }

        public Guid UserGuid { get; set; }

        public Guid? ContactGuid { get; set; }

        public Guid? CompanyGuid { get; set; }
    }
}
