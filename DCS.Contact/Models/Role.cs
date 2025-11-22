using DCS.CoreLib.BaseClass;

namespace DCS.Contact
{
    /// <summary>
    /// Represents a user role with a unique identifier and description.
    /// </summary>
    public class Role : ModelBase<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Role"/> class.
        /// </summary>
        public Role() { }

        /// <summary>
        /// Gets or sets the description of the role.
        /// </summary>
        public string Description { get; set; }
    }
}
