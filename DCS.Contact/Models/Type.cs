namespace DCS.Contact
{
    /// <summary>
    /// Represents a type of an object with a unique identifier, a name, and an active status.
    /// </summary>
    /// <remarks>This class provides a structure for defining an entity with a globally unique identifier
    /// (GUID), a descriptive name, and a boolean flag indicating whether the entity is active.</remarks>
    public class Type
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Type"/> class.
        /// </summary>
        public Type() { }

        /// <summary>
        /// Gets or sets the unique identifier for the type.
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets the name for the type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the type is currently active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
