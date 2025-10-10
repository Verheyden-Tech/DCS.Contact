namespace DCS.Contact
{
    /// <summary>
    /// Represents a role for users in the system.
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Role"/> class.
        /// </summary>
        public Role() { }

        /// <summary>
        /// Gets or sets the unique identifier for the role.
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the role.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the role is active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
