using DCS.CoreLib.BaseClass;

namespace DCS.Contact
{
    /// <summary>
    /// Represents an physical adress.
    /// </summary>
    public class Adress : ModelBase<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Adress"/> class.
        /// </summary>
        public Adress() { }

        /// <summary>
        /// Gets or sets the street name of the adress.
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Gets or sets the house number of the adress.
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// Gets or sets the adress addon of the adress.
        /// </summary>
        public string AdressAddon { get; set; }

        /// <summary>
        /// Gets or sets the city of a adress.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the postal code of a adress.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the country of a adress.
        /// </summary>
        public string Country { get; set; }
    }
}
