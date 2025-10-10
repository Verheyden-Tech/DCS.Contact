namespace DCS.Contact
{
    /// <summary>
    /// Phone class model for phone number data on the table.
    /// </summary>
    public class Phone
    {
        /// <summary>
        /// Constructor for the Phone class.
        /// </summary>
        public Phone() { }

        /// <summary>
        /// Gets or sets the Guid of the phone number.
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets the type of the phone number.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets wether the phone number is active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
