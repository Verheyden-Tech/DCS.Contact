namespace DCS.Contact
{
    /// <summary>
    /// Represents the assignment of various identifiers associated with a contact,  including their address, email,
    /// company, phone, group, and role.
    /// </summary>
    /// <remarks>This class serves as a container for linking a contact to multiple related entities  through
    /// their respective unique identifiers. Each property corresponds to a specific  entity or attribute associated
    /// with the contact.</remarks>
    public class ContactAssignement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactAssignement"/> class.
        /// </summary>
        public ContactAssignement() { }

        /// <summary>
        /// Gets or sets the unique identifier for the object.
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the contact.
        /// </summary>
        public Guid ContactGuid { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier associated with the address.
        /// </summary>
        public Guid? AdressGuid { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier associated with an email, if available.
        /// </summary>
        public Guid? EmailGuid { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the company.
        /// </summary>
        public Guid? CompanyGuid { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier associated with a phone.
        /// </summary>
        public Guid? PhoneGuid { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the group.
        /// </summary>
        public Guid? GroupGuid { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the role.
        /// </summary>
        public Guid? RoleGuid { get; set; }
    }
}
