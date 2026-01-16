using DCS.CoreLib;
using DCS.CoreLib.BaseClass;

namespace DCS.Contact
{
    /// <summary>
    /// Represents a company.
    /// </summary>
    public class Company : ModelBase, IEntity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class.
        /// </summary>
        public Company() { }

        /// <summary>
        /// Gets or sets the description of the company.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the type of the company.
        /// </summary>
        public string Type { get; set; }
    }
}
