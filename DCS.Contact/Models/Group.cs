using DCS.CoreLib;
using DCS.CoreLib.BaseClass;

namespace DCS.Contact
{
    /// <summary>
    /// Group class for group assignements of contacts and users.
    /// </summary>
    public class Group : ModelBase, IEntity<Guid>
    {
        /// <summary>
        /// Default constructor for Group class.
        /// </summary>
        public Group() { }

        /// <summary>
        /// Gets or sets the description of the group.
        /// </summary>
        public string Description { get; set; }
    }
}
