namespace DCS.Contact
{
    public class Adress
    {
        public Adress() { }

        public Guid Guid { get; set; }

        public string StreetName { get; set; }

        public int HouseNumber { get; set; }

        public string AdressAddon { get; set; }

        public string City { get; set; }

        public int PostalCode { get; set; }

        public string Country { get; set; }

        public Guid UserGuid { get; set; }

        public Guid? ContactGuid { get; set; }

        public Guid? CompanyGuid { get; set; }
    }
}
