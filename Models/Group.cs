namespace DCS.Contact
{
    public class Group
    {
        public Group() { }

        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public Guid UserGuid { get; set; }

        public Guid CompanyGuid { get; set; }
    }
}
