namespace DCS.Contact
{
    /// <summary>
    /// Email class for the email model.
    /// </summary>
    public class Email
    {
        /// <summary>
        /// Constructor for the email class.
        /// </summary>
        public Email() { }

        /// <summary>
        /// Gets or sets the Guid of the email.
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets the type of the email address.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        public string MailAdress { get; set; }

        /// <summary>
        /// Indicates wether the email address is active or not.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
