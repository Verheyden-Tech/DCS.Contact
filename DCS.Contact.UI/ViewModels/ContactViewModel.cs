using DCS.CoreLib.BaseClass;
using DCS.CoreLib.Collection;
using System.Collections.ObjectModel;

namespace DCS.Contact.UI
{
    /// <summary>
    /// ViewModel for the contact editor.
    /// </summary>
    public class ContactViewModel : ViewModelBase<Guid, Contact>
    {
        private readonly IContactAssignementService contactAssignementService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IContactAssignementService>();
        private readonly IPhysicalAdressService contactAdressService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhysicalAdressService>();
        private readonly IEmailAdressService emailAdressService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IEmailAdressService>();
        private readonly IPhoneService phoneService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhoneService>();
        private readonly ICompanyService companyService = CommonServiceLocator.ServiceLocator.Current.GetInstance<ICompanyService>();

        private StatefulCollection<Adress> ContactAdresses = new StatefulCollection<Adress>();
        private StatefulCollection<Email> ContactEmails = new StatefulCollection<Email>();
        private StatefulCollection<Phone> ContactPhoneNumbers = new StatefulCollection<Phone>();
        private StatefulCollection<Company> ContactCompanies = new StatefulCollection<Company>();

        private Adress _contactAdress;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactViewModel"/> class using the specified contact.
        /// </summary>
        /// <remarks>This constructor initializes several collections, including contact addresses,
        /// emails, phone numbers, and companies, to manage related data for the specified contact.</remarks>
        /// <param name="contact">The contact object used to initialize the view model. Cannot be <see langword="null"/>.</param>
        public ContactViewModel(Contact contact) : base(contact)
        {
            this.Model = contact;

            //Get all contact related data
            ContactAdresses = GetContactAdresses(contact);
            ContactPhoneNumbers = GetContactPhoneNumbers(contact);
            ContactEmails = GetContactEmailAdresses(contact);
            ContactCompanies = GetContactCompanies(contact);

            if(ContactAdresses != null && ContactAdresses.Count > 0)
                _contactAdress = ContactAdresses.First();

            if (_contactAdress == null)
                _contactAdress = new Adress();
        }

        #region Get Contact Related Data Methods
        /// <summary>
        /// Retrieves a collection of addresses associated with the specified contact.
        /// </summary>
        /// <remarks>This method queries the contact assignment service to find address assignments linked
        /// to the specified contact.  It then retrieves the corresponding address details from the contact address
        /// service.</remarks>
        /// <param name="contact">The contact whose associated addresses are to be retrieved. The contact must have a valid <see
        /// cref="Guid"/>.</param>
        /// <returns>An <see cref="ObservableCollection{T}"/> of <see cref="Adress"/> objects representing the addresses
        /// associated with the specified contact.  If no addresses are found or an error occurs, an empty collection is
        /// returned.</returns>
        public StatefulCollection<Adress> GetContactAdresses(Contact contact)
        {
            try
            {
                StatefulCollection<Adress> contactAdresses = new StatefulCollection<Adress>();

                var contactAdressAssignements = contactAssignementService.GetAll().Where(ca => ca.ContactGuid == contact.Guid && ca.AdressGuid != null);

                if (contactAdressAssignements != null && contactAdressAssignements.Count() >= 0)
                {
                    foreach (var adress in contactAdressAssignements)
                    {
                        if (adress.AdressGuid != null)
                        {
                            var contactAdress = contactAdressService.Get(adress.AdressGuid.Value);

                            if (contactAdress != null && ContactAdresses != null)
                            {
                                contactAdresses.Add(contactAdress);
                            }
                        }
                    }
                }

                return contactAdresses;
            }
            catch (Exception ex)
            {
                Log.LogManager.Singleton.Error("Error while getting contact adresses: " + ex.Message, "ContactViewModel.GetContactAdresses");
                return new StatefulCollection<Adress>();
            }
        }

