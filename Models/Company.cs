namespace DCS.Contact
{
    /// <summary>
    /// Represents a company.
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class.
        /// </summary>
        public Company() { }

        /// <summary>
        /// Gets or sets the unique identifier of the company.
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the company.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Indicates whether the company is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the primary contact person of a company.
        /// </summary>
        public Guid? CompanyContact { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the contact who created the company.
        /// </summary>
        public Guid? ContactGuid { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the user who created the company.
        /// </summary>
        public Guid UserGuid { get; set; }
    }
}
