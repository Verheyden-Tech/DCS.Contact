using DCS.CoreLib.BaseClass;
using System;
using System.Collections.ObjectModel;

namespace DCS.Contact.UI
{
    /// <summary>
    /// ViewModel for contact instances.
    /// </summary>
    public class ContactViewModel : ViewModelBase<Guid, Contact>
    {
        private readonly IContactService service = CommonServiceLocator.ServiceLocator.Current.GetInstance<IContactService>();
        private readonly IEmailAdressService emailService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IEmailAdressService>();
        private readonly IPhoneService phoneService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhoneService>();
        private readonly IContactAssignementService contactAssignementService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IContactAssignementService>();
        private readonly IPhysicalAdressService adressService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhysicalAdressService>();

        private PhysicalAdressViewModel adressViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactViewModel"/> class.
        /// </summary>
        /// <param name="contact"></param>
        public ContactViewModel(Contact contact) : base(contact)
        {
            this.Model = contact;
            this.Collection = new ObservableCollection<Contact>();

            var adressObj = new Adress();
            adressViewModel = new PhysicalAdressViewModel(adressObj);

            var contactAdress = contactAssignementService.GetAll().Result.Where(ca => ca.ContactGuid == contact.Guid && ca.AdressGuid != null).FirstOrDefault();
            if (contactAdress != null)
            {
                var adress = adressService.Get((Guid)contactAdress.AdressGuid).Result;
                if (adress != null)
                {
                    adressViewModel = new PhysicalAdressViewModel(adress);
                }
            }
        }

