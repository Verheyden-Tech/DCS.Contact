using DCS.CoreLib.BaseClass;
using System;
using System.Collections.ObjectModel;

namespace DCS.Contact.UI
{
    /// <summary>
    /// ViewModel for EmailAdress.
    /// </summary>
    public class EmailAdressViewModel : ViewModelBase<Guid, Email>
    {
        private IEmailAdressService emailAdressService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IEmailAdressService>();

        /// <summary>
        /// Constructor for EmailAdressViewModel.
        /// </summary>
        public EmailAdressViewModel(Email email) : base()
        {
            this.Model = email;
            this.Collection = new ObservableCollection<Email>();
        }

        /// <summary>
        /// Creates a new email based on the current model and adds it to the collection if successful.
        /// </summary>
        /// <remarks>
        /// This method generates a new email using the properties of the <see cref="ViewModelBase{TKey, TModel}.Model"/>
        /// object, assigns it a unique identifier, and attempts to save it using the email address service. If the operation
        /// succeeds, the new email is added to the <see cref="ViewModelBase{TKey, TModel}.Collection"/>. If the <see cref="ViewModelBase{TKey, TModel}.Model"/> is null or an
        /// exception occurs during the operation, the method logs an error and returns <see langword="false"/>.
        /// </remarks>
        /// <returns><see langword="true"/> if the new email is successfully created and added to the collection; otherwise, <see langword="false"/>.</returns>
        public bool CreateNewEmail()
        {
            if (Model != null)
            {
                try
                {
                    var newEmail = new Email
                    {
                        Guid = Guid.NewGuid(),
                        MailAdress = Model.MailAdress,
                        Type = Model.Type,
                        IsActive = true // Default to active
                    };

                    if (emailAdressService.New(newEmail).Result)
                    {
                        Collection.Add(newEmail);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Log.LogManager.Singleton.Error($"Exception occurred while creating new Email: {ex.Message}", "EmailAdressViewModel.CreateNewEmail");
                    return false;
                }
            }

            Log.LogManager.Singleton.Error("Model is null. Cannot create new Email.", "EmailAdressViewModel.CreateNewEmail");
            return false;
        }

        /// <summary>
        /// Updates the email information in the service based on the current model.
        /// </summary>
        /// <remarks>
        /// This method attempts to update an existing email in the service using the data from
        /// the current model. If the email does not exist, it attempts to create a new email. Logs are generated for any
        /// errors or exceptional conditions encountered during the operation.
        /// </remarks>
        /// <returns><see langword="true"/> if the email was successfully updated or created; otherwise, <see langword="false"/>.</returns>
        public bool UpdateEmail()
        {
            if (Model != null)
            {
                var email = emailAdressService.Get(Model.Guid);
                if (email != null)
                {
                    try
                    {
                        var updatedEmail = new Email
                        {
                            Guid = Model.Guid,
                            MailAdress = Model.MailAdress,
                            Type = Model.Type,
                            IsActive = Model.IsActive
                        };

                        if (emailAdressService.Update(updatedEmail).Result)
                            return true;
                    }
                    catch (Exception ex)
                    {
                        Log.LogManager.Singleton.Error($"Exception occurred while updating Email: {ex.Message}", "EmailAdressViewModel.UpdateEmail");
                        return false;
                    }
                }
                else
                {
                    if (CreateNewEmail())
                        return true;
                }

                Log.LogManager.Singleton.Error("Email not found in service. Cannot update Email.", "EmailAdressViewModel.UpdateEmail");
                return false;
            }

            Log.LogManager.Singleton.Error("Model is null. Cannot update Email.", "EmailAdressViewModel.UpdateEmail");
            return false;
        }

        #region Public Props
        /// <summary>
        /// Gets or sets the guid of a email adress.
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
            }
        }

        /// <summary>
        /// Gets or sets the type of a email adress.
        /// </summary>
        public string Type
        {
            get
            {
                return Model.Type;
            }
            set
            {
                Model.Type = value;
            }
        }

        /// <summary>
        /// Gets or sets the mail adress.
        /// </summary>
        public string MailAdress
        {
            get
            {
                return Model.MailAdress;
            }
            set
            {
                Model.MailAdress = value;
            }
        }
        #endregion
    }
}