        /// <summary>
        /// Retrieves a collection of phone numbers associated with the specified contact.
        /// </summary>
        /// <remarks>This method queries the contact assignment service to find phone assignments linked
        /// to the specified contact. It then retrieves the corresponding phone details using the phone service. If an
        /// error occurs during the operation, the method logs the error and returns an empty collection.</remarks>
        /// <param name="contact">The contact whose phone numbers are to be retrieved. The contact must have a valid <see
        /// cref="Contact.Guid"/>.</param>
        /// <returns>An <see cref="ObservableCollection{T}"/> of <see cref="Phone"/> objects representing the phone numbers
        /// associated with the contact. If no phone numbers are found, an empty collection is returned.</returns>
        public StatefulCollection<Phone> GetContactPhoneNumbers(Contact contact)
        {
            try
            {
                StatefulCollection<Phone> contactPhoneNumbers = new StatefulCollection<Phone>();

                var contactPhoneAssignements = contactAssignementService.GetAll().Where(ca => ca.ContactGuid == contact.Guid && ca.PhoneGuid != null);

                if (contactPhoneAssignements != null && contactPhoneAssignements.Count() >= 0)
                {
                    foreach (var phone in contactPhoneAssignements)
                    {
                        if (phone.PhoneGuid != null)
                        {
                            var contactPhone = phoneService.Get(phone.PhoneGuid.Value);

                            if (contactPhone != null && ContactPhoneNumbers != null)
                            {
                                contactPhoneNumbers.Add(contactPhone);
                            }
                        }
                    }
                }

                return contactPhoneNumbers;
            }
            catch (Exception ex)
            {
                Log.LogManager.Singleton.Error("Error while getting contact phone numbers: " + ex.Message, "ContactViewModel.GetContactPhoneNumbers");
                return new StatefulCollection<Phone>();
            }
        }

        /// <summary>
        /// Retrieves a collection of email addresses associated with the specified contact.
        /// </summary>
        /// <remarks>This method queries the contact assignment service to find email assignments linked
        /// to the specified contact. It then retrieves the corresponding email details using the email address service.
        /// If an error occurs during the operation, the method logs the error and returns an empty
        /// collection.</remarks>
        /// <param name="contact">The contact whose email addresses are to be retrieved. The contact must have a valid <see
        /// cref="Contact.Guid"/>.</param>
        /// <returns>An <see cref="ObservableCollection{T}"/> of <see cref="Email"/> objects representing the email addresses
        /// associated with the contact. If no email addresses are found, an empty collection is returned.</returns>
        public StatefulCollection<Email> GetContactEmailAdresses(Contact contact)
        {
            try
            {
                StatefulCollection<Email> contactEmails = new StatefulCollection<Email>();

                var contactEmailAssignements = contactAssignementService.GetAll().Where(ca => ca.ContactGuid == contact.Guid && ca.EmailGuid != null);

                if (contactEmailAssignements != null && contactEmailAssignements.Count() >= 0)
                {
                    foreach (var email in contactEmailAssignements)
                    {
                        if (email.EmailGuid != null)
                        {
                            var contactEmail = emailAdressService.Get(email.EmailGuid.Value);

                            if (contactEmail != null && ContactEmails != null)
                            {
                                contactEmails.Add(contactEmail);
                            }
                        }
                    }
                }

                return contactEmails;
            }
            catch (Exception ex)
            {
                Log.LogManager.Singleton.Error("Error while getting contact emails: " + ex.Message, "ContactViewModel.GetContactEmailAdresses");
                return new StatefulCollection<Email>();
            }
        }

        /// <summary>
        /// Retrieves a collection of companies associated with the specified contact.
        /// </summary>
        /// <remarks>This method queries the contact assignments to find companies linked to the specified
        /// contact.  If a company cannot be retrieved or an error occurs during processing, the method logs the error
        /// and returns an empty collection.</remarks>
        /// <param name="contact">The contact whose associated companies are to be retrieved. The contact must have a valid <see
        /// cref="Contact.Guid"/>.</param>
        /// <returns>An <see cref="ObservableCollection{T}"/> of <see cref="Company"/> objects representing the companies
        /// associated with the specified contact.  Returns an empty collection if no companies are associated with the
        /// contact or if an error occurs.</returns>
        public StatefulCollection<Company> GetContactCompanies(Contact contact)
        {
            try
            {
                StatefulCollection<Company> contactCompanies = new StatefulCollection<Company>();

                var contactCompanyAssignements = contactAssignementService.GetAll().Where(ca => ca.ContactGuid == contact.Guid && ca.CompanyGuid != null);

                if (contactCompanyAssignements != null && contactCompanyAssignements.Count() >= 0)
                {
                    foreach (var company in contactCompanyAssignements)
                    {
                        if (company.CompanyGuid != null)
                        {
                            var contactCompany = companyService.Get(company.CompanyGuid.Value);

                            if (contactCompany != null && ContactCompanies != null)
                            {
                                contactCompanies.Add(contactCompany);
                            }
                        }
                    }
                }

                return contactCompanies;
            }
            catch (Exception ex)
            {
                Log.LogManager.Singleton.Error("Error while getting contact companies: " + ex.Message, "ContactViewModel.GetContactCompanies");
                return new StatefulCollection<Company>();
            }
        }
        #endregion

