namespace ContactLibrary
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
    }
}
