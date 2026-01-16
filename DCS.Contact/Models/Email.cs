using DCS.CoreLib;
using DCS.CoreLib.BaseClass;

namespace DCS.Contact
{
    /// <summary>
    /// Email class for the email model.
    /// </summary>
    public class Email : ModelBase, IEntity<Guid>
    {
        /// <summary>
        /// Constructor for the email class.
        /// </summary>
        public Email() { }

        /// <summary>
        /// Gets or sets the type of the email address.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        public string MailAdress { get; set; }
    }
}
