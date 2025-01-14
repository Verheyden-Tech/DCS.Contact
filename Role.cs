namespace ContactLibrary
{
    public class Role
    {
        public Role() { }

        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsActive { get; set; }
    }
}