        #region Add Contact Related Data Methods
        /// <summary>
        /// Associates the specified address with the current contact.
        /// </summary>
        /// <remarks>This method creates a new assignment between the contact and the specified address. 
        /// Ensure that the <see cref="Adress.Guid"/> property of the provided address is valid and not empty.</remarks>
        /// <param name="adress">The address to associate with the contact. The <see cref="Adress.Guid"/> property must be set.</param>
        /// <returns><see langword="true"/> if the address was successfully associated with the contact; otherwise, <see
        /// langword="false"/>.</returns>
        public bool AddAdressToContact(Adress adress)
        {
            if (ContactAdresses.Contains(adress))
            {
                Log.LogManager.Singleton.Warning("Adress is already assigned to contact.", "ContactEditor.AddAdressToContact");
                return false;
            }

            var contactAdressAssignement = new ContactAssignement
            {
                Guid = Guid.NewGuid(),
                ContactGuid = Model.Guid,
                AdressGuid = adress.Guid
            };

            if (contactAssignementService.New(contactAdressAssignement))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Associates a phone number with the current contact.
        /// </summary>
        /// <remarks>This method creates a new association between the specified phone number and the
        /// current contact. Ensure that the <paramref name="phone"/> object is properly initialized before calling this
        /// method.</remarks>
        /// <param name="phone">The phone number to associate with the contact. The <see cref="Phone.Guid"/> property must be set.</param>
        /// <returns><see langword="true"/> if the phone number was successfully associated with the contact; otherwise, <see
        /// langword="false"/>.</returns>
        public bool AddPhoneToContact(Phone phone)
        {
            if(ContactPhoneNumbers.Contains(phone))
            {
                Log.LogManager.Singleton.Warning("Phone is already assigned to contact.", "ContactEditor.AddPhoneToContact");
                return false;
            }

            var contactPhoneAssignement = new ContactAssignement
            {
                Guid = Guid.NewGuid(),
                ContactGuid = Model.Guid,
                PhoneGuid = phone.Guid
            };

            if (contactAssignementService.New(contactPhoneAssignement))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Associates the specified email with the current contact.
        /// </summary>
        /// <remarks>This method creates a new association between the contact and the specified email. 
        /// Ensure that the provided email has a valid <see cref="Email.Guid"/> before calling this method.</remarks>
        /// <param name="email">The email to be added to the contact. The <see cref="Email.Guid"/> property must be set.</param>
        /// <returns><see langword="true"/> if the email was successfully associated with the contact; otherwise, <see
        /// langword="false"/>.</returns>
        public bool AddEmailToContact(Email email)
        {
            if(ContactEmails.Contains(email))
            {
                Log.LogManager.Singleton.Warning("Email is already assigned to contact.", "ContactEditor.AddEmailToContact");
                return false;
            }

            var contactEmailAssignement = new ContactAssignement
            {
                Guid = Guid.NewGuid(),
                ContactGuid = Model.Guid,
                EmailGuid = email.Guid
            };

            if (contactAssignementService.New(contactEmailAssignement))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Associates the specified company with the current contact.
        /// </summary>
        /// <param name="company">The company to associate with the contact. Must not be <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if the company was successfully associated with the contact; otherwise, <see
        /// langword="false"/>.</returns>
        public bool AddCompanyToContact(Company company)
        {
            if(ContactCompanies.Contains(company))
            {
                Log.LogManager.Singleton.Warning("Company is already assigned to contact.", "ContactEditor.AddCompanyToContact");
                return false;
            }

            var contactCompanyAssignement = new ContactAssignement
            {
                Guid = Guid.NewGuid(),
                ContactGuid = Model.Guid,
                CompanyGuid = company.Guid
            };

            if (contactAssignementService.New(contactCompanyAssignement))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region Remove Contact Related Data Methods
        /// <summary>
        /// Removes the specified address from the current contact.
        /// </summary>
        /// <remarks>The method checks if the specified address is associated with the current contact 
        /// and removes the association if it exists. If the address is not associated with the  contact, the method
        /// returns <see langword="false"/>.</remarks>
        /// <param name="adress">The address to be removed from the contact.</param>
        /// <returns><see langword="true"/> if the address was successfully removed from the contact;  otherwise, <see
        /// langword="false"/>.</returns>
        public bool RemoveAdressFromContact(Adress adress)
        {
            if(!ContactAdresses.Contains(adress))
            {
                Log.LogManager.Singleton.Warning("Adress is not assigned to contact.", "ContactEditor.RemoveAdressFromContact");
                return false;
            }

            var contactAdressAssignement = contactAssignementService.GetAll().FirstOrDefault(ca => ca.ContactGuid == Model.Guid && ca.AdressGuid == adress.Guid);
            
            if(contactAdressAssignement != null && contactAssignementService.Delete(contactAdressAssignement.Guid))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes the specified email from the current contact.
        /// </summary>
        /// <remarks>This method attempts to remove the association between the specified email and the
        /// current contact. If no such association exists, the method returns <see langword="false"/>.</remarks>
        /// <param name="email">The email to be removed from the contact. Must not be <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if the email was successfully removed from the contact; otherwise, <see
        /// langword="false"/>.</returns>
        public bool RemoveEmailFromContact(Email email)
        {
            if(!ContactEmails.Contains(email))
            {
                Log.LogManager.Singleton.Warning("Email is not assigned to contact.", "ContactEditor.RemoveEmailFromContact");
                return false;
            }

            var contactEmailAssignement = contactAssignementService.GetAll().FirstOrDefault(ca => ca.ContactGuid == Model.Guid && ca.EmailGuid == email.Guid);

            if (contactEmailAssignement != null && contactAssignementService.Delete(contactEmailAssignement.Guid))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes the specified phone number from the current contact.
        /// </summary>
        /// <remarks>This method attempts to remove the association between the specified phone number and
        /// the current contact. If no such association exists, the method returns <see langword="false"/>.</remarks>
        /// <param name="phone">The phone number to be removed, identified by its unique identifier.</param>
        /// <returns><see langword="true"/> if the phone number was successfully removed from the contact;  otherwise, <see
        /// langword="false"/>.</returns>
        public bool RemovePhoneFromContact(Phone phone)
        {
            if(!ContactPhoneNumbers.Contains(phone))
            {
                Log.LogManager.Singleton.Warning("Phonenumber is not assigned to contact.", "ContactEditor.RemovePhoneFromContact");
                return false;
            }

            var contactPhoneAssignement = contactAssignementService.GetAll().FirstOrDefault(ca => ca.ContactGuid == Model.Guid && ca.PhoneGuid == phone.Guid);

            if (contactPhoneAssignement != null && contactAssignementService.Delete(contactPhoneAssignement.Guid))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes the specified company from the current contact's assignments.
        /// </summary>
        /// <remarks>This method attempts to remove the specified company from the current contact's
        /// assignments. If the company is not assigned to the contact, the method returns <see langword="false"/>
        /// without performing any operation.</remarks>
        /// <param name="company">The company to be removed from the contact's assignments. Must not be <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if the company was successfully removed from the contact's assignments; otherwise,
        /// <see langword="false"/> if the company was not assigned to the contact or the removal operation failed.</returns>
        public bool RemoveCompanyFromContact(Company company)
        {
            if(!ContactCompanies.Contains(company))
            {
                Log.LogManager.Singleton.Warning("Company is not assigned to contact.", "ContactEditor.RemoveCompanyFromContact");
                return false;
            }

            var contactCompanyAssignement = contactAssignementService.GetAll().FirstOrDefault(ca => ca.ContactGuid == Model.Guid && ca.CompanyGuid == company.Guid);

            if (contactCompanyAssignement != null && contactAssignementService.Delete(contactCompanyAssignement.Guid))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region Public Props Contact
        /// <summary>
        /// Gets or sets the unique identifier of the contact.
        /// </summary>
        public Guid Guid
        {
            get
            {
                return Model.Guid;
            }
            set
            {
                Model.Guid = value;
                OnPropertyChanged(nameof(Guid));
            }
        }

        /// <summary>
        /// Gets or sets the first name of the contact.
        /// </summary>
        public string FirstName
        {
            get
            {
                return Model.FirstName;
            }
            set
            {
                Model.FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        /// <summary>
        /// Gets or sets the last name of the contact.
        /// </summary>
        public string LastName
        {
            get
            {
                return Model.LastName;
            }
            set
            {
                Model.LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        /// <summary>
        /// Indicates whether the contact is active.
        /// </summary>
        public bool IsActive
        {
            get
            {
                return Model.IsActive;
            }
            set
            {
                Model.IsActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }

        /// <summary>
        /// Gets or sets the creation date of the contact.
        /// </summary>
        public DateTime? CreationDate
        {
            get
            {
                return Model.CreationDate;
            }
            set
            {
                Model.CreationDate = value;
                OnPropertyChanged(nameof(CreationDate));
            }
        }

        /// <summary>
        /// Gets or sets the date and time of the last modification.
        /// </summary>
        public DateTime? LastModificationDate
        {
            get
            {
                return Model.LastModificationDate;
            }
            set
            {
                Model.LastModificationDate = value;
                OnPropertyChanged(nameof(LastModificationDate));
            }
        }

        /// <summary>
        /// Gets or sets the date and time when the contact was marked for deletion.
        /// </summary>
        public DateTime? DeleteDate
        {
            get
            {
                return Model.DeleteDate;
            }
            set
            {
                Model.DeleteDate = value;
                OnPropertyChanged(nameof(DeleteDate));
            }
        }

        /// <summary>
        /// Gets or sets the file path to the contact's profile picture.
        /// </summary>
        public string? ProfilePicturePath
        {
            get
            {
                return Model.ProfilePicturePath;
            }
            set
            {
                Model.ProfilePicturePath = value;
                OnPropertyChanged(nameof(ProfilePicturePath));
            }
        }
        #endregion

        #region Public Props Contact Related Data
        /// <summary>
        /// Gets or sets the name of the street associated with the contact's address.
        /// </summary>
        /// <remarks>Setting this property updates the corresponding street name in the underlying contact
        /// address and raises the OnPropertyChanged event for the <see cref="Adress.StreetName"/> property.</remarks>
        public string StreetName
        {
            get
            {
                return _contactAdress.StreetName;
            }
            set
            {
                if (_contactAdress != null)
                {
                    _contactAdress.StreetName = value;
                    OnPropertyChanged(nameof(StreetName));
                }
            }
        }

        /// <summary>
        /// Gets or sets the house number associated with the contact address.
        /// </summary>
        /// <remarks>Setting this property raises the OnPropertyChanged event for the contact associated
        /// <see cref="Adress.HouseNumber"/> property.</remarks>
        public string HouseNumber
        {
            get
            {
                return _contactAdress.HouseNumber;
            }
            set
            {
                if (_contactAdress != null)
                {
                    _contactAdress.HouseNumber = value;
                    OnPropertyChanged(nameof(HouseNumber));
                }
            }
        }

        /// <summary>
        /// Gets or sets the city associated with the contact address.
        /// </summary>
        /// <remarks>Setting this property updates the city in the underlying contact address and raises
        /// the OnPropertyChanged" event for the <see cref="Adress.City"/> property.</remarks>
        public string City
        {
            get
            {
                return _contactAdress.City;
            }
            set
            {
                if (_contactAdress != null)
                {
                    _contactAdress.City = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }

        /// <summary>
        /// Gets or sets the postal code associated with the contact address.
        /// </summary>
        /// <remarks>Setting this property updates the postal code in the underlying contact address and
        /// raises the OnPropertyChanged event for the <see cref="Adress.PostalCode"/> property.</remarks>
        public string PostalCode
        {
            get
            {
                return _contactAdress.PostalCode;
            }
            set
            {
                if (_contactAdress != null)
                {
                    _contactAdress.PostalCode = value;
                    OnPropertyChanged(nameof(PostalCode));
                }
            }
        }

        /// <summary>
        /// Gets or sets the country associated with the contact address.
        /// </summary>
        /// <remarks>Setting this property updates the country in the underlying contact address and
        /// raises the OnPropertyChanged event for the <see cref="Adress.Country"/> property.</remarks>
        public string Country
        {
            get
            {
                return _contactAdress.Country;
            }
            set
            {
                if (_contactAdress != null)
                {
                    _contactAdress.Country = value;
                    OnPropertyChanged(nameof(Country));
                }
            }
        }
        #endregion
    }
}
