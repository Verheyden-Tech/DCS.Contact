using DCS.CoreLib.BaseClass;
using System.Collections.ObjectModel;

namespace DCS.Contact.UI
{
    /// <summary>
    /// ViewModel for physical adresses.
    /// </summary>
    public class PhysicalAdressViewModel : ViewModelBase<Guid, Adress>
    {
        private IPhysicalAdressService physicalAdressService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhysicalAdressService>();

        /// <summary>
        /// Constructor for PhysicalAdressViewModel.
        /// </summary>
        public PhysicalAdressViewModel(Adress adress) : base()
        {
            this.Model = adress;
            this.Collection = new ObservableCollection<Adress>();
        }

        /// <summary>
        /// Creates a new address based on the current model and adds it to the collection if successful.
        /// </summary>
        /// <remarks>
        /// This method generates a new address using the properties of the <see cref="ViewModelBase{TKey, TModel}.Model"/>
        /// object, assigns it a unique identifier, and attempts to save it using the physical address service. If the operation
        /// succeeds, the new address is added to the <see cref="ViewModelBase{TKey, TModel}.Collection"/>. If the <see cref="ViewModelBase{TKey, TModel}.Model"/> is null or an
        /// exception occurs during the operation, the method logs an error and returns <see langword="false"/>.
        /// </remarks>
        /// <returns><see langword="true"/> if the new address is successfully created and added to the collection; otherwise, <see langword="false"/>.</returns>
        public bool CreateNewAdress()
        {
            if (Model != null)
            {
                try
                {
                    var newAdress = new Adress
                    {
                        Guid = Guid.NewGuid(),
                        StreetName = Model.StreetName,
                        HouseNumber = Model.HouseNumber,
                        AdressAddon = Model.AdressAddon,
                        PostalCode = Model.PostalCode,
                        City = Model.City,
                        Country = Model.Country,
                        IsActive = true // Default to active
                    };

                    if (physicalAdressService.New(newAdress).Result)
                    {
                        Collection.Add(newAdress);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Log.LogManager.Singleton.Error($"Exception occurred while creating new Address: {ex.Message}", "PhysicalAdressViewModel.CreateNewAdress");
                    return false;
                }
            }

            Log.LogManager.Singleton.Error("Model is null. Cannot create new Address.", "PhysicalAdressViewModel.CreateNewAdress");
            return false;
        }

        /// <summary>
        /// Updates the address information in the service based on the current model.
        /// </summary>
        /// <remarks>
        /// This method attempts to update an existing address in the service using the data from
        /// the current model. If the address does not exist, it attempts to create a new one. Logs are generated for any
        /// errors or exceptional conditions encountered during the operation.
        /// </remarks>
        /// <returns><see langword="true"/> if the address was successfully updated or created; otherwise, <see langword="false"/>.</returns>
        public bool UpdateAdress()
        {
            if (Model != null)
            {
                var adress = physicalAdressService.Get(Model.Guid);
                if (adress != null)
                {
                    try
                    {
                        var updatedAdress = new Adress
                        {
                            Guid = Model.Guid,
                            StreetName = Model.StreetName,
                            HouseNumber = Model.HouseNumber,
                            AdressAddon = Model.AdressAddon,
                            PostalCode = Model.PostalCode,
                            City = Model.City,
                            Country = Model.Country,
                            IsActive = Model.IsActive
                        };

                        if (physicalAdressService.Update(updatedAdress).Result)
                            return true;
                    }
                    catch (Exception ex)
                    {
                        Log.LogManager.Singleton.Error($"Exception occurred while updating Address: {ex.Message}", "PhysicalAdressViewModel.UpdateAdress");
                        return false;
                    }
                }
                else
                {
                    if (CreateNewAdress())
                        return true;
                }

                Log.LogManager.Singleton.Error("Address not found in service. Cannot update Address.", "PhysicalAdressViewModel.UpdateAdress");
                return false;
            }

            Log.LogManager.Singleton.Error("Model is null. Cannot update Address.", "PhysicalAdressViewModel.UpdateAdress");
            return false;
        }

        #region Public Props
        /// <summary>
        /// Gets or sets the guid of a adress.
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
        /// Gets or sets the street name of a adress.
        /// </summary>
        public string StreetName
        {
            get
            {
                return Model.StreetName;
            }
            set
            {
                Model.StreetName = value;
            }
        }

        /// <summary>
        /// Gets or sets the house number of a adress.
        /// </summary>
        public string HouseNumber
        {
            get
            {
                return Model.HouseNumber;
            }
            set
            {
                Model.HouseNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the adress suffix of a adress.
        /// </summary>
        public string AddressAddon
        {
            get
            {
                return Model.AdressAddon;
            }
            set
            {
                Model.AdressAddon = value;
            }
        }

        /// <summary>
        /// Gets or sets the postal code of a adress.
        /// </summary>
        public string PostalCode
        {
            get
            {
                return Model.PostalCode;
            }
            set
            {
                Model.PostalCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the city of a adress.
        /// </summary>
        public string City
        {
            get
            {
                return Model.City;
            }
            set
            {
                Model.City = value;
            }
        }

        /// <summary>
        /// Gets or sets the country of a adress.
        /// </summary>
        public string Country
        {
            get
            {
                return Model.Country;
            }
            set
            {
                Model.Country = value;
            }
        }
        #endregion
    }
}
