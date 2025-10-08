namespace DCS.Contact
{
    /// <summary>
    /// Defines the contract for managing contact assignments within the system.
    /// </summary>
    /// <remarks>This service provides operations for creating, retrieving, updating, and deleting contact
    /// assignments. It extends the base service functionality with a focus on the <see cref="ContactAssignement"/>
    /// entity.</remarks>
    public interface IContactAssignementService : IContactAssignementRepository
    {
        /// <summary>
        /// Associates an address with a contact.
        /// </summary>
        /// <remarks>This method creates a new association between the specified contact and address.
        /// Ensure that both identifiers correspond to existing entities in the repository.</remarks>
        /// <param name="contactGuid">The unique identifier of the contact to which the address will be added.</param>
        /// <param name="adressGuid">The unique identifier of the address to associate with the contact.</param>
        /// <returns><see langword="true"/> if the address was successfully associated with the contact; otherwise, <see
        /// langword="false"/>.</returns>
        bool AddAdressToContact(Guid contactGuid, Guid adressGuid);
        /// <summary>
        /// Removes the association between a contact and an address.
        /// </summary>
        /// <remarks>This method attempts to find the association between the specified contact and
        /// address. If the association  exists, it is removed. If no such association is found, the method returns <see
        /// langword="false"/>.</remarks>
        /// <param name="contactGuid">The unique identifier of the contact.</param>
        /// <param name="adressGuid">The unique identifier of the address to be removed from the contact.</param>
        /// <returns><see langword="true"/> if the association between the contact and the address was successfully removed; 
        /// otherwise, <see langword="false"/>.</returns>
        bool RemoveAdressFromContact(Guid contactGuid, Guid adressGuid);
        /// <summary>
        /// Associates a phone with a contact.
        /// </summary>
        /// <remarks>This method creates an association between a contact and a phone using their
        /// respective unique identifiers. Ensure that both the contact and phone exist in the system before calling
        /// this method.</remarks>
        /// <param name="contactGuid">The unique identifier of the contact to which the phone will be assigned.</param>
        /// <param name="phoneGuid">The unique identifier of the phone to be assigned to the contact.</param>
        /// <returns><see langword="true"/> if the phone was successfully associated with the contact; otherwise, <see
        /// langword="false"/>.</returns>
        bool AddPhoneToContact(Guid contactGuid, Guid phoneGuid);
        /// <summary>
        /// Removes the association between a contact and a phone number.
        /// </summary>
        /// <remarks>This method removes the link between the specified contact and phone number if such
        /// an association exists. If no matching association is found, the method returns <see
        /// langword="false"/>.</remarks>
        /// <param name="contactGuid">The unique identifier of the contact.</param>
        /// <param name="phoneGuid">The unique identifier of the phone number to be removed.</param>
        /// <returns><see langword="true"/> if the association was successfully removed; otherwise, <see langword="false"/>.</returns>
        bool RemovePhoneFromContact(Guid contactGuid, Guid phoneGuid);
        /// <summary>
        /// Associates an email with a contact.
        /// </summary>
        /// <remarks>This method creates an association between a contact and an email. Ensure that both
        /// the contact and email identifiers are valid and exist in the system before calling this method.</remarks>
        /// <param name="contactGuid">The unique identifier of the contact to which the email will be assigned.</param>
        /// <param name="emailGuid">The unique identifier of the email to be associated with the contact.</param>
        /// <returns><see langword="true"/> if the email was successfully associated with the contact; otherwise, <see
        /// langword="false"/>.</returns>
        bool AddEmailToContact(Guid contactGuid, Guid emailGuid);
        /// <summary>
        /// Removes the association between a contact and an email address.
        /// </summary>
        /// <remarks>This method attempts to remove the specified email address from the specified
        /// contact.  If no association exists between the contact and the email address, the method returns <see
        /// langword="false"/>.</remarks>
        /// <param name="contactGuid">The unique identifier of the contact.</param>
        /// <param name="emailGuid">The unique identifier of the email address to be removed from the contact.</param>
        /// <returns><see langword="true"/> if the association was successfully removed; otherwise, <see langword="false"/>.</returns>
        bool RemoveEmailFromContact(Guid contactGuid, Guid emailGuid);
        /// <summary>
        /// Associates a company with a contact.
        /// </summary>
        /// <remarks>This method creates an association between a contact and a company. Ensure that both
        /// identifiers represent valid entities in the system before calling this method.</remarks>
        /// <param name="contactGuid">The unique identifier of the contact to which the company will be associated.</param>
        /// <param name="companyGuid">The unique identifier of the company to associate with the contact.</param>
        /// <returns><see langword="true"/> if the company was successfully associated with the contact; otherwise, <see
        /// langword="false"/>.</returns>
        bool AddCompanyToContact(Guid contactGuid, Guid companyGuid);
        /// <summary>
        /// Removes the association between a contact and a company.
        /// </summary>
        /// <remarks>This method searches for an existing association between the specified contact and
        /// company. If the association is found, it is removed. If no association exists, the method returns <see
        /// langword="false"/>.</remarks>
        /// <param name="contactGuid">The unique identifier of the contact.</param>
        /// <param name="companyGuid">The unique identifier of the company.</param>
        /// <returns><see langword="true"/> if the association was successfully removed; otherwise, <see langword="false"/>.</returns>
        bool RemoveCompanyFromContact(Guid contactGuid, Guid companyGuid);
        /// <summary>
        /// Assigns a contact to a specified company.
        /// </summary>
        /// <remarks>This method creates an association between a contact and a group. Ensure that both
        /// the contact and group exist before calling this method. The operation will fail if the assignment cannot be
        /// persisted.</remarks>
        /// <param name="contactGuid">The unique identifier of the contact to be assigned to the group.</param>
        /// <param name="groupGuid">The unique identifier of the group to which the contact will be assigned.</param>
        /// <returns><see langword="true"/> if the contact was successfully assigned to the group; otherwise, <see
        /// langword="false"/>.</returns>
        bool AddGroupToContact(Guid contactGuid, Guid groupGuid);
        /// <summary>
        /// Removes the association between a contact and a group.
        /// </summary>
        /// <remarks>This method searches for an existing association between the specified contact and
        /// group. If the association is found, it is removed. If no association exists, the method returns <see
        /// langword="false"/>.</remarks>
        /// <param name="contactGuid">The unique identifier of the contact.</param>
        /// <param name="groupGuid">The unique identifier of the group.</param>
        /// <returns><see langword="true"/> if the association was successfully removed; otherwise, <see langword="false"/>.</returns>
        bool RemoveGroupFromContact(Guid contactGuid, Guid groupGuid);
        /// <summary>
        /// Assigns a role to a contact by creating a new role assignment.
        /// </summary>
        /// <remarks>This method creates a new role assignment for the specified contact and role.  Ensure
        /// that both the <paramref name="contactGuid"/> and <paramref name="roleGuid"/> correspond to valid
        /// entities.</remarks>
        /// <param name="contactGuid">The unique identifier of the contact to which the role will be assigned.</param>
        /// <param name="roleGuid">The unique identifier of the role to assign to the contact.</param>
        /// <returns><see langword="true"/> if the role was successfully assigned to the contact; otherwise, <see
        /// langword="false"/>.</returns>
        bool AddRoleToContact(Guid contactGuid, Guid roleGuid);
        /// <summary>
        /// Removes the specified role from the contact.
        /// </summary>
        /// <remarks>This method attempts to remove the association between the specified contact and
        /// role. If no such association exists, the method returns <see langword="false"/>.</remarks>
        /// <param name="contactGuid">The unique identifier of the contact.</param>
        /// <param name="roleGuid">The unique identifier of the role to be removed.</param>
        /// <returns><see langword="true"/> if the role was successfully removed from the contact;  otherwise, <see
        /// langword="false"/>.</returns>
        bool RemoveRoleFromContact(Guid contactGuid, Guid roleGuid);
    }
}
