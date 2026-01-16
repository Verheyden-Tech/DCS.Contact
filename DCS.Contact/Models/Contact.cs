using DCS.CoreLib;
using DCS.CoreLib.BaseClass;

namespace DCS.Contact
{
    /// <summary>
    /// Represents a contact.
    /// </summary>
    public class Contact : ModelBase, IEntity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        public Contact() { }

        /// <summary>
        /// Gets or sets the first name of the contact.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the contact.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the date of creation of the contact.
        /// </summary>
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the date of the last modification of the contact.
        /// </summary>
        public DateTime? LastModificationDate { get; set; }

        /// <summary>
        /// Gets or sets the date of deletion mark of the contact.
        /// </summary>
        public DateTime? DeleteDate { get; set; }

        /// <summary>
        /// Gets or sets the file path to the contact's profile picture.
        /// </summary>
        public string? ProfilePicturePath { get; set; }
    }
}