        #region Create, Update, Delete Contact
        /// <summary>
        /// Creates a new contact based on the current model and adds it to the collection if successful.
        /// </summary>
        /// <remarks>
        /// This method generates a new contact using the properties of the <see cref="ViewModelBase{TKey, TModel}.Model"/>
        /// object, assigns it a unique identifier, and attempts to save it using the contact service. If the operation
        /// succeeds, the new contact is added to the <see cref="ViewModelBase{TKey, TModel}.Collection"/>. If the <see cref="ViewModelBase{TKey, TModel}.Model"/> is null or an
        /// exception occurs during the operation, the method logs an error and returns <see langword="false"/>.
        /// </remarks>
        /// <returns><see langword="true"/> if the new contact is successfully created and added to the collection; otherwise, <see langword="false"/>.</returns>
        public bool CreateNewContact()
        {
            if (Model != null)
            {
                try
                {
                    var newContact = new Contact
                    {
                        Guid = Guid.NewGuid(),
                        FirstName = Model.FirstName,
                        LastName = Model.LastName,
                        ProfilePicturePath = Model.ProfilePicturePath,
                        IsActive = Model.IsActive
                    };

                    if (service.New(newContact).Result)
                    {
                        Collection.Add(newContact);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Log.LogManager.Singleton.Error($"Exception occurred while creating new Contact: {ex.Message}", "ContactViewModel.CreateNewContact");
                    return false;
                }
            }

            Log.LogManager.Singleton.Error("Model is null. Cannot create new Contact.", "ContactViewModel.CreateNewContact");
            return false;
        }

        /// <summary>
        /// Updates the contact information in the service based on the current model.
        /// </summary>
        /// <remarks>
        /// This method attempts to update an existing contact in the service using the data from
        /// the current model. If the contact does not exist, it attempts to create a new contact. Logs are generated for any
        /// errors or exceptional conditions encountered during the operation.
        /// </remarks>
        /// <returns><see langword="true"/> if the contact was successfully updated or created; otherwise, <see langword="false"/>.</returns>
        public bool UpdateContact()
        {
            if (Model != null)
            {
                var contact = service.Get(Model.Guid).Result;
                if (contact != null)
                {
                    try
                    {
                        var updatedContact = new Contact
                        {
                            Guid = Model.Guid,
                            FirstName = Model.FirstName,
                            LastName = Model.LastName,
                            ProfilePicturePath = Model.ProfilePicturePath,
                            IsActive = Model.IsActive
                        };

                        if (service.Update(updatedContact).Result)
                            return true;
                    }
                    catch (Exception ex)
                    {
                        Log.LogManager.Singleton.Error($"Exception occurred while updating Contact: {ex.Message}", "ContactViewModel.UpdateContact");
                        return false;
                    }
                }
                else
                {
                    if (CreateNewContact())
                        return true;
                }

                Log.LogManager.Singleton.Error("Contact not found in service. Cannot update Contact.", "ContactViewModel.UpdateContact");
                return false;
            }

            Log.LogManager.Singleton.Error("Model is null. Cannot update Contact.", "ContactViewModel.UpdateContact");
            return false;
        }

        /// <summary>
        /// Deletes the current contact from the database and removes it from the collection.
        /// </summary>
        /// <remarks>This method attempts to delete the contact represented by the current <see
        /// cref="ViewModelBase{TKey, TModel}.Model"/> from the database. If the contact is successfully deleted, it is also removed from the <see
        /// cref="ViewModelBase{TKey, TModel}.Collection"/>. If the contact does not exist in the database, or if an error occurs during the
        /// deletion process, the method logs the error and returns <see langword="false"/>.</remarks>
        /// <returns><see langword="true"/> if the contact was successfully deleted from the database and removed from the
        /// collection; otherwise, <see langword="false"/>.</returns>
        public bool DeleteContact()
        {
            if (Model != null)
            {
                try
                {
                    var existingContact = service.Get(Model.Guid).Result;
                    if(existingContact != null)
                    {
                        if (service.Delete(Model.Guid).Result)
                        {
                            Collection.Remove(Model);
                            return true;
                        }
                    }
                    
                    Log.LogManager.Singleton.Error($"Contact {Model.FirstName} {Model.LastName} not found in database. Cannot delete Contact.", "ContactViewModel.DeleteContact");
                    return false;
                }
                catch (Exception ex)
                {
                    Log.LogManager.Singleton.Error($"Exception occurred while deleting Contact: {ex.Message}", "ContactViewModel.DeleteContact");
                    return false;
                }
            }

            Log.LogManager.Singleton.Error("Model is null. Cannot delete Contact.", "ContactViewModel.DeleteContact");
            return false;
        }
        #endregion

        #region Add/Remove Email and Phone to/from Contact
        /// <summary>
        /// Adds an email to the contact's email collection.
        /// </summary>
        /// <param name="email">The email to add.</param>
        /// <returns>True if the email was added successfully, otherwise false.</returns>
        public bool AddEmailToContact(Email email)
        {
            if (email != null)
            {
                if (emailService.New(email).Result)
                {
                    Emails.Add(email);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Removes an email from the contact's email collection.
        /// </summary>
        /// <param name="email">The email to remove.</param>
        /// <returns>True if the email was removed successfully, otherwise false.</returns>
        public bool RemoveEmailFromContact(Email email)
        {
            if (email != null)
            {
                if (emailService.Delete(email.Guid).Result)
                {
                    Emails.Remove(email);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Adds a phone number to the contact's phone collection.
        /// </summary>
        /// <param name="phone">The phone number to add.</param>
        /// <returns>True if the phone number was added successfully, otherwise false.</returns>
        public bool AddPhoneToContact(Phone phone)
        {
            if (phone != null)
            {
                if (phoneService.New(phone).Result)
                {
                    Phones.Add(phone);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Removes a phone number from the contact's phone collection.
        /// </summary>
        /// <param name="phone">The phone number to remove.</param>
        /// <returns>True if the phone number was removed successfully, otherwise false.</returns>
        public bool RemovePhoneFromContact(Phone phone)
        {
            if (phone != null)
            {
                if (phoneService.Delete(phone.Guid).Result)
                {
                    Phones.Remove(phone);
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the unique identifier of the contact.
        /// </summary>
        public Guid Guid
        {
            get => Model.Guid;
            set
            {
                if (!Equals(value, Model.Guid))
                {
                    Model.Guid = value;
                    OnPropertyChanged(nameof(Guid));
                }
            }
        }

        /// <summary>
        /// Gets or sets the first name of the contact.
        /// </summary>
        public string FirstName
        {
            get => Model.FirstName;
            set
            {
                if (!Equals(value, Model.FirstName))
                {
                    Model.FirstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        /// <summary>
        /// Gets or sets the last name of the contact.
        /// </summary>
        public string LastName
        {
            get => Model.LastName;
            set
            {
                if (!Equals(value, Model.LastName))
                {
                    Model.LastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        /// <summary>
        /// Gets or sets the path to the profile picture of the contact.
        /// </summary>
        public string ProfilePicturePath
        {
            get => Model.ProfilePicturePath;
            set
            {
                if (!Equals(value, Model.ProfilePicturePath))
                {
                    Model.ProfilePicturePath = value;
                    OnPropertyChanged(nameof(ProfilePicturePath));
                }
            }
        }

        /// <summary>
        /// Indicates whether the contact is active.
        /// </summary>
        public bool IsActive
        {
            get => Model.IsActive;
            set
            {
                if (!Equals(value, Model.IsActive))
                {
                    Model.IsActive = value;
                    OnPropertyChanged(nameof(IsActive));
                }
            }
        }

        /// <summary>
        /// Gets or sets the street name of the contact's address.
        /// </summary>
        public string ContactStreetName
        {
            get => adressViewModel.StreetName;
            set
            {
                if (!Equals(value, adressViewModel.StreetName))
                {
                    adressViewModel.StreetName = value;
                    OnPropertyChanged(nameof(ContactStreetName));
                }
            }
        }

        /// <summary>
        /// Gets or sets the house number associated with the contact's address.
        /// </summary>
        public string ContactHouseNumber
        {
            get => adressViewModel.HouseNumber;
            set
            {
                if (!Equals(value, adressViewModel.HouseNumber))
                {
                    adressViewModel.HouseNumber = value;
                    OnPropertyChanged(nameof(ContactHouseNumber));
                }
            }
        }

        /// <summary>
        /// Gets or sets the city associated with the contact's address.
        /// </summary>
        public string ContactCity
        {
            get => adressViewModel.City;
            set
            {
                if (!Equals(value, adressViewModel.City))
                {
                    adressViewModel.City = value;
                    OnPropertyChanged(nameof(ContactCity));
                }
            }
        }

        /// <summary>
        /// Gets or sets the postal code associated with the contact's address.
        /// </summary>
        public string ContactPostalCode
        {
            get => adressViewModel.PostalCode;
            set
            {
                if (!Equals(value, adressViewModel.PostalCode))
                {
                    adressViewModel.PostalCode = value;
                    OnPropertyChanged(nameof(ContactPostalCode));
                }
            }
        }

        /// <summary>
        /// Gets or sets the country associated with the contact's address.
        /// </summary>
        public string ContactCountry
        {
            get => adressViewModel.Country;
            set
            {
                if (!Equals(value, adressViewModel.Country))
                {
                    adressViewModel.Country = value;
                    OnPropertyChanged(nameof(ContactCountry));
                }
            }
        }

        /// <summary>
        /// Gets or sets the collection of emails associated with the contact.
        /// </summary>
        public ObservableCollection<Email> Emails
        {
            get => Emails;
            set
            {
                if (!Equals(value, Emails))
                {
                    Emails = value;
                    OnPropertyChanged(nameof(Emails));
                }
            }
        }

        /// <summary>
        /// Gets or sets the collection of phone numbers associated with the contact.
        /// </summary>
        public ObservableCollection<Phone> Phones
        {
            get => Phones;
            set
            {
                if (!Equals(value, Phones))
                {
                    Phones = value;
                    OnPropertyChanged(nameof(Phones));
                }
            }
        }
        #endregion
    }
}
