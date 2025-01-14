namespace ContactLibrary
{
    public class Group
    {
        public Group() { }

        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
