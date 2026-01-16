using DCS.CoreLib;
using DCS.CoreLib.BaseClass;

namespace DCS.Contact
{
    /// <summary>
    /// Phone class model for phone number data on the table.
    /// </summary>
    public class Phone : ModelBase, IEntity<Guid>
    {
        /// <summary>
        /// Constructor for the Phone class.
        /// </summary>
        public Phone() { }

        /// <summary>
        /// Gets or sets the type of the phone number.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
