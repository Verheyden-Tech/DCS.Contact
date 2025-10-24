using DCS.CoreLib.BaseClass;
using System;
using System.Collections.ObjectModel;

namespace DCS.Contact.UI
{
    /// <summary>
    /// ViewModel for company instances.
    /// </summary>
    public class CompanyViewModel : ViewModelBase<Guid, Company>
    {
        private ICompanyService service = CommonServiceLocator.ServiceLocator.Current.GetInstance<ICompanyService>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyViewModel"/> class.
        /// </summary>
        /// <param name="company"></param>
        public CompanyViewModel(Company company) : base(company)
        {
            this.Model = company;
            this.Collection = new ObservableCollection<Company>();
        }

        /// <summary>
        /// Creates a new company based on the current model and adds it to the collection if successful.
        /// </summary>
        /// <remarks>
        /// This method generates a new company using the properties of the <see cref="ViewModelBase{TKey, TModel}.Model"/>
        /// object, assigns it a unique identifier, and attempts to save it using the company service. If the operation
        /// succeeds, the new company is added to the <see cref="ViewModelBase{TKey, TModel}.Collection"/>. If the <see cref="ViewModelBase{TKey, TModel}.Model"/> is null or an
        /// exception occurs during the operation, the method logs an error and returns <see langword="false"/>.
        /// </remarks>
        /// <returns><see langword="true"/> if the new company is successfully created and added to the collection; otherwise, <see langword="false"/>.</returns>
        public bool CreateNewCompany()
        {
            if (Model != null)
            {
                try
                {
                    var newCompany = new Company
                    {
                        Guid = Guid.NewGuid(),
                        Name = Model.Name,
                        Description = Model.Description,
                        Type = Model.Type,
                        IsActive = Model.IsActive
                    };

                    if (service.New(newCompany).Result)
                    {
                        Collection.Add(newCompany);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Log.LogManager.Singleton.Error($"Exception occurred while creating new Company: {ex.Message}", "CompanyViewModel.CreateNewCompany");
                    return false;
                }
            }

            Log.LogManager.Singleton.Error("Model is null. Cannot create new Company.", "CompanyViewModel.CreateNewCompany");
            return false;
        }

        /// <summary>
        /// Updates the company information in the service based on the current model.
        /// </summary>
        /// <remarks>
        /// This method attempts to update an existing company in the service using the data from
        /// the current model. If the company does not exist, it attempts to create a new company. Logs are generated for any
        /// errors or exceptional conditions encountered during the operation.
        /// </remarks>
        /// <returns><see langword="true"/> if the company was successfully updated or created; otherwise, <see langword="false"/>.</returns>
        public bool UpdateCompany()
        {
            if (Model != null)
            {
                var company = service.Get(Model.Guid).Result;
                if (company != null)
                {
                    try
                    {
                        var updatedCompany = new Company
                        {
                            Guid = Model.Guid,
                            Name = Model.Name,
                            Description = Model.Description,
                            Type = Model.Type,
                            IsActive = Model.IsActive
                        };

                        if (service.Update(updatedCompany).Result)
                            return true;
                    }
                    catch (Exception ex)
                    {
                        Log.LogManager.Singleton.Error($"Exception occurred while updating Company: {ex.Message}", "CompanyViewModel.UpdateCompany");
                        return false;
                    }
                }
                else
                {
                    if (CreateNewCompany())
                        return true;
                }

                Log.LogManager.Singleton.Error("Company not found in service. Cannot update Company.", "CompanyViewModel.UpdateCompany");
                return false;
            }

            Log.LogManager.Singleton.Error("Model is null. Cannot update Company.", "CompanyViewModel.UpdateCompany");
            return false;
        }

        #region Public Props
        /// <summary>
        /// Gets or sets the unique identifier of the company.
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
        /// Gets or sets the name of the company.
        /// </summary>
        public string Name
        {
            get => Model.Name;
            set
            {
                if (!Equals(value, Model.Name))
                {
                    Model.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        /// <summary>
        /// Gets or sets the description associated with the company.
        /// </summary>
        public string Description
        {
            get => Model.Description;
            set
            {
                if (!Equals(value, Model.Description))
                {
                    Model.Description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        /// <summary>
        /// Gets or sets the type of the company.
        /// </summary>
        public string Type
        {
            get => Model.Type;
            set
            {
                if (!Equals(value, Model.Type))
                {
                    Model.Type = value;
                    OnPropertyChanged(nameof(Type));
                }
            }
        }

        /// <summary>
        /// Indicates whether the company is active.
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
        #endregion
    }
}
