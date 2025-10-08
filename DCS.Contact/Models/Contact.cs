namespace DCS.Contact
{
    /// <summary>
    /// Represents a contact.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        public Contact() { }

        /// <summary>
        /// Gets or sets the unique identifier of the contact.
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets the first name of the contact.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the contact.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Indicates whether the contact is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date of creation of the contact.
        /// </summary>
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the date of the last modification of the contact.
        /// </summary>
        public DateTime? LastModificationDate { get; set; }

        /// <summary>
        /// Gets or sets the date of deletion of the contact.
        /// </summary>
        public DateTime? DeleteDate { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the user who created the contact.
        /// </summary>
        public Guid UserGuid { get; set; }

        /// <summary>
        /// Gets or sets the file path to the contact's profile picture.
        /// </summary>
        public string? ProfilePicturePath { get; set; }
    }
}
