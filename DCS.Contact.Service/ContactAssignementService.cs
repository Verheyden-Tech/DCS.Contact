using DCS.CoreLib.BaseClass;

namespace DCS.Contact.Service
{
    /// <summary>
    /// Provides functionality for managing and interacting with contact assignments.
    /// </summary>
    /// <remarks>This service is responsible for operations related to the <see cref="ContactAssignement"/>
    /// entity,  leveraging the specified repository for data access. It extends the <see cref="ServiceBase{TKey,
    /// TEntity, TRepository}"/>  class, providing a specialized implementation for contact assignment
    /// management.</remarks>
    public class ContactAssignementService : ServiceBase<Guid, ContactAssignement, IContactAssignementRepository>, IContactAssignementService
    {
        private readonly IContactAssignementRepository repository = CommonServiceLocator.ServiceLocator.Current.GetInstance<IContactAssignementRepository>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactAssignementService"/> class.
        /// </summary>
        /// <remarks>This constructor sets up the service with the specified repository, which is used to
        /// perform data operations related to contact assignments. Ensure that a valid implementation of  <see
        /// cref="IContactAssignementRepository"/> is provided.</remarks>
        /// <param name="contactAssignementRepository">The repository used to manage contact assignments. This parameter cannot be null.</param>
        public ContactAssignementService(IContactAssignementRepository contactAssignementRepository) : base(contactAssignementRepository)
        {
            this.repository = contactAssignementRepository;
        }

        /// <inheritdoc/>
        public bool AddAdressToContact(Guid contactGuid, Guid adressGuid)
        {
            var assignement = new ContactAssignement
            {
                ContactGuid = contactGuid,
                AdressGuid = adressGuid
            };

            if (repository.New(assignement))
                return true;

            return false;
        }

        /// <inheritdoc/>
        public bool RemoveAdressFromContact(Guid contactGuid, Guid adressGuid)
        {
            var assignement = repository.GetAll().FirstOrDefault(ca => ca.ContactGuid == contactGuid && ca.AdressGuid == adressGuid);

            if (assignement != null && repository.Delete(assignement.Guid))
                return true;

            return false;
        }

        /// <inheritdoc/>
        public bool AddEmailToContact(Guid contactGuid, Guid emailGuid)
        {
            var assignement = new ContactAssignement
            {
                ContactGuid = contactGuid,
                EmailGuid = emailGuid
            };

            if (repository.New(assignement))
                return true;

            return false;
        }

        /// <inheritdoc/>
        public bool RemoveEmailFromContact(Guid contactGuid, Guid emailGuid)
        {
            var assignement = repository.GetAll().FirstOrDefault(ca => ca.ContactGuid == contactGuid && ca.EmailGuid == emailGuid);

            if (assignement != null && repository.Delete(assignement.Guid))
                return true;

            return false;
        }

        /// <inheritdoc/>
        public bool AddPhoneToContact(Guid contactGuid, Guid phoneGuid)
        {
            var assignement = new ContactAssignement
            {
                ContactGuid = contactGuid,
                PhoneGuid = phoneGuid
            };

            if (repository.New(assignement))
                return true;

            return false;
        }

        /// <inheritdoc/>
        public bool RemovePhoneFromContact(Guid contactGuid, Guid phoneGuid)
        {
            var assignement = repository.GetAll().FirstOrDefault(ca => ca.ContactGuid == contactGuid && ca.PhoneGuid == phoneGuid);

            if (assignement != null && repository.Delete(assignement.Guid))
                return true;

            return false;
        }

        /// <inheritdoc/>
        public bool AddCompanyToContact(Guid contactGuid, Guid companyGuid)
        {
            var assignement = new ContactAssignement
            {
                ContactGuid = contactGuid,
                CompanyGuid = companyGuid
            };

            if (repository.New(assignement))
                return true;

            return false;
        }

        /// <inheritdoc/>
        public bool RemoveCompanyFromContact(Guid contactGuid, Guid companyGuid)
        {
            var assignement = repository.GetAll().FirstOrDefault(ca => ca.ContactGuid == contactGuid && ca.CompanyGuid == companyGuid);

            if (assignement != null && repository.Delete(assignement.Guid))
                return true;

            return false;
        }

        /// <inheritdoc/>
        public bool AddGroupToContact(Guid contactGuid, Guid groupGuid)
        {
            var assignement = new ContactAssignement
            {
                ContactGuid = contactGuid,
                GroupGuid = groupGuid
            };

            if (repository.New(assignement))
                return true;

            return false;
        }

        /// <inheritdoc/>
        public bool RemoveGroupFromContact(Guid contactGuid, Guid groupGuid)
        {
            var assignement = repository.GetAll().FirstOrDefault(ca => ca.ContactGuid == contactGuid && ca.GroupGuid == groupGuid);

            if (assignement != null && repository.Delete(assignement.Guid))
                return true;

            return false;
        }

        /// <inheritdoc/>
        public bool AddRoleToContact(Guid contactGuid, Guid roleGuid)
        {
            var assignement = new ContactAssignement
            {
                ContactGuid = contactGuid,
                RoleGuid = roleGuid
            };

            if (repository.New(assignement))
                return true;

            return false;
        }

        /// <inheritdoc/>
        public bool RemoveRoleFromContact(Guid contactId, Guid roleGuid)
        {
            var assignement = repository.GetAll().FirstOrDefault(ca => ca.ContactGuid == contactId && ca.RoleGuid == roleGuid);

            if (assignement != null && repository.Delete(assignement.Guid))
                return true;

            return false;
        }
    }
}

