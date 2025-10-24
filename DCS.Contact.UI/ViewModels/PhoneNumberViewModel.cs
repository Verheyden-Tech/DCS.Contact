using DCS.CoreLib.BaseClass;
using System;
using System.Collections.ObjectModel;

namespace DCS.Contact.UI
{
    /// <summary>
    /// ViewModel for phone numbers.
    /// </summary>
    public class PhoneNumberViewModel : ViewModelBase<Guid, Phone>
    {
        private IPhoneService phoneService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhoneService>();

        /// <summary>
        /// Constructor for PhoneNumberViewModel.
        /// </summary>
        public PhoneNumberViewModel(Phone phone) : base()
        {
            this.Model = phone;
            this.Collection = new ObservableCollection<Phone>();
        }

        /// <summary>
        /// Creates a new phone number based on the current model and adds it to the collection if successful.
        /// </summary>
        /// <remarks>
        /// This method generates a new phone number using the properties of the <see cref="ViewModelBase{TKey, TModel}.Model"/>
        /// object, assigns it a unique identifier, and attempts to save it using the phone service. If the operation
        /// succeeds, the new phone number is added to the <see cref="ViewModelBase{TKey, TModel}.Collection"/>. If the <see cref="ViewModelBase{TKey, TModel}.Model"/> is null or an
        /// exception occurs during the operation, the method logs an error and returns <see langword="false"/>.
        /// </remarks>
        /// <returns><see langword="true"/> if the new phone number is successfully created and added to the collection; otherwise, <see langword="false"/>.</returns>
        public bool CreateNewPhone()
        {
            if (Model != null)
            {
                try
                {
                    var newPhone = new Phone
                    {
                        Guid = Guid.NewGuid(),
                        PhoneNumber = Model.PhoneNumber,
                        Type = Model.Type,
                        IsActive = true // Default to active
                    };

                    if (phoneService.New(newPhone).Result)
                    {
                        Collection.Add(newPhone);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Log.LogManager.Singleton.Error($"Exception occurred while creating new Phone: {ex.Message}", "PhoneNumberViewModel.CreateNewPhone");
                    return false;
                }
            }

            Log.LogManager.Singleton.Error("Model is null. Cannot create new Phone.", "PhoneNumberViewModel.CreateNewPhone");
            return false;
        }

        /// <summary>
        /// Updates the phone number information in the service based on the current model.
        /// </summary>
        /// <remarks>
        /// This method attempts to update an existing phone number in the service using the data from
        /// the current model. If the phone number does not exist, it attempts to create a new one. Logs are generated for any
        /// errors or exceptional conditions encountered during the operation.
        /// </remarks>
        /// <returns><see langword="true"/> if the phone number was successfully updated or created; otherwise, <see langword="false"/>.</returns>
        public bool UpdatePhone()
        {
            if (Model != null)
            {
                var phone = phoneService.Get(Model.Guid);
                if (phone != null)
                {
                    try
                    {
                        var updatedPhone = new Phone
                        {
                            Guid = Model.Guid,
                            PhoneNumber = Model.PhoneNumber,
                            Type = Model.Type,
                            IsActive = Model.IsActive
                        };

                        if (phoneService.Update(updatedPhone).Result)
                            return true;
                    }
                    catch (Exception ex)
                    {
                        Log.LogManager.Singleton.Error($"Exception occurred while updating Phone: {ex.Message}", "PhoneNumberViewModel.UpdatePhone");
                        return false;
                    }
                }
                else
                {
                    if (CreateNewPhone())
                        return true;
                }

                Log.LogManager.Singleton.Error("Phone not found in service. Cannot update Phone.", "PhoneNumberViewModel.UpdatePhone");
                return false;
            }

            Log.LogManager.Singleton.Error("Model is null. Cannot update Phone.", "PhoneNumberViewModel.UpdatePhone");
            return false;
        }

        #region Public Props
        /// <summary>
        /// Gets or sets the guid of a phone number.
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
        /// Gets or sets the type of a phone number.
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
        /// Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return Model.PhoneNumber;
            }
            set
            {
                Model.PhoneNumber = value;
            }
        }
        #endregion
    }
}
