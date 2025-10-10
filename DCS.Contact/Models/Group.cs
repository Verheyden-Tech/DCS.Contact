namespace DCS.Contact
{
    /// <summary>
    /// Group class for group assignements of contacts and users.
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Default constructor for Group class.
        /// </summary>
        public Group() { }

        /// <summary>
        /// Gets or sets the Guid of the group.
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the group.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Indicates wether the group is active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
